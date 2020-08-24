using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Apps.Common;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Data;
using TheWorldTree.EXMethod;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 说说控制器
    /// </summary>
    public class SayController : BaseVerifyController
    {
        public TreeBaseEX TreeBaseEX;
        public TreeSayEX TreeSayEX;
        public TheWorldTreeDBContext _context;

        public SayController(TheWorldTreeDBContext context)
        {
            TreeSayEX = new TreeSayEX(context);
            TreeBaseEX = new TreeBaseEX(context);
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region 查询
        /// <summary>
        /// 列表数
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="limit">数据条数</param>
        /// <param name="searchInfo">查询条件</param>
        /// <returns></returns>
        public JsonResult GetList(int page, int limit, string searchInfo)
        {
            var result = TreeSayEX.GetJsonList(page, limit, searchInfo);
            return Json(result);
        }
        #endregion

        #region 创建
        [HttpGet]
        public IActionResult Create()
        {
            TreeSay press = new TreeSay()
            {
                ID = Guid.NewGuid().ToString()
            };
            return View(press);
        }

        [HttpPost]
        public JsonResult Create(TreeSay press)
        {
            press.Creater = GetCurrentU();
            press.CreateTime = DateTime.Now;
            if (press != null && ModelState.IsValid)
            {
                try
                {
                    if (TreeSayEX.Create(press) == Suc)
                    {
                        return Json(JsonHandler.CreateMessage(Suc, "创建成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(Def, "创建失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "创建失败" + ex.ToString()));
                }

            }

            return Json(JsonHandler.CreateMessage(Def, GetEntityError()));

        }
        #endregion

        #region 修改
        [HttpGet]
        public IActionResult Edit(string id)
        {
            TreeSay press = TreeSayEX.GetList<TreeSay>().Where(x => x.ID == id).FirstOrDefault();
           
            return View(press);
        }

        [HttpPost]
        public JsonResult Edit(TreeSay press)
        {
            press.UpdateOne = GetCurrentU();
            press.UpdateTime = DateTime.Now;
            if (press != null && ModelState.IsValid)
            {
                try
                {
                    if (TreeSayEX.Edit(press) == Suc)
                    {
                        return Json(JsonHandler.CreateMessage(Suc, "修改成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(Def, "修改失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + MethodBase.GetCurrentMethod().Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "修改失败" + ex.ToString()));
                }

            }
            return Json(JsonHandler.CreateMessage(1, GetEntityError()));

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
                    TreeSay press = TreeSayEX.GetList<TreeSay>().Where(x => x.ID == id).FirstOrDefault();
                    if (TreeSayEX.Delete(press) == Suc)
                    {

                        return Json(JsonHandler.CreateMessage(Suc, "删除成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(Def, "删除失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "删除失败" + ex.ToString()));
                }

            }
            else
            {
                return Json(JsonHandler.CreateMessage(Def, "请选择要删除的数据"));
            }

        }
        #endregion
    }
}
