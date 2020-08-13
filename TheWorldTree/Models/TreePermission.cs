using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 权限
    /// </summary>
    public class TreePermission : TreeOperate
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Required]
        [Display(Name = "角色Id")]
        public string RoleId { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        [Required]
        [Display(Name = "模块Id")]
        public string ModleId { get; set; }
    }
}
