using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// table json格式
    /// </summary>
    public class TreeJsonTable
    {
        /// <summary>
        /// 这是状态码
        /// </summary>
        public int StateCode { get; set; }

        /// <summary>
        /// 这是异常信息
        /// </summary>
        public string Msg { get; set; }


        /// <summary>
        /// 这是数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 这是数据集
        /// </summary>
        public object Data { get; set; }
    }


   
}
