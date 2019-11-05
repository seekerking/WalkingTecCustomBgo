using AppSys.Framework.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.Model.Entity.TikTokSound
{
    [Table(TablePreConfig.TikTokSoundPre + "PushTasks")]
    public class PushTasksEntity : BasePoco
    {
        [Display(Name = "客户端")]
        public CidEnum Cid { get; set; } = CidEnum.all;
        [Display(Name = "版本 多个,号连接")]
        public string Av { get; set; } = string.Empty;

        [Display(Name = "标题")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string TaskTitle { get; set; } = string.Empty;

        [Display(Name = "内容")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string TaskBody { get; set; } = string.Empty;

        [Display(Name = "推送时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime TaskFireTime { get; set; } 

        [Display(Name = "跳转类型")] 
        public string TaskJumpType { get; set; } = string.Empty;

        [Display(Name = "跳转地址")]
        public string Url { get; set; } = string.Empty;

        [Display(Name = "状态")]
        public StateEnum TaskState { get; set; } = StateEnum.UnExe;
        
    }

    public enum CidEnum
    {
        [Display(Name = "all")]
        all = 0,
        [Display(Name = "android")]
        android = 1,
        [Display(Name = "ios")]
        ios = 2,
    }

    public enum StateEnum
    {
        [Display(Name = "未执行")]
        UnExe = 0,
        [Display(Name = "完成")]
        Complete = 1, 
    }
    
}
