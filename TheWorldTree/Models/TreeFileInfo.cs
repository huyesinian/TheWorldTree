using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class TreeFileInfo : TreeOperate
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
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, 100)]
        public decimal FileLength { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [Display(Name = "文件大小")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, 100)]
        public decimal FileSize { get; set; }

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


        /// <summary>
        /// 文件路径
        /// </summary>
        [Display(Name = "文件路径")]
        public string FilePath { get; set; }

        /// <summary>
        /// 文件相对路径
        /// </summary>
        [Display(Name = "文件相对路径")]
        public string FileRelPath { get; set; }

        /// <summary>
        /// 缩略图路径
        /// </summary>
        [Display(Name = "缩略图路径")]
        public string Thum_file { get; set; }
    }
}
