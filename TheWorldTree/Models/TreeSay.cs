using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    public class TreeSay : TreeOperate
    {
        /// <summary>
        /// 说内容
        /// </summary>
        [Display(Name = "说内容")]
        [Required]
        [MaxLength(888)]
        public string SayContent { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        [Display(Name = "点赞数")]
        public int GiveLikeS { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        [Display(Name = "评论数")]
        public int CommentS { get; set; }


    }
}
