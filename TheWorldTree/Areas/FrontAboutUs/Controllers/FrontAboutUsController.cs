using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheWorldTree.Controllers;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Areas.FrontAboutUs.Controllers
{
    /// <summary>
    /// “关于”页面的控制
    /// </summary>
    [Area("FrontAboutUs")]
    public class FrontAboutUsController : BaseController
    {
        public TheWorldTreeDBContext _context;

        public FrontAboutUsController(TheWorldTreeDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            TreeMsgBoard msgBoard = new TreeMsgBoard();
            return View(msgBoard);
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
            var selResult = Redis.GetMsgIPNum(userIP);  //去redis中查询当天留言次数
            if (selResult.Length > 0)//提示每天只能留言三次
            {
                return Json(selResult);
            }
            else//进行保存留言操作,并且记录数据
            {
                _context.Add(treeMsgBoard);
                _context.SaveChanges();
                Redis.UpdateClientIPErrorNum(userIP);
            }
            return Json(Suc);
        }
    }
}
