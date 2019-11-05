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
    public partial class GroupDicEntityBatchVM : BaseBatchVM<GroupDicEntity, GroupDicEntity_BatchEdit>
    {
        public GroupDicEntityBatchVM()
        {
            ListVM = new GroupDicEntityListVM();
            LinkedVM = new GroupDicEntity_BatchEdit();
        }

        protected override bool CheckIfCanDelete(Guid id, out string errorMessage)
        {
            errorMessage = null;
			return true;
        }
    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class GroupDicEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
