using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using ProjectFastBgo.Model.Enum.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.GroupDicEntityVMs
{
    public partial class GroupDicEntitySearcher : BaseSearcher
    {
        [Display(Name = "分组类型")] public GroupTypeEnum? Type { get; set; } = GroupTypeEnum.表情包;
        protected override void InitVM()
        {
        }

    }
}
