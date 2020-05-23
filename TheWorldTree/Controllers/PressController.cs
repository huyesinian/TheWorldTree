using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apps.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWorldTree.Data;
using TheWorldTree.Models;
using System.Reflection;
using TheWorldTree.EXMethod;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class PressController : BaseVerifyController
    {
        public TreeBaseEX TreeBaseEX;
        public TreePressEX  treePressEX;
        public TheWorldTreeDBContext _context;
       
        public PressController(TheWorldTreeDBContext context)
        {
            treePressEX= new TreePressEX(context);
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
        public JsonResult GetList(int page,int limit,string searchInfo)
        {
            var result = treePressEX.GetJsonList(page, limit, searchInfo);
            return Json(result);
        }
        #endregion

        #region 创建
        [HttpGet]
        public IActionResult Create()
        {
            TreePress press = new TreePress()
            {
                ID = Guid.NewGuid().ToString()
            };
            ViewBag.Issues = TreeBaseEX.GetDic("单选是");
            return View(press);
        }

        [HttpPost]
        public JsonResult Create(TreePress press)
        {
            press.Creater = GetCurrentU();
            press.CreateTime = DateTime.Now;
            if (press != null && ModelState.IsValid)
            {
                try
                {
                    if (treePressEX.Create(press) == Suc)
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
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name+":"+ex.ToString());
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
            TreePress press = treePressEX.GetList<TreePress>().Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Issues = TreeBaseEX.GetDic("单选是",press.Issue);
            return View(press);
        }

        [HttpPost]
        public JsonResult Edit(TreePress press)
        {
            press.UpdateOne= GetCurrentU();
            press.UpdateTime = DateTime.Now; 
            if (press != null && ModelState.IsValid)
            {
                try
                {
                    if (treePressEX.Edit(press) == Suc)
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
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + MethodBase.GetCurrentMethod().Name +":"+ ex.ToString());
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
                    TreePress press = treePressEX.GetList<TreePress>().Where(x => x.ID == id).FirstOrDefault();
                    if (treePressEX.Delete(press) == Suc)
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