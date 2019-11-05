using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.PushTasks.PushTasksEntityVMs
{
    public partial class PushTasksEntityVM : BaseCRUDVM<PushTasksEntity>
    {
        public List<ComboSelectListItem> JumpType { get; set; }
        public PushTasksEntityVM()
        {
        }

        protected override void InitVM()
        {
            List<ComboSelectListItem> items = new List<ComboSelectListItem>();
            ComboSelectListItem item = new ComboSelectListItem();
            item.Text = "H5";
            item.Value = "H5";
            items.Add(item);
            ComboSelectListItem item2 = new ComboSelectListItem();
            item2.Text = "原生页面";
            item2.Value = "Native";
            items.Add(item2);
            JumpType = items;
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
    }
}
