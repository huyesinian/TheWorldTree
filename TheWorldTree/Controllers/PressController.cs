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

        #region 查询
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            var result = Rubbish.GetJsonList<TreePress>();
            return Json(result);
        }
        #endregion

        #region 创建
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
                        return Json(JsonHandler.CreateMessage(0, "创建成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(1, "创建失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(ex.ToString());
                    return Json(JsonHandler.CreateMessage(1, "创建失败" + ex.ToString()));
                }

            }
            return Json(JsonHandler.CreateMessage(1, "创建失败,数据验证未通过"));

        }
        #endregion

        #region 修改
        [HttpGet]
        public IActionResult Edit(string id)
        {
            TreePress press = Rubbish.GetList<TreePress>().Where(x => x.ID == id).FirstOrDefault();
            return View(press);
        }

        [HttpPost]
        public JsonResult Edit(TreePress press)
        {
            if (press != null && ModelState.IsValid)
            {
                try
                {
                    if (Rubbish.Edit(press) == 0)
                    {
                        return Json(JsonHandler.CreateMessage(0, "修改成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(1, "修改失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(ex.ToString());
                    return Json(JsonHandler.CreateMessage(1, "修改失败" + ex.ToString()));
                }

            }
            return Json(JsonHandler.CreateMessage(1, "修改失败,数据验证未通过"));

        }
        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    TreePress press = Rubbish.GetList<TreePress>().Where(x => x.ID == id).FirstOrDefault();
                    if (Rubbish.Delete(press) == 0)
                    {

                        return Json(JsonHandler.CreateMessage(0, "删除成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(1, "删除失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(ex.ToString());
                    return Json(JsonHandler.CreateMessage(1, "删除失败" + ex.ToString()));
                }

            }
            else
            {
                return Json(JsonHandler.CreateMessage(1, "请选择要删除的数据"));
            }

        }
        #endregion



    }
}