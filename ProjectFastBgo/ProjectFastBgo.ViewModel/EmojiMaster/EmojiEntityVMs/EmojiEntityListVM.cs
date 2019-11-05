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


namespace ProjectFastBgo.ViewModel.EmojiMaster.EmojiEntityVMs
{
    public partial class EmojiEntityListVM : BasePagedListVM<EmojiEntity_View, EmojiEntitySearcher>
    {
        public List<ComboSelectListItem> AllGroupDicEntitys { get; set; }
        public List<ComboSelectListItem> GetAllGroupDic()
        {

            AllGroupDicEntitys = DC.Set<GroupDicEntity>()
                .Where(x => x.Type == GroupTypeEnum.表情包)
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
            AllGroupDicEntitys = DC.Set<GroupDicEntity>()
                .Where(x => x.Type == GroupTypeEnum.表情包)
                .OrderBy(x => x.Sort)
                .Select(x => new ComboSelectListItem()
                {
                    Text = x.Title,
                    Value = x.ID.ToString("D")

                }).ToList();


            return new List<GridAction>
            {
                this.MakeStandardAction("EmojiEntity", GridActionStandardTypesEnum.Create, "新建","EmojiMaster", dialogWidth: 800),
                this.MakeStandardAction("EmojiEntity", GridActionStandardTypesEnum.Edit, "修改","EmojiMaster", dialogWidth: 800),
                this.MakeStandardAction("EmojiEntity", GridActionStandardTypesEnum.Delete, "删除", "EmojiMaster",dialogWidth: 800),
                this.MakeStandardAction("EmojiEntity", GridActionStandardTypesEnum.Details, "详细","EmojiMaster", dialogWidth: 800),
           
            };
        }

        protected override IEnumerable<IGridColumn<EmojiEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<EmojiEntity_View>>{
                this.MakeGridHeader(x => x.Img),
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.Sort),
                this.MakeGridHeader(x => x.GroupDicEntity.Title),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EmojiEntity_View> GetSearchQuery()
        {
            var query = DC.Set<EmojiEntity>()
                .WhereIf(Searcher.GroupId.HasValue,x=>x.GroupId==Searcher.GroupId)
           .Join(DC.Set<GroupDicEntity>(), x => x.GroupId, y => y.ID, (x, y) => new EmojiEntity_View
           {
               ID = x.ID,
               Img = x.Img,
               Title = x.Title,
               GroupId = x.GroupId,
               GroupDicEntity = y,
               Sort = x.Sort

           }) .OrderBy(x => x.Sort);
            return query;
        }

    }

    public class EmojiEntity_View : EmojiEntity{

    }
}
