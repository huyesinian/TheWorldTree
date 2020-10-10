using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TheWorldTree.Controllers;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Areas.FrontHome
{
    /// <summary>
    /// 前端留言板
    /// </summary>
    [Area("FrontHome")]
    public class FrontMsgController : BaseController
    {
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;

        public FrontMsgController(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
        }
        public IActionResult Index()
        {
            Rubbish.RecordUId(GetCurrentU());
            var MsgList = _context.TreeMsgBoard.Where(x => x.ContentId == null).OrderByDescending(x => x.CreateTime).ToList();
            ViewBag.Msgs = MsgList;
            ViewBag.ContentSums = MsgList.Count;
            TreeMsgBoard treeMsgBoard = new TreeMsgBoard()
            {
                ID = Guid.NewGuid().ToString()
            };
            return View(treeMsgBoard);
        }

        /// <summary>
        /// 关于提交留言板的相关信息
        /// </summary>
        /// <param name="treeMsgBoard">页面信息</param>
        /// <returns></returns>
        public JsonResult MsgBoard(TreeMsgBoard treeMsgBoard)
        {
            treeMsgBoard.ID = Guid.NewGuid().ToString();
            treeMsgBoard.CreateTime = DateTime.Now;
            var userIP = GetCurrentU();//先获取当前登录用户的IP
            treeMsgBoard.Creater = userIP;
            _context.Add(treeMsgBoard);
            _context.SaveChanges();
            Redis.UpdateClientIPErrorNum(userIP);
            return Json(Suc);
        }

       

    }
}
