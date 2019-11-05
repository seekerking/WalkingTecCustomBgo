using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectFastBgo.Model.Dto.TikTokSound
{
   public class UserBasicSettingDto
    {
        

        [Display(Name = "每日免费次数")]
        public int UserFreeUseCount { get; set; }

        [Display(Name = "每日看视屏次数")]
        public int WatchVideoUseCount { get; set; }
    }
}
