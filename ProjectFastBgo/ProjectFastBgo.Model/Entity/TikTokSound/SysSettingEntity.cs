using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AppSys.Framework.Config;
using AppSys.Utility;
using ProjectFastBgo.Model.Dto.TikTokSound;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.Model.Entity.TikTokSound
{
    [Table(TablePreConfig.TikTokSoundPre + "SysSettings")]
    public class SysSettingEntity:BasePoco
    {
        public string SysKey { get; set; }
        public string Config { get; set; }
        public UserBasicSettingDto UserSettingDto
        {
            get
            {
                UserBasicSettingDto config = null;

                try
                {
                    if (!Config.IsNullOrEmpty())
                    {
                        config = Config.JSONDeserialize<UserBasicSettingDto>();
                    }
                    else
                    {
                        config = new UserBasicSettingDto();
                    }
                }
                catch (Exception e)
                {
                    config = new UserBasicSettingDto();
                }

                return config;
            }
        }


    }
}
