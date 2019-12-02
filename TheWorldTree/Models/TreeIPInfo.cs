using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 访问用户统计
    /// </summary>
    public class TreeIPInfo: TreeBase
    {
        public string IPAdd { get; set; }

        public DateTime IPAccessTime { get; set; }
    }
}
