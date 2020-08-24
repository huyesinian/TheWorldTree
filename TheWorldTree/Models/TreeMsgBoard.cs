using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 留言板
    /// </summary>
    public class TreeMsgBoard : TreeOperate
    {
        /// <summary>
        /// 关联ID
        /// </summary>
        [Display(Name = "关联ID")]
        public string ContentId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string UserIP { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "留言内容")] 
        public string MsgContent { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(11)]
        [Display(Name = "手机号码")] 
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "邮箱")] 
        public string Email { get; set; }


    }
}
