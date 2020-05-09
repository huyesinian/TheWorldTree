using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack;

namespace TheWorldTree.Interface
{
    /// <summary>
    /// 基础接口
    /// </summary>
    public interface IBaseInterface
    {
        /// <summary>
        /// 获取带分页的结果集
        /// </summary>
        /// <typeparam name="T">实体参数</typeparam>
        /// <param name="p">页数</param>
        /// <param name="l">每页数据条数</param>
        /// <param name="searchInfo">查询条件</param>
        /// <returns></returns>
        public string GetJsonList<T>(int p, int l,string searchInfo ) where T : class;

        /// <summary>
        /// 创建
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="s">实体参数</param>
        /// <returns></returns>
        public int Create<T>(T s) where T : class;

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="s">实体参数</param>
        /// <returns></returns>
        public int Edit<T>(T s) where T : class;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Delete<T>(T s);

        /// <summary>
        /// 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class;


        /// <summary>
        /// 分页之后的集合
        /// </summary>
        /// <typeparam name="T">实体参数</typeparam>
        /// <typeparam name="page">页数</typeparam>
        /// <typeparam name="limit">每页数据条数</typeparam>
        /// <returns>分页之后的集合</returns>
        public List<T> GetPagingList<T>(int page, int limit,List<T> ts);


        /// <summary>
        /// 返回Json结果字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="totalNum">总数量</param>
        /// <param name="ts">结果集</param>
        /// <returns>Json结果字符串</returns>
        public string GetJsonResult<T>(int totalNum, List<T> ts);


    }
}
