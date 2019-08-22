using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace LHOfficeBgo.Model.Entity
{
    [Table("IndexLayOut")]
   public class IndexLayOutEntity : BasePoco
    {
        [Display(Name = "自动播放")]
        [Required(ErrorMessage ="{0}必填")]
        public string  Name { get; set; }
        [Display(Name = "布局关键字")]
        [Required(ErrorMessage = "{0}必填")]
        public string LayOutKey { get; set; }
    }
}
