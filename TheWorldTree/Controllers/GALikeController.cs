using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Apps.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    TreeGALike gal = new TreeGALike()
        //    {
        //        ID = Guid.NewGuid().ToString()
        //    };

        //    return View(gal);
        //}

        /// <summary>
        /// 创建点赞信息
        /// </summary>
        /// <param name="contentId">关联id</param>
        /// <param name="useMoudle">使用模块</param>
        /// <param name="likeSum">点赞数</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(string contentId,string useMoudle,int likeSum)
        {
            TreeGALike gal = new TreeGALike()
            {
                ID = Guid.NewGuid().ToString(),
                ContentID= contentId,
                LikeMan= GetCurrentU(),
                UseModule= useMoudle
            };
            gal.Creater = GetCurrentU();
            gal.CreateTime = DateTime.Now;
            if (gal != null && ModelState.IsValid)
            {
                try
                {
                    if (treeGALikeEX.Create(gal) == Suc)
                    {
                        //创建成功之后还需要修改点赞数
                        TreeSay treeSay = _context.TreeSay.Where(x => x.ID == contentId).FirstOrDefault();
                        if (treeSay!=null)
                        {
                            treeSay.GiveLikeS = likeSum;
                            _context.Entry(treeSay).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
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

      

        #region 删除
        /// <summary>
        /// 删除点赞信息
        /// </summary>
        /// <param name="contentId">关联id</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string contentId, int likeSum)
        {
            if (!string.IsNullOrWhiteSpace(contentId))
            {
                try
                {
                    TreeGALike gal = treeGALikeEX.GetList<TreeGALike>().Where(x => x.ContentID == contentId&&x.LikeMan== GetCurrentU()).FirstOrDefault();
                    if (treeGALikeEX.Delete(gal) == Suc)
                    {
                        //删除成功之后还需要修改点赞数
                        TreeSay treeSay = _context.TreeSay.Where(x => x.ID == contentId).FirstOrDefault();
                        if (treeSay != null)
                        {
                            treeSay.GiveLikeS = likeSum;
                            _context.Entry(treeSay).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
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
