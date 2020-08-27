using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 前端说说
    /// </summary>
    public class TreeFrontSay
    {
        /// <summary>
        /// 说说集合
        /// </summary>
        public TreeSay TreeSays { get; set; }

        /// <summary>
        /// 图片集合
        /// </summary>
        public List<TreeFileInfo> TreeFileInfos { get; set; }

        
        /// <summary>
        /// 评论集合
        /// </summary>
        public List<TreeMsgBoard> TreeMsgBoards { get; set; }

        /// <summary>
        /// 点赞集合
        /// </summary>
        public List<TreeGALike>  TreeGALikes { get; set; }


    }
}
