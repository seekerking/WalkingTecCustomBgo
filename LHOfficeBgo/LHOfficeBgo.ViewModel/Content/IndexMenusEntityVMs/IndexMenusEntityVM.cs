using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexMenusEntityVMs
{
    public partial class IndexMenusEntityVM : BaseCRUDVM<IndexMenusEntity>
    {
        public Guid? ParentId { get; set; }
        public List<ComboSelectListItem> ParentMenus;
        public List<ComboSelectListItem> MenuLayOuts;

        public IndexMenusEntityVM()
        {
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }

        public bool HaveChildMenu()
        {
            return DC.Set<IndexMenusEntity>().Any(x => x.ParentId == Entity.ID);
        }

        public bool HaveContent()
        {
            return DC.Set<IndexContentEntity>().Any(x => x.IndexMenusId == Entity.ID);
        }

        public bool HaveImages()
        {
            return DC.Set<IndexImgsEntity>().Any(x => x.IndexMenusId == Entity.ID);
        }

        public List<ComboSelectListItem> GetLayOut(string layOutKey)
        {
            var query = DC.Set<IndexLayOutEntity>()
                .Select(x => new ComboSelectListItem
                {
                    Value = x.LayOutKey,
                    Text = x.Name,
                    Selected = !string.IsNullOrEmpty(layOutKey) && layOutKey==x.LayOutKey
                }).ToList();
            return query;
        }

        public List<ComboSelectListItem> GetParentMenus(Guid? ownId,Guid?parentId)
        {
            //如果顶层目录切已经创建，则不能选择子类作为顶层目录
            //修改需要将目录中自己排除，避免自己成为自己的目录
            var query = DC.Set<IndexMenusEntity>()
                .Where(x=> !ownId.HasValue || (!parentId.HasValue&&x.ParentId==null||parentId.HasValue))
                .Where(x => !ownId.HasValue || x.ID != ownId.Value)
              
                .Select(x => new ComboSelectListItem
                {
                    Value = x.ID.ToString("D"),
                    Text = x.Name,
                    Selected = parentId.HasValue && parentId.Value == x.ID||!ownId.HasValue&&parentId.HasValue&&parentId==x.ID
                }).ToList();
            return query;
        }
    }
}
