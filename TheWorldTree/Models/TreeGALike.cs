using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 点赞
    /// </summary>
    public class TreeGALike: TreeOperate
    {
        /// <summary>
        /// 关联ID
        /// </summary>
        [Display(Name = "关联ID")]
        [MaxLength(50)]
        public string ContentID { get; set; }

        /// <summary>
        /// 点赞人
        /// </summary>
        [Display(Name = "点赞人")]
        [MaxLength(50)]
        public string LikeMan { get; set; }

        /// <summary>
        /// 使用的模块
        /// </summary>
        [Display(Name = "使用的模块")]
        [MaxLength(50)]
        public string UseModule { get; set; }
    }
}
