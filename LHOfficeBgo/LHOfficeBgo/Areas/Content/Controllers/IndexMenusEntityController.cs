﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LHOfficeBgo.Model.Entity;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using LHOfficeBgo.ViewModel.Content.IndexMenusEntityVMs;
using WalkingTec.Mvvm.Mvc.Binders;

namespace LHOfficeBgo.Controllers
{
    [Area("Content")]
    [ActionDescription("网站栏目管理")]
    public partial class IndexMenusEntityController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index(Guid? parentId)
        {
            var vm = CreateVM<IndexMenusEntityListVM>();
            vm.ParentId = parentId;
            return PartialView(vm);
        }
        #endregion

        #region 新建
        [ActionDescription("新建")]
        public ActionResult Create(Guid? parentId)
        {
            var vm = CreateVM<IndexMenusEntityVM>();
            vm.ParentId = parentId;
            vm.ParentMenus = vm.GetParentMenus(null, parentId);
            vm.MenuLayOuts = vm.GetLayOut(null);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("新建")]
        public ActionResult Create(IndexMenusEntityVM vm)
        {
            if (vm.ParentId.HasValue)
            {
                vm.Entity.DefaultImg = string.Empty;
                vm.Entity.HoverImg = string.Empty;
                vm.Entity.Url = string.Empty;
                vm.DC.UpdateProperty(vm.Entity, "DefaultImg");
                vm.DC.UpdateProperty(vm.Entity, "HoverImg");
                vm.DC.UpdateProperty(vm.Entity, "Url");
            }
            else
            {
                if (string.IsNullOrEmpty(vm.Entity.LayOutKey))
                {
                    return FFResult().Alert("顶层目录必填展示位置");
                }
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
        public ActionResult Edit(Guid id, Guid? parentId)
        {
            var vm = CreateVM<IndexMenusEntityVM>(id);
            vm.ParentId = parentId;
            vm.ParentMenus = vm.GetParentMenus(id, parentId);
            vm.MenuLayOuts = vm.GetLayOut(vm.Entity.LayOutKey);
            return PartialView(vm);
        }

        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(IndexMenusEntityVM vm)
        {
            if (vm.ParentId.HasValue)
            {
                vm.Entity.DefaultImg = string.Empty;
                vm.Entity.HoverImg = string.Empty;
                vm.Entity.Url = string.Empty;
                vm.DC.UpdateProperty(vm.Entity, "DefaultImg");
                vm.DC.UpdateProperty(vm.Entity, "HoverImg");
                vm.DC.UpdateProperty(vm.Entity, "Url");
            }
            else
            {
                if (string.IsNullOrEmpty(vm.Entity.LayOutKey))
                {
                    return FFResult().Alert("顶层目录必填展示位置");
                }
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
            var vm = CreateVM<IndexMenusEntityVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("删除")]
        [HttpPost]
        public ActionResult Delete(Guid id, IFormCollection nouse)
        {
            var vm = CreateVM<IndexMenusEntityVM>(id);
            if (vm.HaveChildMenu())
            {
                return FFResult().Alert("有子目录不允许删除，请先删除子目录");
            }

            if (vm.HaveContent())
            {
                return FFResult().Alert("目录下面有内容，请先删除内容");
            }

            if (vm.HaveImages())
            {
                return FFResult().Alert("目录下面有图片关联，请先删除图片");
            }
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
            var vm = CreateVM<IndexMenusEntityVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region 批量修改
        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult BatchEdit(Guid[] IDs)
        {
            var vm = CreateVM<IndexMenusEntityBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult DoBatchEdit(IndexMenusEntityBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<IndexMenusEntityBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult DoBatchDelete(IndexMenusEntityBatchVM vm, IFormCollection nouse)
        {
            if (vm.HaveChildMenu(vm.Ids.ToList()))
            {
                return FFResult().Alert("有数据有子目录不允许删除，请先删除子目录");
            }

            if (vm.HaveContents(vm.Ids.ToList()))
            {
                return FFResult().Alert("有数据有内容关联，请删除关联内容");
            }
            if (vm.HaveImages(vm.Ids.ToList()))
            {
                return FFResult().Alert("有数据有图片关联，请删除关联图片");
            }

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
            var vm = CreateVM<IndexMenusEntityImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("导入")]
        public ActionResult Import(IndexMenusEntityImportVM vm, IFormCollection nouse)
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