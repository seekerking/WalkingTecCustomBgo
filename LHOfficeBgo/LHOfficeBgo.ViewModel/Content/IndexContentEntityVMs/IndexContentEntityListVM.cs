using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LHOfficeBgo.Model.Entity;
using LHOfficeBgo.Model.Enum.Content;


namespace LHOfficeBgo.ViewModel.Content.IndexContentEntityVMs
{
    public partial class IndexContentEntityListVM : BasePagedListVM<IndexContentEntity_View, IndexContentEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.Create, "新建","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.Edit, "修改","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.Delete, "删除", "Content",dialogWidth: 800),
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.Details, "详细","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.BatchEdit, "批量修改","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.BatchDelete, "批量删除","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexContentEntity", GridActionStandardTypesEnum.Import, "导入","Content", dialogWidth: 800),
                this.MakeStandardExportAction(null,false,ExportEnum.Excel)
            };
        }

        protected override IEnumerable<IGridColumn<IndexContentEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<IndexContentEntity_View>>{
                this.MakeGridHeader(x=>x.IndexMenuName),
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.FromSource),
                this.MakeGridHeader(x => x.IsTop),
                this.MakeGridHeader(x =>x.Status),
                this.MakeGridHeader(x => x.GoodCount),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<IndexContentEntity_View> GetSearchQuery()
        {
            var query = DC.Set<IndexContentEntity>()
                .Include(x => x.IndexMenus)
                .Select(x => new IndexContentEntity_View
                {
                    ID = x.ID,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    IndexMenuName = x.IndexMenus.Name,
                    FromSource = x.FromSource,
                    IsTop = x.IsTop,
                    Status = x.Status,
                    GoodCount = x.GoodCount,
                })
                .OrderByDescending(x => x.IsTop).ThenByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class IndexContentEntity_View : IndexContentEntity
    {
        [Display(Name = "所属栏目")]
        public string IndexMenuName { get; set; }
    }

}
