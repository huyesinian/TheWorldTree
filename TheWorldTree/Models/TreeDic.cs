using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.Models
{
    /// <summary>
    /// 字典表
    /// </summary>
    public class TreeDic : TreeOperate
    {
        /// <summary>
        /// 字典编码
        /// </summary>
        [Required]
        [Display(Name = "字典编码")]
        public string DicCode { get; set; }
        /// <summary>
        /// 字典名
        /// </summary>
        [Required]
        [Display(Name = "字典名")]
        public string NodeName { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        [Required]
        [Display(Name = "字典值")]
        public string NodeCode { get; set; }
        /// <summary>
        /// 附属名1
        /// </summary>
        [Display(Name = "附属名1")]
        public string Node1 { get; set; }
        /// <summary>
        /// 附属名2
        /// </summary>
        [Display(Name = "附属名2")]
        public string Node2 { get; set; }
        /// <summary>
        /// 附属名3
        /// </summary>
        [Display(Name = "附属名3")]
        public string Node3 { get; set; }
        /// <summary>
        /// 附属名4
        /// </summary>
        [Display(Name = "附属名4")] 
        public string Node4 { get; set; }
        /// <summary>
        /// 附属名5
        /// </summary>
        [Display(Name = "附属名5")] 
        public string Node5 { get; set; }
        /// <summary>
        /// 附属名6
        /// </summary>
        [Display(Name = "附属名6")]
        public string Node6 { get; set; }
        /// <summary>
        /// 附属名7
        /// </summary>
        [Display(Name = "附属名7")]
        public string Node7 { get; set; }
        /// <summary>
        /// 附属名8
        /// </summary>
        [Display(Name = "附属名8")] 
        public string Node8 { get; set; }
        /// <summary>
        /// 附属值1
        /// </summary>
        [Display(Name = "附属值1")]
        public string Node1Code { get; set; }
        /// <summary>
        /// 附属值2
        /// </summary>
        [Display(Name = "附属值2")] 
        public string Node2Code { get; set; }
        /// <summary>
        /// 附属值3
        /// </summary>
        [Display(Name = "附属值3")] 
        public string Node3Code { get; set; }
        /// <summary>
        /// 附属值4
        /// </summary>
        [Display(Name = "附属值4")] 
        public string Node4Code { get; set; }
        /// <summary>
        /// 附属值5
        /// </summary>
        [Display(Name = "附属值5")] 
        public string Node5Code { get; set; }
        /// <summary>
        /// 附属值6
        /// </summary>
        [Display(Name = "附属值6")] 
        public string Node6Code { get; set; }
        /// <summary>
        /// 附属值7
        /// </summary>
        [Display(Name = "附属值7")] 
        public string Node7Code { get; set; }
        /// <summary>
        /// 附属值8
        /// </summary>
        [Display(Name = "附属值8")] 
        public string Node8Code { get; set; }
    }
}
