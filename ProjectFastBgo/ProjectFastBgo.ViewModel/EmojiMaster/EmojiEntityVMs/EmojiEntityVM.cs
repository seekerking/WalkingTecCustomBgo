using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using ProjectFastBgo.Model.Enum.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.EmojiEntityVMs
{
    public partial class EmojiEntityVM : BaseCRUDVM<EmojiEntity>
    {
        public List<ComboSelectListItem> AllGroupDicEntitys { get; set; }

        public EmojiEntityVM()
        {
            SetInclude(x => x.GroupDicEntity);
        }

        protected override void InitVM()
        {
            AllGroupDicEntitys = DC.Set<GroupDicEntity>()
                .Where(x => x.Type == GroupTypeEnum.表情包)
                .OrderBy(x => x.Sort)
                .Select(x => new ComboSelectListItem()
                {
                    Text = x.Title,
                    Value = x.ID.ToString("D"),
                    Selected = Entity.GroupId == x.ID

                }).ToList();
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

