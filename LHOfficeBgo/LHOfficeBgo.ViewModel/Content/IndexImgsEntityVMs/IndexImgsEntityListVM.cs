using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexImgsEntityVMs
{
    public partial class IndexImgsEntityListVM : BasePagedListVM<IndexImgsEntity_View, IndexImgsEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.Create, "新建","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.Edit, "修改","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.Delete, "删除", "Content",dialogWidth: 800),
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.Details, "详细","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.BatchEdit, "批量修改","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.BatchDelete, "批量删除","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexImgsEntity", GridActionStandardTypesEnum.Import, "导入","Content", dialogWidth: 800),
                this.MakeStandardExportAction(null,false,ExportEnum.Excel)
            };
        }

        protected override IEnumerable<IGridColumn<IndexImgsEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<IndexImgsEntity_View>>{
                this.MakeGridHeader(x => x.IndexMenuName),
                this.MakeGridHeader(x => x.IsAuto),
                this.MakeGridHeader(x => x.Speed),
                this.MakeGridColumn(x=>x.CreateTime),
                this.MakeGridColumn(x=>x.CreateBy),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<IndexImgsEntity_View> GetSearchQuery()
        {
            var query = DC.Set<IndexImgsEntity>()
                .Include(x => x.IndexMenus)
                .Select(x => new IndexImgsEntity_View
                {
                    ID = x.ID,
                    IndexMenusId = x.IndexMenusId,
                    IndexMenuName = x.IndexMenus.Name,
                    IsAuto = x.IsAuto,
                    Speed = x.Speed,
                    CreateTime = x.CreateTime,
                    CreateBy = x.CreateBy
                })
                .OrderByDescending(x=>x.CreateTime);
            return query;
        }

    }

    public class IndexImgsEntity_View : IndexImgsEntity
    {
        [Display(Name = "所属栏目")]
        public string IndexMenuName { get; set; }

    }
}
