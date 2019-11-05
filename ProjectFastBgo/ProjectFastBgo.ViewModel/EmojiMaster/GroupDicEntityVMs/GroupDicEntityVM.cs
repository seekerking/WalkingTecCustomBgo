using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.GroupDicEntityVMs
{
    public partial class GroupDicEntityVM : BaseCRUDVM<GroupDicEntity>
    {

        public GroupDicEntityVM()
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

        public bool CheckIdInPaint(Guid id)
        {
            var query = DC.Set<PaintMapEntity>()
                .Any(x => x.GroupId == id);
            
            return query;

        }

        public bool CheckIdInEmoji(Guid id)
        {
            var query = DC.Set<EmojiEntity>()
                .Any(x => x.GroupId == id);

            return query;
        }

    }
}
