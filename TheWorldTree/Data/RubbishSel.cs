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

        /// <summary>
        /// 创建
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="s">具体实体</param>
        /// <returns></returns>
        public int Create<T>(T s) where T : class
        {
            _context.Add(s);
            return _context.SaveChanges();
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
        /// 修改
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="s">传进来的实体</param>
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
                    {
                        _context.Entry(s).Property(prop.Name).CurrentValue = null;
                    }
                    var keys = _context.Entry(s).Property(prop.Name).Metadata.GetType().GetProperty("Keys");//判断当前字段是否为主键
                    object value = keys.GetValue(_context.Entry(s).Property(prop.Name).Metadata);
                    if (value==null)//如果是主键，则跳过修改属性
                    {
                        _context.Entry(s).Property(prop.Name).IsModified = true;
                    }
                   
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
        /// <param name="searchInfo">查询条件</param>
        /// <returns></returns>
        public string GetJsonList<T>(int p, int l,string searchInfo) where T : class
        {
            var SelResult = GetList<T>();
            var Sum = SelResult.Count();
            //这里是用来放查询方法的
            SelResult = GetPagingList(p,l, SelResult);
            string output = GetJsonResult(Sum, SelResult);
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
        /// 分页方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page">页数</param>
        /// <param name="limit">条数</param>
        /// <param name="ts">结果集</param>
        /// <returns></returns>
        public List<T> GetPagingList<T>(int page, int limit, List<T> ts)
        {
            List<T> resultList;
            if (page <= 1)
            {
                resultList = ts.Take(limit).ToList();
            }
            else
            {
                resultList = ts.Skip((page - 1) * limit).Take(limit).ToList();
            }
            return resultList;
        }

        /// <summary>
        /// 返回Json结果字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="totalNum">总条数</param>
        /// <param name="ts">结果集</param>
        /// <returns>Json结果字符串</returns>
        public string GetJsonResult<T>(int totalNum,List<T> ts)
        {
            TreeJsonTable jsonTable = new TreeJsonTable()
            {
                StateCode = 0,
                Msg = "",
                Count = totalNum,
                Data = ts
            };
            string output = JsonConvert.SerializeObject(jsonTable);
            return output;
        }

        /// <summary>
        /// 替换成相对路径
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public string UrlConvertor(string strUrl)
        {
            Uri uri1 = new Uri(strUrl);
            Uri uri2 = new Uri(@"E:\TheWorldTree\TheWorldTree\wwwroot");
            var url = "";
            if (strUrl.Contains("/FileSave"))
            {
                url = uri2.MakeRelativeUri(uri1).ToString().Substring(uri2.MakeRelativeUri(uri1).ToString().IndexOf("FileSave"));
            }
            else
            {
                url = uri2.MakeRelativeUri(uri1).ToString().Substring(uri2.MakeRelativeUri(uri1).ToString().IndexOf("ThumFileSave"));
            }
            return url;
        }
    }
}
