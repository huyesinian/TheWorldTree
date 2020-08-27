using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    public class TreeFrontAlbum
    {
        /// <summary>
        /// 图片文件夹类
        /// </summary>
        public TreeAlbumFolder TreeAlbumFolders { get; set; }

        /// <summary>
        /// 图片集合
        /// </summary>
        public List<TreeFileInfo> TreeFileInfos { get; set; }
    }
}
