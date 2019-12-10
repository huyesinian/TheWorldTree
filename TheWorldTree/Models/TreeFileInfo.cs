using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class TreeFileInfo : TreeFileSuffixType
    {
        /// <summary>
        /// 关联ID
        /// </summary>
        [Display(Name = "关联ID")]
        [MaxLength(50)]
        public string ContentID { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [Display(Name = "文件名称")]
        [MaxLength(100)]
        public string FileName { get; set; }

        /// <summary>
        /// 文件全称
        /// </summary>
        [Display(Name = "文件全称")]
        [MaxLength(100)]
        public string FileFullName { get; set; }

        /// <summary>
        /// 文件长度
        /// </summary>
        [Display(Name = "文件长度")]
        [MaxLength(100)]
        public string FileLength { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [Display(Name = "文件大小")]
        [MaxLength(100)]
        public string FileSize { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [Display(Name = "文件路径")]
        [MaxLength(100)]
        public string FilePath { get; set; }

        /// <summary>
        /// 缩略图路径
        /// </summary>
        [Display(Name = "缩略图路径")]
        [MaxLength(100)]
        public string Thum_file { get; set; }
    }
}
