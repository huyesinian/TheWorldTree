using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.EXMethod
{
    /// <summary>
    /// 一些基础方法
    /// </summary>
    public  class TreeBaseEX
    {
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly TheWorldTreeDBContext _db;
        public TreeBaseEX(TheWorldTreeDBContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 获取字典集合
        /// </summary>
        /// <param name="para">字典编码</param>
        /// <param name="vals">现有结果值</param>
        /// <returns></returns>
        public  List<SelectListItem> GetDic(string para, dynamic vals = null)
        {
            var sel = new List<SelectListItem>();
            try
            {
                string strVals = vals;
                var dic = _db.TreeDic.Where(x => x.DicCode == para).Select(x => new { x.NodeCode, x.NodeName, x.CreateTime }).OrderBy(x => x.CreateTime).ToList();
                foreach (var item in dic)
                {
                    sel.Add(strVals == item.NodeCode ? new SelectListItem { Text = item.NodeName, Value = item.NodeCode, Selected = true } : new SelectListItem { Text = item.NodeName, Value = item.NodeCode });
                }
                return sel;
            }
            catch (Exception ex)
            {
                Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                return sel;
            }
            
        }


        /// <summary>
        /// 获取当前年份的每月访问人数
        /// </summary>
        /// <returns></returns>
        public IPinfo GetIPinfo()
        {
            var IPI = new IPinfo();
            try
            {
                IPI = ExtendDBEX.ExecProcReader<IPinfo>(_db, "proc_GetIPInfo", null).FirstOrDefault();
                return IPI;
            }
            catch (Exception ex)
            {
                Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                return IPI;
            }
        }




    }
}
