using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexMenusEntityVMs
{
    public partial class IndexMenusEntityListVM : BasePagedListVM<IndexMenusEntity_View, IndexMenusEntitySearcher>
    {
        public Guid? ParentId { get; set; }


        protected override List<GridAction> InitGridAction()
        {
            var queryString = ParentId.HasValue ? "parentId=" + ParentId.Value : "";
            return new List<GridAction>
            {
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.Create, "新建","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.Index, "下级目录","Content",name:"下级目录",queryString:queryString),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.Edit, "修改","Content", dialogHeight:800,queryString:queryString),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.Delete, "删除", "Content",dialogWidth: 800),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.Details, "详细","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.BatchEdit, "批量修改","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.BatchDelete, "批量删除","Content", dialogWidth: 800),
                this.MakeStandardAction("IndexMenusEntity", GridActionStandardTypesEnum.Import, "导入","Content", dialogWidth: 800),
                this.MakeStandardExportAction(null,false,ExportEnum.Excel)
            };
        }

        protected override IEnumerable<IGridColumn<IndexMenusEntity_View>> InitGridHeader()
        {
            var list = new List<GridColumn<IndexMenusEntity_View>>
            {
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.SortOrder),
                this.MakeGridHeader(x => x.IsShow),
                this.MakeGridHeader(x => x.CreateBy),
                this.MakeGridHeaderAction(width: 300)
            };
            if (!ParentId.HasValue)
            {
                list.Add(this.MakeGridHeader(x => x.HoverImg));
                list.Add(this.MakeGridHeader(x => x.DefaultImg));
                list.Add(this.MakeGridHeader(x => x.Url));
            }
            return list;
        }

        public override IOrderedQueryable<IndexMenusEntity_View> GetSearchQuery()
        {
            var query = DC.Set<IndexMenusEntity>()
                .Select(x => new IndexMenusEntity_View
                {
				    ID = x.ID,
                    ParentId = x.ParentId,
                    Name = x.Name,
                    Url = x.Url,
                    SortOrder = x.SortOrder,
                    DefaultImg = x.DefaultImg,
                    HoverImg = x.HoverImg,
                    IsShow = x.IsShow,
                    CreateBy = x.CreateBy
                }).Where(x=>x.ParentId==ParentId)
                .OrderBy(x=>x.SortOrder).ThenByDescending(x=>x.CreateTime);
            return query;
        }

    }

    public class IndexMenusEntity_View : IndexMenusEntity{

    }
}
