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


namespace ProjectFastBgo.ViewModel.EmojiMaster.PaintMapEntityVMs
{
    public partial class PaintMapEntityListVM : BasePagedListVM<PaintMapEntity_View, PaintMapEntitySearcher>
    {
        public List<ComboSelectListItem> AllGroupDicEntitys { get; set; }

        public List<ComboSelectListItem> GetAllGroupDic()
        {

            AllGroupDicEntitys = DC.Set<GroupDicEntity>()
                .Where(x => x.Type == GroupTypeEnum.贴图)
                .OrderBy(x => x.Sort)
                .Select(x => new ComboSelectListItem()
                {
                    Text = x.Title,
                    Value = x.ID.ToString("D")

                }).ToList();
            return AllGroupDicEntitys;
        }
        protected override List<GridAction> InitGridAction()
        {
            ;
            return new List<GridAction>
            {
                this.MakeStandardAction("PaintMapEntity", GridActionStandardTypesEnum.Create, "新建","EmojiMaster", dialogWidth: 800),
                this.MakeStandardAction("PaintMapEntity", GridActionStandardTypesEnum.Edit, "修改","EmojiMaster", dialogWidth: 800),
                this.MakeStandardAction("PaintMapEntity", GridActionStandardTypesEnum.Delete, "删除", "EmojiMaster",dialogWidth: 800),
                this.MakeStandardAction("PaintMapEntity", GridActionStandardTypesEnum.Details, "详细","EmojiMaster", dialogWidth: 800)
            };
        }

        protected override IEnumerable<IGridColumn<PaintMapEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<PaintMapEntity_View>>{
                this.MakeGridHeader(x => x.Img),
                this.MakeGridHeader(x => x.Sort),
                this.MakeGridHeader(x => x.GroupDicEntity.Title),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PaintMapEntity_View> GetSearchQuery()
        {
            var query = DC.Set<PaintMapEntity>()
                .WhereIf(Searcher.GroupId.HasValue, x => x.GroupId == Searcher.GroupId)
                .Join(DC.Set<GroupDicEntity>(), x => x.GroupId, y => y.ID, (x, y) => new PaintMapEntity_View
                {
                    ID = x.ID,
                    Img = x.Img,
                    GroupDicEntity = y,
                    Sort = x.Sort

                })
                .OrderBy(x => x.Sort);
            return query;
        }

    }

    public class PaintMapEntity_View : PaintMapEntity
    {


    }
}
