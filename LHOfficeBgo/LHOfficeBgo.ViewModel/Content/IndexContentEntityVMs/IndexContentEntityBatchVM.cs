using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexContentEntityVMs
{
    public partial class IndexContentEntityBatchVM : BaseBatchVM<IndexContentEntity, IndexContentEntity_BatchEdit>
    {
        public IndexContentEntityBatchVM()
        {
            ListVM = new IndexContentEntityListVM();
            LinkedVM = new IndexContentEntity_BatchEdit();
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
    public class IndexContentEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
