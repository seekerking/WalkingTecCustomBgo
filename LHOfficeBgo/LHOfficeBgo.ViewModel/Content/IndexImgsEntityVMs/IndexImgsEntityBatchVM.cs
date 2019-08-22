using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexImgsEntityVMs
{
    public partial class IndexImgsEntityBatchVM : BaseBatchVM<IndexImgsEntity, IndexImgsEntity_BatchEdit>
    {
        public IndexImgsEntityBatchVM()
        {
            ListVM = new IndexImgsEntityListVM();
            LinkedVM = new IndexImgsEntity_BatchEdit();
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
    public class IndexImgsEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
