using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace LHOfficeBgo.Model.Entity
{
    [Table("IndexImgs")]
   public class IndexImgsEntity : BasePoco
    {
        [Display(Name = "是否轮播")]
        public bool IsAuto { get; set; }
        [Display(Name = "播放速度(毫秒)")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        public string Imgs { get; set; }
        [Display(Name = "内容栏目")]
        [Required(ErrorMessage = "栏目不能为空")]
        public Guid IndexMenusId { get; set; }

        [ForeignKey("IndexMenusId")]
        public virtual IndexMenusEntity IndexMenus { get; set; }

    }
}
