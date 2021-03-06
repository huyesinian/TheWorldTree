﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.EXMethod
{
    /// <summary>
    /// 留言板的扩展类
    /// </summary>
    public class TreeMsgBoardEX
    {
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;

        public TreeMsgBoardEX(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="s">具体实体</param>
        /// <returns></returns>
        public int Delete<T>(T s)
        {
            _context.Remove(s);
            return _context.SaveChanges();
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// 获取结果集字符串，带查询条件的那种
        /// </summary>
        /// <param name="p">页数</param>
        /// <param name="l">条数</param>
        /// <param name="searchInfo">查询条件</param>
        /// <returns></returns>
        public string GetJsonList(int p, int l, string searchInfo)
        {
            var SelResult = Rubbish.GetList<TreeMsgBoard>();//获取集合
            var Sum = SelResult.Count();//获取总数量
            if (searchInfo != null)
            {
                SelResult = SelResult.Where(x => x.UserIP.Contains(searchInfo) || x.MsgContent.Contains(searchInfo) || x.Phone.Contains(searchInfo) || x.Email.Contains(searchInfo)).ToList();
            }
            SelResult = Rubbish.GetPagingList(p, l, SelResult);
            string output = Rubbish.GetJsonResult(Sum, SelResult);
            return output;
        }
    }
}
