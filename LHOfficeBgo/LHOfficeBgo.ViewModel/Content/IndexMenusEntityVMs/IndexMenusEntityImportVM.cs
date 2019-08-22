using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexMenusEntityVMs
{
    public partial class IndexMenusEntityTemplateVM : BaseTemplateVM
    {
        public ExcelPropety ParentId_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.ParentId);
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.Name);
        public ExcelPropety Url_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.Url);
        public ExcelPropety SortOrder_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.SortOrder);
        public ExcelPropety DefaultImg_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.DefaultImg);
        public ExcelPropety HoverImg_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.HoverImg);
        public ExcelPropety IsShow_Excel = ExcelPropety.CreateProperty<IndexMenusEntity>(x => x.IsShow);

	    protected override void InitVM()
        {
        }

    }

    public class IndexMenusEntityImportVM : BaseImportVM<IndexMenusEntityTemplateVM, IndexMenusEntity>
    {

    }

}
