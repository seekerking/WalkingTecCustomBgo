using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ProjectFastBgo.Model.Entity.TikTokSound;


namespace ProjectFastBgo.ViewModel.PushTasks.PushTasksEntityVMs
{
    public partial class PushTasksEntitySearcher : BaseSearcher
    {
        [Display(Name = "状态")]
        public CidEnum? Cid { get; set; }
        [Display(Name = "标题")]
        public String TaskTitle { get; set; }
        [Display(Name = "状态")]
        public StateEnum? TaskState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
