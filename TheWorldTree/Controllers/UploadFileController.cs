using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var imgs = new List<ImgInfo>();
            files = Request.Form.Files;
            try
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = _config.GetSection("UploadUrl").Value + DateTime.Now.ToString("yyyy-MM-dd") + "/" + contentId + "/";
                        Directory.CreateDirectory(filePath);
                        //var filePath = Path.GetTempFileName();//这里的路径可以通过配置文件进行修改,合成路径
                        using (var stream = System.IO.File.Create(filePath + formFile.FileName))
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
                                Creater="",
                                CreateTime=DateTime.Now
                            };
                            var imgI = new ImgInfo()
                            {
                                url = filePath + formFile.FileName,
                                title = ""
                            };
                            imgs.Add(imgI);
                            if (Rubbish.Create(TreeF) == 0)
                            {
                                return Json(imgs);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }

            return Json(1);
        }
    }

    public class ImgInfo
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
    }


}