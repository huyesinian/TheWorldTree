using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public  TheWorldTreeDBContext _context;

        public RubbishSel(TheWorldTreeDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取json结果集
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public  string GetJsonList<T>() where T : class
        {
            var SelResult = _context.Set<T>().ToList();
            TreeJsonTable jsonTable = new TreeJsonTable()
            {
                StateCode =0,
                Msg="",
                Count= SelResult.Count(),
                Data= SelResult
            };
            string output = JsonConvert.SerializeObject(jsonTable);
            return output;
        }

     
    }
}
