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
    public partial class SysSettingEntityBatchVM : BaseBatchVM<SysSettingEntity, SysSettingEntity_BatchEdit>
    {
        public SysSettingEntityBatchVM()
        {
            ListVM = new SysSettingEntityListVM();
            LinkedVM = new SysSettingEntity_BatchEdit();
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
    public class SysSettingEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
