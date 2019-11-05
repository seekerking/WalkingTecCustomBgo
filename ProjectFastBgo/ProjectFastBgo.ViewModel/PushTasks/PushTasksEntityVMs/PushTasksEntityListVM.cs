using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.PushTasks.PushTasksEntityVMs
{
    public partial class PushTasksEntityListVM : BasePagedListVM<PushTasksEntity_View, PushTasksEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.Create, "新建","PushTasks", dialogWidth: 800),
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.Edit, "修改","PushTasks", dialogWidth: 800),
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.Delete, "删除", "PushTasks",dialogWidth: 800),
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.Details, "详细","PushTasks", dialogWidth: 800),
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.BatchEdit, "批量修改","PushTasks", dialogWidth: 800),
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.BatchDelete, "批量删除","PushTasks", dialogWidth: 800),
                this.MakeStandardAction("PushTasksEntity", GridActionStandardTypesEnum.Import, "导入","PushTasks", dialogWidth: 800),
                this.MakeStandardExportAction(null,false,ExportEnum.Excel)
            };
        }

        protected override IEnumerable<IGridColumn<PushTasksEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<PushTasksEntity_View>>{
                this.MakeGridHeader(x => x.Cid),
                this.MakeGridHeader(x => x.Av),
                this.MakeGridHeader(x => x.TaskTitle),
                this.MakeGridHeader(x => x.TaskBody),
                this.MakeGridHeader(x => x.TaskFireTime),
                this.MakeGridHeader(x => x.TaskJumpType),
                this.MakeGridHeader(x => x.Url),
                this.MakeGridHeader(x => x.TaskState),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PushTasksEntity_View> GetSearchQuery()
        {
            var query = DC.Set<PushTasksEntity>()
                .CheckEqual(Searcher.Cid, x=>x.Cid)
                .CheckContain(Searcher.TaskTitle, x=>x.TaskTitle)
                .CheckEqual(Searcher.TaskState, x=>x.TaskState)
                .Select(x => new PushTasksEntity_View
                {
				    ID = x.ID,
                    Cid = x.Cid,
                    Av = x.Av,
                    TaskTitle = x.TaskTitle,
                    TaskBody = x.TaskBody,
                    TaskFireTime = x.TaskFireTime,
                    TaskJumpType = x.TaskJumpType,
                    Url = x.Url,
                    TaskState = x.TaskState,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PushTasksEntity_View : PushTasksEntity{

    }
}
