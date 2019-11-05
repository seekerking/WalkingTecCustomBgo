using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;
using ProjectFastBgo.Model.Enum.TikTokSound;


namespace ProjectFastBgo.ViewModel.TikTokSound.TopHotSoundEntityVMs
{
    public partial class TopHotSoundEntitySearcher : BaseSearcher
    {

        [Display(Name = "栏目分类")]
        public MenuTypeEnum? MenuType { get; set; }
        protected override void InitVM()
        {
        }

    }
}
