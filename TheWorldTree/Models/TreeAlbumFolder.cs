using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 相册文件夹
    /// </summary>
    public class TreeAlbumFolder : TreeOperate
    {
        /// <summary>
        /// 文件夹名称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "文件夹名称")]
        [Required]
        public string FlName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [Display(Name = "描述")]
        public string Describe { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Display(Name = "分类")]
        public string Classify { get; set; }

    }
}
