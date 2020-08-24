using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 订阅表
    /// </summary>
    public class TreeSubscription : TreeOperate
    {
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [Display(Name ="邮箱地址")]
        [MaxLength(50)]
        [Required]
        public string EmailAddress { get; set; }
    }
}
