using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 操作基本信息
    /// </summary>
    public class TreeOperate : TreeBase
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "创建人")]
        public string Creater { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        public string UpdateOne { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
    }
}
