using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LHOfficeBgo.Model.Enum.Content;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WalkingTec.Mvvm.Core;

namespace LHOfficeBgo.Model.Entity
{
    public class IndexContentEntity : BasePoco
    {
        [Display(Name = "标题")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Title { get; set; }
        [Display(Name = "子标题")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string SubTitle { get; set; }
        [Display(Name = "数据来源")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FromSource { get; set; }
        [Display(Name = "内容栏目")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid IndexMenusId { get; set; }
        [Display(Name = "置顶")]
        public bool IsTop { get; set; }
        [Display(Name = "状态")]
        public IndexContentStatusEnum Status { get; set; }
        [Display(Name = "内容")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Text { get; set; }
        [Display(Name = "点赞数")]
        public int GoodCount { get; set; }
        [Display(Name = "是否隐藏")]
        public bool GoodCountStatus { get; set; }

        [ForeignKey("IndexMenusId")]
        public virtual  IndexMenusEntity IndexMenus { get; set; }
    }
}
