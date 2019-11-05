using System;
using AppSys.Utility;
using Microsoft.AspNetCore.Mvc;
using ProjectFastBgo.ViewModel.TikTokSound.SysSettingEntityVMs;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace ProjectFastBgo.Areas.TikTokSound.Controllers
{
    [Area("TikTokSound")]
    [ActionDescription("用户基础数据设置")]
    public partial class SysSettingEntityController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<SysSettingEntityListVM>();
            return PartialView(vm);
        }
        #endregion



        #region 修改
        [ActionDescription("修改")]
        public ActionResult Edit(Guid id)
        {
            var vm = CreateVM<SysSettingEntityVM>(id);
            vm.UserBasicSetting = vm.Entity.UserSettingDto;
            return PartialView(vm);
        }

        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(SysSettingEntityVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                if (vm.UserBasicSetting != null)
                {
                    vm.Entity.Config = vm.UserBasicSetting.JSONSerialize();
                    DC.UpdateProperty(vm.Entity,"Config");
                }


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
            var vm = CreateVM<SysSettingEntityVM>(id);
            return PartialView(vm);
        }
        #endregion

    }
}
