using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using LHOfficeBgo.ViewModel.Content.IndexImgsEntityVMs;

namespace LHOfficeBgo.Controllers
{
    [Area("Content")]
    [ActionDescription("轮播图管理")]
    public partial class IndexImgsEntityController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<IndexImgsEntityListVM>();
            return PartialView(vm);
        }
        #endregion

        #region 新建
        [ActionDescription("新建")]
        public ActionResult Create()
        {
            var vm = CreateVM<IndexImgsEntityVM>();
            vm.ContentMenus = vm.GetContentMenu(null);
            vm.ContentMenusTree = vm.GetContentMenuTree();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("新建")]
        public ActionResult Create(IndexImgsEntityVM vm)
        {
            ModelState.Remove("Entity.Imgs");
            if (vm.FC.Where(x => x.Key.StartsWith("Entity.Imgs")).Select(x => x.Value).ToList().Count==0)
            {
                return FFResult().Alert("至少需要上传一张图");
            }
           

            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region 修改
        [ActionDescription("修改")]
        public ActionResult Edit(Guid id)
        {
            var vm = CreateVM<IndexImgsEntityVM>(id);
            vm.ContentMenus = vm.GetContentMenu(id);
            vm.ContentMenusTree = vm.GetContentMenuTree();
            return PartialView(vm);
        }

        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(IndexImgsEntityVM vm)
        {
            ModelState.Remove("Entity.Imgs");
            if (vm.FC.Where(x => x.Key.StartsWith("Entity.Imgs")).Select(x => x.Value).ToList().Count == 0)
            {
                return FFResult().Alert("至少需要上传一张图");
            }
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

        #region 删除
        [ActionDescription("删除")]
        public ActionResult Delete(Guid id)
        {
            var vm = CreateVM<IndexImgsEntityVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("删除")]
        [HttpPost]
        public ActionResult Delete(Guid id, IFormCollection nouse)
        {
            var vm = CreateVM<IndexImgsEntityVM>(id);
            vm.DoDelete();
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid();
            }
        }
        #endregion

        #region 详细
        [ActionDescription("详细")]
        public ActionResult Details(Guid id)
        {
            var vm = CreateVM<IndexImgsEntityVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region 批量修改
        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult BatchEdit(Guid[] IDs)
        {
            var vm = CreateVM<IndexImgsEntityBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult DoBatchEdit(IndexImgsEntityBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return PartialView("BatchEdit",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有"+vm.Ids.Length+"条数据被修改");
            }
        }
        #endregion

        #region 批量删除
        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult BatchDelete(Guid[] IDs)
        {
            var vm = CreateVM<IndexImgsEntityBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult DoBatchDelete(IndexImgsEntityBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return PartialView("BatchDelete",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有"+vm.Ids.Length+"条数据被删除");
            }
        }
        #endregion

        #region 导入
		[ActionDescription("导入")]
        public ActionResult Import()
        {
            var vm = CreateVM<IndexImgsEntityImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("导入")]
        public ActionResult Import(IndexImgsEntityImportVM vm, IFormCollection nouse)
        {
            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("成功导入 " + vm.EntityList.Count.ToString() + " 行数据");
            }
        }
        #endregion
    }
}
