﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.AdLayOutEntityVMs
{
    public partial class AdLayOutEntityBatchVM : BaseBatchVM<AdLayOutEntity, AdLayOutEntity_BatchEdit>
    {
        public AdLayOutEntityBatchVM()
        {
            ListVM = new AdLayOutEntityListVM();
            LinkedVM = new AdLayOutEntity_BatchEdit();
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
    public class AdLayOutEntity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
