using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjectFastBgo.Model.Entity.TikTokSound;
using ProjectFastBgo.Model.Enum.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.TopHotSoundEntityVMs
{
    public partial class TopHotSoundEntityListVM : BasePagedListVM<TopHotSoundEntity_View, TopHotSoundEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("TopHotSoundEntity", GridActionStandardTypesEnum.Create, "新建","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("TopHotSoundEntity", GridActionStandardTypesEnum.Edit, "修改","TikTokSound", dialogWidth: 800),
                this.MakeStandardAction("TopHotSoundEntity", GridActionStandardTypesEnum.Delete, "删除", "TikTokSound",dialogWidth: 800),
                this.MakeStandardAction("TopHotSoundEntity", GridActionStandardTypesEnum.Details, "详细","TikTokSound", dialogWidth: 800),
            };
        }

        protected override IEnumerable<IGridColumn<TopHotSoundEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<TopHotSoundEntity_View>>{
                this.MakeGridHeader(x => x.MenuType),
                this.MakeGridHeader(x => x.Img),
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.Singer),
                this.MakeGridHeader(x => x.Sort),
                this.MakeGridHeader(x=>x.StartDate).SetFormat((entity,v)=> { return ((DateTime)v).ToString("yyyy-MM-dd"); }),
                this.MakeGridHeader(x=>x.EndDate).SetFormat((entity,v)=> {return ((DateTime)v).ToString("yyyy-MM-dd"); }),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TopHotSoundEntity_View> GetSearchQuery()
        {
            var query = DC.Set<TopHotSoundEntity>()
                .WhereIf(Searcher.MenuType.HasValue,x=>x.MenuType==Searcher.MenuType)
                .Select(x => new TopHotSoundEntity_View
                {
				    ID = x.ID,
                    MenuType = x.MenuType,
                    Img = x.Img,
                    Title = x.Title,
                    Singer = x.Singer,
                    Sort = x.Sort,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                })
                .OrderBy(x => x.Sort).ThenByDescending(x=>x.UpdateTime);
            return query;
        }

    }

    public class TopHotSoundEntity_View : TopHotSoundEntity{

    }
}
