using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServiceStack;
using TheWorldTree.Interface;
using TheWorldTree.Models;

namespace TheWorldTree.Data
{
    /// <summary>
    /// 垃圾查询类
    /// </summary>
    public class RubbishSel : IBaseInterface
    {
        public TheWorldTreeDBContext _context;

        public RubbishSel(TheWorldTreeDBContext context)
        {
            _context = context;
        }

        public int Create<T>(T s) where T : class
        {
            _context.Add(s);
            return _context.SaveChanges();
        }

        public int Delete<T>(T s)
        {
            _context.Remove(s);
            return _context.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Edit<T>(T s) where T : class
        {
            _context.Set<T>().Attach(s);
            PropertyInfo[] props = s.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(s, null) != null)
                {
                    if (prop.GetValue(s, null).ToString() == " ")
                        _context.Entry(s).Property(prop.Name).CurrentValue = null;
                    _context.Entry(s).Property(prop.Name).IsModified = true;
                }
            }
            return _context.SaveChanges();

        }

        /// <summary>
        /// 带分页的结果集
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="p">页数</param>
        /// <param name="l">页面条数</param>
        /// <returns></returns>
        public string GetJsonList<T>(int p, int l) where T : class
        {
            var SelResult = _context.Set<T>().ToList();
            var pageSum = SelResult.Count();
            if (p <= 1)
            {
                SelResult = SelResult.Take(l).ToList();
            }
            else
            {
                SelResult = SelResult.Skip((p - 1) * l).Take(l).ToList();
            }
            TreeJsonTable jsonTable = new TreeJsonTable()
            {
                StateCode = 0,
                Msg = "",
                Count = pageSum,
                Data = SelResult
            };
            string output = JsonConvert.SerializeObject(jsonTable);
            return output;
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
        /// 替换成相对路径
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public string UrlConvertor(string strUrl)
        {
            Uri uri1 = new Uri(strUrl);
            Uri uri2 = new Uri(@"E:\TheWorldTree\TheWorldTree\wwwroot\");
            var url = uri2.MakeRelativeUri(uri1).ToString().Substring(uri2.MakeRelativeUri(uri1).ToString().IndexOf("FileSave"));
            return url;
        }
    }
}
