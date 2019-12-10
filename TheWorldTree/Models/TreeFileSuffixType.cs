using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 文件后缀类型
    /// </summary>
    public class TreeFileSuffixType: TreeOperate
    {
        /// <summary>
        /// 后缀类型
        /// </summary>
        [MaxLength(50)]
        [Required]
        [Display(Name = "后缀类型")]
        public string Expanded_name { get; set; }

        /// <summary>
        /// 导出文本格式
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Display(Name = "导出文本格式")]
        public string Content_Type { get; set; }

    }
}
