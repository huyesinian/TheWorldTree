using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Data;

namespace TheWorldTree.Controllers
{
    public class UploadFileController : BaseVerifyController
    {
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;
        public UploadFileController(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> UploadIMG(List<IFormFile> files, string contentId = null)
        {
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Json(1);
        }
    }
}