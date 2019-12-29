using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 新闻类
    /// </summary>
    public class TreePress : TreeOperate
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "标题")]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        [MaxLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        [Display(Name = "正文")]
        [Required]
        public string MainBody { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        [Display(Name = "是否发布")]
        public bool Issue { get; set; }


    }
}
