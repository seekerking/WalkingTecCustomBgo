using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Sys.ManageConfigEntityVMs
{
    public partial class ManageConfigEntityListVM : BasePagedListVM<ManageConfigEntity_View, ManageConfigEntitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.Create, "新建","Sys", dialogWidth: 800),
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.Edit, "修改","Sys", dialogWidth: 800),
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.Delete, "删除", "Sys",dialogWidth: 800),
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.Details, "详细","Sys", dialogWidth: 800),
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.BatchEdit, "批量修改","Sys", dialogWidth: 800),
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.BatchDelete, "批量删除","Sys", dialogWidth: 800),
                this.MakeStandardAction("ManageConfigEntity", GridActionStandardTypesEnum.Import, "导入","Sys", dialogWidth: 800),
                this.MakeStandardExportAction(null,false,ExportEnum.Excel)
            };
        }

        protected override IEnumerable<IGridColumn<ManageConfigEntity_View>> InitGridHeader()
        {
            return new List<GridColumn<ManageConfigEntity_View>>{
                this.MakeGridHeader(x => x.DataKey),
                this.MakeGridHeader(x => x.IosDownLoadUrl),
                this.MakeGridHeader(x => x.AndroidDownLoadUrl),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ManageConfigEntity_View> GetSearchQuery()
        {
            var query = DC.Set<ManageConfigEntity>()
                .Select(x => new ManageConfigEntity_View
                {
				    ID = x.ID,
                    DataKey = x.DataKey,
                    IosDownLoadUrl = x.IosDownLoadUrl,
                    AndroidDownLoadUrl = x.AndroidDownLoadUrl,
                    QrCodeUrl = x.QrCodeUrl,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ManageConfigEntity_View : ManageConfigEntity{

    }
}
