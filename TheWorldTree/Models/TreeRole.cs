using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class TreeRole : TreeOperate
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Required]
        [Display(Name = "角色")]
        public string Role { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        [Display(Name = "描述")]
        public string Discription { get; set; }
    }
}
