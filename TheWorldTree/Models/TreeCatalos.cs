using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 目录
    /// </summary>
    public class TreeCatalos : TreeOperate
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "名称")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "别名")]
        public string Alias { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [MaxLength(50)]
        [Required]
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [MaxLength(50)]
        [Required]
        [Display(Name = "链接")]
        public string Url { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "图标")]
        public string Iconic { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int? Sort { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "说明")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public string Enable { get; set; }

        /// <summary>
        /// 最后一项
        /// </summary>
        [Display(Name = "最后一项")]
        public string IsLast { get; set; }
    }
}
