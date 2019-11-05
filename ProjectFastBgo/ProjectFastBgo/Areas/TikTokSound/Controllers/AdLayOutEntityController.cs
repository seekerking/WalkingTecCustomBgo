using System;
using Microsoft.AspNetCore.Mvc;
using ProjectFastBgo.ViewModel.TikTokSound.AdLayOutEntityVMs;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace ProjectFastBgo.Areas.TikTokSound.Controllers
{
    [Area("TikTokSound")]
    [ActionDescription("歌曲识别广告位置管理")]
    public partial class AdLayOutEntityController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<AdLayOutEntityListVM>();
            return PartialView(vm);
        }
        #endregion

        #region 修改
        [ActionDescription("修改")]
        public ActionResult Edit(Guid id)
        {
            var vm = CreateVM<AdLayOutEntityVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(AdLayOutEntityVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoEdit();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(vm.Entity.ID);
                }
            }
        }
        #endregion


        #region 详细
        [ActionDescription("详细")]
        public ActionResult Details(Guid id)
        {
            var vm = CreateVM<AdLayOutEntityVM>(id);
            return PartialView(vm);
        }
        #endregion


    }
}
