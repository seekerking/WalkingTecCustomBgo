using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LHOfficeBgo.Model.Dto;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Content.IndexContentEntityVMs
{
    public partial class IndexContentEntityVM : BaseCRUDVM<IndexContentEntity>
    {

        public List<ComboSelectListItem> ContentMenus { get; set; }
        public List<GroupIndexMenuDto> ContentMenusTree { get; set; }
        public IndexContentEntityVM()
        {
            SetInclude(x => x.IndexMenus);
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

        public List<ComboSelectListItem> GetContentMenu(Guid? ownId)
        {
               var list = DC.Set<IndexMenusEntity>()

                .Select(x => new ComboSelectListItem
                {
                    Value = x.ID.ToString("D"),
                    Text = x.Name,
                    Selected =ownId.HasValue && ownId==x.ID
                }).ToList();
            return list;
        }
        public List<GroupIndexMenuDto> GetContentMenuTree()
        {
            return DC.Set<IndexMenusEntity>().ToList().GetGroupList();
        }
    }
}
