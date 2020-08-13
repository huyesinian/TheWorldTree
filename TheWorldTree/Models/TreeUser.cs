using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class TreeUser : TreeOperate
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户真名
        /// </summary>
        [Required]
        [Display(Name = "用户真名")]
        public string TrueName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        public string PassWord { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        [Display(Name = "性别")]
        public string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Required]
        [Display(Name = "生日")]
        public string Birthday { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Display(Name = "角色id")]
        public string RoleId { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public string State { get; set; }
    }
}
