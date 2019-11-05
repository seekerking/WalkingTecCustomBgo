using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.GroupDicEntityVMs
{
    public partial class GroupDicEntityTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class GroupDicEntityImportVM : BaseImportVM<GroupDicEntityTemplateVM, GroupDicEntity>
    {

    }

}
