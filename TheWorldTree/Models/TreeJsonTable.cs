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

    /// <summary>
    /// 这是富文本框中的上传文件
    /// </summary>
    public class JsonImg
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// 真是图上上传之后需要返回的信息
    /// </summary>
    public class ImgInfo
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string src { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
    }



}
