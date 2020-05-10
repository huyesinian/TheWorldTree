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
    public class CatalosController : BaseVerifyController
    {
        public TreeCatalosEX  treeCatalosEX;
        public TheWorldTreeDBContext _context;

        public CatalosController(TheWorldTreeDBContext context)
        {
            treeCatalosEX = new TreeCatalosEX(context);
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
            var result = treeCatalosEX.GetJsonList(page, limit, searchInfo);
            return Json(result);
        }
        #endregion

        #region 创建
        [HttpGet]
        public IActionResult Create()
        {
            TreeCatalos catalos = new TreeCatalos()
            {
                ID = Guid.NewGuid().ToString()
            };
            return View(catalos);
        }

        [HttpPost]
        public JsonResult Create(TreeCatalos catalos)
        {
            catalos.Creater = GetCurrentU();
            catalos.CreateTime = DateTime.Now;
            if (catalos != null && ModelState.IsValid)
            {
                try
                {
                    if (treeCatalosEX.Create(catalos) == 1)
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
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(1, "创建失败" + ex.ToString()));
                }

            }

            return Json(JsonHandler.CreateMessage(1, GetEntityError()));

        }
        #endregion

        #region 修改
        [HttpGet]
        public IActionResult Edit(string id)
        {
            TreeCatalos catalos = treeCatalosEX.GetList<TreeCatalos>().Where(x => x.ID == id).FirstOrDefault();
            return View(catalos);
        }

        [HttpPost]
        public JsonResult Edit(TreeCatalos catalos)
        {
            catalos.UpdateOne = GetCurrentU();
            if (catalos != null && ModelState.IsValid)
            {
                try
                {
                    if (treeCatalosEX.Edit(catalos) == 1)
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
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + MethodBase.GetCurrentMethod().Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(1, "修改失败" + ex.ToString()));
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
                    TreeCatalos catalos = treeCatalosEX.GetList<TreeCatalos>().Where(x => x.ID == id).FirstOrDefault();
                    if (treeCatalosEX.Delete(catalos) == 1)
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
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(1, "删除失败" + ex.ToString()));
                }

            }
            else
            {
                return Json(JsonHandler.CreateMessage(1, "请选择要删除的数据"));
            }

        }
        #endregion

        #region 获取目录json结果集
        [HttpPost]
        public JsonResult GetJsonResult()
        {
            //这里获取目录
            string CatalosJsonString = treeCatalosEX.GetJsonString();
            return Json(CatalosJsonString);

        }
        #endregion
    }
}
