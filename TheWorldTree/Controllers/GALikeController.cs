﻿using System;
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
    public class GALikeController : BaseController
    {
        public TreeBaseEX  treeBaseEX;
        public TreeGALikeEX  treeGALikeEX;
        public TheWorldTreeDBContext _context;

        public GALikeController(TheWorldTreeDBContext context)
        {
            treeGALikeEX = new TreeGALikeEX(context);
            treeBaseEX = new TreeBaseEX(context);
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
            var result = treeGALikeEX.GetJsonList(page, limit, searchInfo);
            return Json(result);
        }
        #endregion

        #region 创建
        [HttpGet]
        public IActionResult Create()
        {
            TreeGALike gal = new TreeGALike()
            {
                ID = Guid.NewGuid().ToString()
            };
         
            return View(gal);
        }

        [HttpPost]
        public JsonResult Create(TreeGALike gal)
        {
            gal.Creater = GetCurrentU();
            gal.CreateTime = DateTime.Now;
            if (gal != null && ModelState.IsValid)
            {
                try
                {
                    if (treeGALikeEX.Create(gal) == Suc)
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

            return Json(JsonHandler.CreateMessage(Def, /*GetEntityError()*/""));

        }
        #endregion

        #region 修改
        [HttpGet]
        public IActionResult Edit(string id)
        {
            TreeGALike gal = treeGALikeEX.GetList<TreeGALike>().Where(x => x.ID == id).FirstOrDefault();
           
            return View(gal);
        }

        [HttpPost]
        public JsonResult Edit(TreeGALike gal)
        {
            gal.UpdateOne = GetCurrentU();
            gal.UpdateTime = DateTime.Now;
            if (gal != null && ModelState.IsValid)
            {
                try
                {
                    if (treeGALikeEX.Edit(gal) == Suc)
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
            return Json(JsonHandler.CreateMessage(1, /*GetEntityError()*/""));

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
                    TreeGALike gal = treeGALikeEX.GetList<TreeGALike>().Where(x => x.ID == id).FirstOrDefault();
                    if (treeGALikeEX.Delete(gal) == Suc)
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
