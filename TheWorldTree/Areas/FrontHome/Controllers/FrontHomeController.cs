using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pipelines.Sockets.Unofficial.Arenas;
using TheWorldTree.Controllers;
using TheWorldTree.Data;
using TheWorldTree.EXMethod;

namespace TheWorldTree.Areas.FrontHome
{
    [Area("FrontHome")]
    public class FrontHomeController : BaseController
    {
        public TreeFileInfoEX treeFileInfoEX;
        public TheWorldTreeDBContext _context;

        public FrontHomeController(TheWorldTreeDBContext context)
        {
            treeFileInfoEX = new TreeFileInfoEX(context);
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public JsonResult GetImage(int page,int sum,string searchInfo=null)
        {
            var result = treeFileInfoEX.GetJsonList(page, sum, searchInfo);
            return Json(result);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search(string key)
        {
            var result = treeFileInfoEX.SearchJsonList(1, 0, key);
            return Json(result);
        }
    }
}
