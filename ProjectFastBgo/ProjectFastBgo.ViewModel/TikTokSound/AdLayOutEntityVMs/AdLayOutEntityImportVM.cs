using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.AdLayOutEntityVMs
{
    public partial class AdLayOutEntityTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class AdLayOutEntityImportVM : BaseImportVM<AdLayOutEntityTemplateVM, AdLayOutEntity>
    {

    }

}
