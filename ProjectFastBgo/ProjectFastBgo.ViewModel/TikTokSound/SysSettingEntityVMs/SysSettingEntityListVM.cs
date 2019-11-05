using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using AppSys.Utility;
using ProjectFastBgo.Model.Dto.TikTokSound;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.SysSettingEntityVMs
{
    public partial class SysSettingEntityListVM : BasePagedListVM<SysSettingEntity_View, SysSettingEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SysSettingEntity", GridActionStandardTypesEnum.Edit, "修改","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("SysSettingEntity", GridActionStandardTypesEnum.Details, "详细","TikTokSound", dialogWidth: 800)
            };
        }

        protected override IEnumerable<IGridColumn<SysSettingEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<SysSettingEntity_View>>{
                this.MakeGridHeader(x => x.UserSettingDto.UserFreeUseCount),
                this.MakeGridHeader(x => x.UserSettingDto.WatchVideoUseCount),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SysSettingEntity_View> GetSearchQuery()
        {
            var query = DC.Set<SysSettingEntity>()
                .Select(x => new SysSettingEntity_View
                {
				    ID = x.ID,
                    SysKey = x.SysKey,
                    Config = x.Config,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SysSettingEntity_View : SysSettingEntity
    {

    }
}
