using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AppSys.Framework.Config;
using AppSys.Utility.JsonExtension;
using Newtonsoft.Json;
using ProjectFastBgo.Model.Enum.TikTokSound;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.Model.Entity.TikTokSound
{
    [Table(TablePreConfig.TikTokSoundPre + "TopHotSongs")]
    public class TopHotSoundEntity : BasePoco
    {
        [Display(Name = "歌曲栏目")]
        [Required(ErrorMessage = "{0}是必填项")]
        public MenuTypeEnum MenuType { get; set; }
        [Display(Name = "图片")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Img { get; set; }
        [Display(Name = "歌曲名")]
        [StringLength(125, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Title { get; set; }
        [Display(Name = "歌手名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Singer { get; set; }
        [Display(Name = "歌曲顺序")]
        public int Sort { get; set; }

        [Display(Name = "生效日期")]
        [Required(ErrorMessage = "{0}是必填项")]
        [JsonConverter(typeof(JsonShortDotDateConverter))]
        public DateTime StartDate { get; set; }
        [Display(Name = "失效日期")]
        [Required(ErrorMessage = "{0}是必填项")]
        [JsonConverter(typeof(JsonShortDotDateConverter))]
        public DateTime EndDate { get; set; }

    }
}
