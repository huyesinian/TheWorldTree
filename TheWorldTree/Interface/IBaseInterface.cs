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
        /// 获取结果集
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="s">参数</param>
        /// <returns></returns>
        public string GetJsonList<T>() where T : class;


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

    }
}
