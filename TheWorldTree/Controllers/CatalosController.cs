﻿using Apps.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using TheWorldTree.Data;
using TheWorldTree.EXMethod;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 目录
    /// </summary>
    public class CatalosController : BaseVerifyController
    {
        public TreeBaseEX TreeBaseEX;
        public TreeCatalosEX  treeCatalosEX;
        public TheWorldTreeDBContext _context;

        public CatalosController(TheWorldTreeDBContext context)
        {
            treeCatalosEX = new TreeCatalosEX(context);
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
            ViewBag.IsLasts = TreeBaseEX.GetDic("单选是");
            ViewBag.Enables = TreeBaseEX.GetDic("单选是");
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
                    if (treeCatalosEX.Create(catalos) == Suc)
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

            return Json(JsonHandler.CreateMessage(1, GetEntityError()));

        }
        #endregion

        #region 修改
        [HttpGet]
        public IActionResult Edit(string id)
        {
            TreeCatalos catalos = treeCatalosEX.GetList<TreeCatalos>().Where(x => x.ID == id).FirstOrDefault();
            ViewBag.IsLasts = TreeBaseEX.GetDic("单选是",catalos.IsLast);
            ViewBag.Enables = TreeBaseEX.GetDic("单选是", catalos.Enable);
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
                    if (treeCatalosEX.Edit(catalos) == Suc)
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
            return Json(JsonHandler.CreateMessage(Def, GetEntityError()));

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
                    if (treeCatalosEX.Delete(catalos) == Suc)
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

        #region 获取目录json结果集
        [HttpPost]
        public JsonResult GetJsonResult(string id=null)
        {
            string CatalosJsonString = treeCatalosEX.GetJsonString(id);
            return Json(CatalosJsonString);

        }
        #endregion
    }
}
