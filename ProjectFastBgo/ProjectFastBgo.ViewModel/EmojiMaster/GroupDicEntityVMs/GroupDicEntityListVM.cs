using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using ProjectFastBgo.Model.Enum.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.GroupDicEntityVMs
{
    public partial class GroupDicEntityListVM : BasePagedListVM<GroupDicEntity_View, GroupDicEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("GroupDicEntity", GridActionStandardTypesEnum.Create, "新建","EmojiMaster", dialogWidth: 800),
                this.MakeStandardAction("GroupDicEntity", GridActionStandardTypesEnum.Edit, "修改","EmojiMaster", dialogWidth: 800),
                this.MakeStandardAction("GroupDicEntity", GridActionStandardTypesEnum.Delete, "删除", "EmojiMaster",dialogWidth: 800),
                this.MakeStandardAction("GroupDicEntity", GridActionStandardTypesEnum.Details, "详细","EmojiMaster", dialogWidth: 800)
            };
        }

        protected override IEnumerable<IGridColumn<GroupDicEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<GroupDicEntity_View>>{
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.Type),
                this.MakeGridHeader(x => x.Sort),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<GroupDicEntity_View> GetSearchQuery()
        {
            var query = DC.Set<GroupDicEntity>()
                .WhereIf(Searcher.Type.HasValue,x=>x.Type==Searcher.Type)
                .Select(x => new GroupDicEntity_View
                {
				    ID = x.ID,
                    Title = x.Title,
                    Type = x.Type,
                    Sort = x.Sort,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class GroupDicEntity_View : GroupDicEntity{

    }
}
