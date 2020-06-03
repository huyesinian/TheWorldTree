﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TheWorldTree.Data;
using TheWorldTree.Models;
namespace TheWorldTree.Controllers
{
    public class UploadFileController : BaseVerifyController
    {
        private readonly IConfiguration _config;
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;
        public UploadFileController(TheWorldTreeDBContext context, IConfiguration config)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
            _config = config;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> UploadIMG(IFormFileCollection files, string contentId = null)
        {
            files = Request.Form.Files;
            try
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {

                        var filePath = _config.GetSection("UploadUrl").Value + DateTime.Now.ToString("yyyy-MM-dd") + "/" + contentId + "/";
                        Directory.CreateDirectory(filePath);
                        filePath += formFile.FileName;
                        //var filePath = Path.GetTempFileName();//这里的路径可以通过配置文件进行修改,合成路径
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await formFile.CopyToAsync(stream);
                            var TreeF = new TreeFileInfo()
                            {
                                ID = Guid.NewGuid().ToString(),
                                ContentID = contentId,
                                Content_Type = formFile.ContentType,
                                FileName = formFile.FileName.Substring(0, formFile.FileName.LastIndexOf(".")),
                                FileFullName = formFile.FileName,
                                FileLength = formFile.Length,
                                Expanded_name = formFile.FileName.Substring(formFile.FileName.LastIndexOf(".")),
                                FilePath = filePath,
                                FileRelPath = Rubbish.UrlConvertor(filePath),
                                Creater = "",
                                CreateTime = DateTime.Now
                            };
                            var imgI = new ImgInfo()
                            {
#if DEBUG
                                src = "https://localhost:44391/" + "/" + TreeF.FileRelPath,
#else
                                src = "http://localhost:5241"+"/"+TreeF.FileRelPath,
#endif
                                title = ""
                            };

                            if (Rubbish.Create(TreeF) == Suc)
                            {
                                JsonImg jsonimg = new JsonImg()
                                {
                                    code = 0,
                                    msg = "",
                                    data = imgI
                                };
                                var jsonresult = JsonConvert.SerializeObject(jsonimg);
                                return Json(jsonresult);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                return Json(Def);
            }

            return Json(Suc);
        }
    }



}