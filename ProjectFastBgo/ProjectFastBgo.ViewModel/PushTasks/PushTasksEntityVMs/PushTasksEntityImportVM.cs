using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.PushTasks.PushTasksEntityVMs
{
    public partial class PushTasksEntityTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class PushTasksEntityImportVM : BaseImportVM<PushTasksEntityTemplateVM, PushTasksEntity>
    {

    }

}
