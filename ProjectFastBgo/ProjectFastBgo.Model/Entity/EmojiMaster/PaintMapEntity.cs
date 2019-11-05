using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AppSys.Framework.Config;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.Model.Entity.EmojiMaster
{
    [Table(TablePreConfig.EmojiMasterPre + "PaintMaps")]
    public class PaintMapEntity:BasePoco
    {
        [Display(Name = "所属分组")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid GroupId { get; set; }


        [Display(Name = "表情图")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Img { get; set; }
        [Display(Name = "表情序号")]
        public int Sort { get; set; }


        [ForeignKey("GroupId")]
        public virtual GroupDicEntity GroupDicEntity { get; set; }
    }
}
