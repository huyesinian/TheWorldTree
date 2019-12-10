using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 基本信息
    /// </summary>
    public class TreeBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "ID")]
        [Key]
        public string ID { get; set; }

        
    }
}
