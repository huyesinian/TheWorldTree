using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
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
        /// 获取json结果集
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public string GetJsonList<T>() where T : class
        {
            var SelResult = _context.Set<T>().ToList();
            TreeJsonTable jsonTable = new TreeJsonTable()
            {
                StateCode = 0,
                Msg = "",
                Count = SelResult.Count(),
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
            return   _context.Set<T>().ToList();
        }


    }
}
