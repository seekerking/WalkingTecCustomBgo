using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexContentEntityVMs
{
    public partial class IndexContentEntityTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.Title);
        public ExcelPropety SubTitle_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.SubTitle);
        public ExcelPropety FromSource_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.FromSource);
        public ExcelPropety MenuId_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.IndexMenusId);
        public ExcelPropety IsTop_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.IsTop);
        public ExcelPropety Status_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.Status);
        public ExcelPropety Text_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.Text);
        public ExcelPropety GoodCount_Excel = ExcelPropety.CreateProperty<IndexContentEntity>(x => x.GoodCount);

	    protected override void InitVM()
        {
        }

    }

    public class IndexContentEntityImportVM : BaseImportVM<IndexContentEntityTemplateVM, IndexContentEntity>
    {

    }

}
