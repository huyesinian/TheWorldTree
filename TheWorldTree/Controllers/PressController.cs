using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apps.Common;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    public class PressController : BaseVerifyController
    {
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;
        public PressController(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            var result = Rubbish.GetJsonList<TreePress>();
            return Json(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            TreePress press = new TreePress();
            return View(press);
        }

        [HttpPost]
        public JsonResult Create(TreePress press)
        {
            if (press != null && ModelState.IsValid)
            {
                try
                {
                    if (Rubbish.Create(press) == 0)
                    {
                        return Json(JsonHandler.CreateMessage(0, ""));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(1, ""));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            return Json(1);
           
           
        }


    }
}