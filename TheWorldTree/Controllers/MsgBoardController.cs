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
    /// 后台留言板
    /// </summary>
    public class MsgBoardController : BaseVerifyController
    {
        public TreeMsgBoardEX treeMsgBoardEX;
        public TheWorldTreeDBContext _context;

        public MsgBoardController(TheWorldTreeDBContext context)
        {
            treeMsgBoardEX = new TreeMsgBoardEX(context);
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
            var result = treeMsgBoardEX.GetJsonList(page, limit, searchInfo);
            return Json(result);
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
                    TreeMsgBoard  msgBoard = treeMsgBoardEX.GetList<TreeMsgBoard>().Where(x => x.ID == id).FirstOrDefault();
                    if (treeMsgBoardEX.Delete(msgBoard) == 1)
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

    }
}
