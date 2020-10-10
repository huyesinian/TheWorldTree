using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pipelines.Sockets.Unofficial.Arenas;
using TheWorldTree.Controllers;
using TheWorldTree.Data;
using TheWorldTree.EXMethod;
using TheWorldTree.Models;

namespace TheWorldTree.Areas.FrontHome
{
    [Area("FrontHome")]
    public class FrontHomeController : BaseController
    {
        public RubbishSel Rubbish;
        public TreeFileInfoEX treeFileInfoEX;
        public TheWorldTreeDBContext _context;

        public FrontHomeController(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            treeFileInfoEX = new TreeFileInfoEX(context);
            _context = context;
        }
        public IActionResult Index()
        {
            Rubbish.RecordUId(GetCurrentU());
            var Content= _context.TreePress.Where(x => x.Issue == "1").ToList();
            ViewBag.ContentHome = Content;
            ViewBag.ContentSums = Content.Count();
            ViewBag.ImgHome = _context.TreeFileInfo.Where(x => x.UseType == "导图").ToList();
            return View();
        }

        /// <summary>
        /// 详细页面
        /// </summary>
        /// <param name="contentId">留言关联id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(string contentId)
        {
            TreeMsgBoard treeMsgBoard = new TreeMsgBoard()
            { 
            ID=Guid.NewGuid().ToString(),
            ContentId= contentId
            };
            var Content= _context.TreePress.Where(x => x.ID == contentId).FirstOrDefault();
            var MsgContent= _context.TreeMsgBoard.Where(x => x.ContentId == contentId).ToList();
            ViewBag.TreePressS = Content;
            ViewBag.MsgBoards = MsgContent;
            ViewBag.ContentSums = MsgContent.Count();
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
            //var selResult = Redis.GetMsgIPNum(userIP);  //去redis中查询当天留言次数
            _context.Add(treeMsgBoard);
            _context.SaveChanges();
            Redis.UpdateClientIPErrorNum(userIP);
            return Json(Suc);
        }







    }
}
