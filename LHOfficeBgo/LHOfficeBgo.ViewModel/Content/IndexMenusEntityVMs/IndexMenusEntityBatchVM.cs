using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexMenusEntityVMs
{
    public partial class IndexMenusEntityBatchVM : BaseBatchVM<IndexMenusEntity, IndexMenusEntity_BatchEdit>
    {
        public IndexMenusEntityBatchVM()
        {
            ListVM = new IndexMenusEntityListVM();
            LinkedVM = new IndexMenusEntity_BatchEdit();
        }

        protected override bool CheckIfCanDelete(Guid id, out string errorMessage)
        {
            errorMessage = null;
			return true;
        }
        public bool HaveChildMenu(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return false;
            }
            return DC.Set<IndexMenusEntity>().Any(x => ids.Contains(x.ParentId.Value));
        }
        public bool HaveContents(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return false;
            }
            return DC.Set<IndexContentEntity>().Any(x => ids.Contains(x.IndexMenusId));
        }
        public bool HaveImages(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return false;
            }
            return DC.Set<IndexImgsEntity>().Any(x => ids.Contains(x.IndexMenusId));
        }
    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class IndexMenusEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
