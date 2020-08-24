﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Controllers;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Areas.FrontHome.Controllers
{
    /// <summary>
    /// 说说
    /// </summary>
    [Area("FrontHome")]
    public class FrontSayController : BaseController
    {
        public TheWorldTreeDBContext _context;

        public FrontSayController(TheWorldTreeDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var SaySynthesize = (from s in _context.TreeSay 
                                 select new { TreeSays=s
                                 , TreeFileInfos = _context.TreeFileInfo.Where(x=>x.ContentID==s.ID).ToList()
                                 , TreeMsgBoards = _context.TreeMsgBoard.Where(x=>x.ContentId==s.ID).ToList() 
                                 }).ToList();
            List<TreeFrontSay> SaysList = new List<TreeFrontSay>();
            if (SaySynthesize.Count>0)
            {
                foreach (var item in SaySynthesize)
                {
                    TreeFrontSay treeFrontSay = new TreeFrontSay()
                    { 
                        TreeSays=item.TreeSays,
                        TreeFileInfos=item.TreeFileInfos,
                        TreeMsgBoards=item.TreeMsgBoards
                    };
                    SaysList.Add(treeFrontSay);
                }
            }
            ViewBag.TreeForntSays = SaysList;
            ViewBag.ContentSums = SaysList.Count();
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
