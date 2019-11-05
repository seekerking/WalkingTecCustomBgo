using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.SysSettingEntityVMs
{
    public partial class SysSettingEntityTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class SysSettingEntityImportVM : BaseImportVM<SysSettingEntityTemplateVM, SysSettingEntity>
    {

    }

}
