using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.EXMethod
{
    /// <summary>
    /// 关于附件信息的扩展方法
    /// </summary>
    public class TreeFileInfoEX
    {
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;

        public TreeFileInfoEX(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
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
            var SelResult = Rubbish.GetList<TreeFileInfo>();//获取集合
            var Sum = SelResult.Count();//获取总数量
            if (searchInfo != null)
            {
                SelResult = SelResult.Where(x => x.ID.Contains(searchInfo) || x.ContentID.Contains(searchInfo)).ToList();
            }
            SelResult = Rubbish.GetPagingList(p, l, SelResult);
            string output = Rubbish.GetJsonResult(Sum, SelResult);
            return output;
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
                    if (value == null)//如果是主键，则跳过修改属性
                    {
                        _context.Entry(s).Property(prop.Name).IsModified = true;
                    }

                }
            }
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
    }
}
