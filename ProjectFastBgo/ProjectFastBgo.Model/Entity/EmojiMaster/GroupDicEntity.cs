using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AppSys.Framework.Config;
using ProjectFastBgo.Model.Enum.EmojiMaster;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.Model.Entity.EmojiMaster
{
    [Table(TablePreConfig.EmojiMasterPre + "GroupDic")]
    public class GroupDicEntity : BasePoco
    {
        [Display(Name = "分组名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Title { get; set; }
        [Display(Name = "分组类型")]
        public GroupTypeEnum Type { get; set; }
        [Display(Name = "分组序号")]
        public int Sort { get; set; }
    }
}
