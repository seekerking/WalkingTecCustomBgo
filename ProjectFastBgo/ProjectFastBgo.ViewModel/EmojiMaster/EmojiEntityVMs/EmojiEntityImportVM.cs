using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.EmojiEntityVMs
{
    public partial class EmojiEntityTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class EmojiEntityImportVM : BaseImportVM<EmojiEntityTemplateVM, EmojiEntity>
    {

    }

}
