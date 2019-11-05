using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.AdLayOutEntityVMs
{
    public partial class AdLayOutEntityListVM : BasePagedListVM<AdLayOutEntity_View, AdLayOutEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.Create, "新建","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.Edit, "修改","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.Delete, "删除", "TikTokSound",dialogWidth: 800),
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.Details, "详细","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.BatchEdit, "批量修改","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.BatchDelete, "批量删除","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("AdLayOutEntity", GridActionStandardTypesEnum.Import, "导入","TikTokSound", dialogWidth: 800),
                this.MakeStandardExportAction(null,false,ExportEnum.Excel)
            };
        }

        protected override IEnumerable<IGridColumn<AdLayOutEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<AdLayOutEntity_View>>{
                this.MakeGridHeader(x => x.AdLayOutKey),
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.OpenState),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<AdLayOutEntity_View> GetSearchQuery()
        {
            var query = DC.Set<AdLayOutEntity>()
                .Select(x => new AdLayOutEntity_View
                {
				    ID = x.ID,
                    AdLayOutKey = x.AdLayOutKey,
                    Title = x.Title,
                    OpenState = x.OpenState,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class AdLayOutEntity_View : AdLayOutEntity{

    }
}
