using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.EmojiMaster;


namespace ProjectFastBgo.ViewModel.EmojiMaster.PaintMapEntityVMs
{
    public partial class PaintMapEntitySearcher : BaseSearcher
    {
        [Display(Name = "所属分组")]
        public Guid? GroupId { get; set; }
        protected override void InitVM()
        {
        }

    }
}
