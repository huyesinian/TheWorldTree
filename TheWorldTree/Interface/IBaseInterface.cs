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
    }
}
