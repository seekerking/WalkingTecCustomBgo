using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Sys.ManageConfigEntityVMs
{
    public partial class ManageConfigEntityBatchVM : BaseBatchVM<ManageConfigEntity, ManageConfigEntity_BatchEdit>
    {
        public ManageConfigEntityBatchVM()
        {
            ListVM = new ManageConfigEntityListVM();
            LinkedVM = new ManageConfigEntity_BatchEdit();
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
    public class ManageConfigEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
