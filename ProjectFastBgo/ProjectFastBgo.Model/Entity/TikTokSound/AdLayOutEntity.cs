using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AppSys.Framework.Config;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.Model.Entity.TikTokSound
{

    [Table(TablePreConfig.TikTokSoundPre+"AdLayOut")]
    public class AdLayOutEntity:BasePoco
    {
        [Display(Name = "展示位置代码")]
        [StringLength(125, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string AdLayOutKey { get; set; }
        [Display(Name = "展示位置名称")]
        [StringLength(125, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Title { get; set; }

        [Display(Name = "开启状态")]
        public bool OpenState { get; set; }
    }
}
