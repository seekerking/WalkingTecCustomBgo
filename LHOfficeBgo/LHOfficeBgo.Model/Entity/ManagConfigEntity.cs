using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace LHOfficeBgo.Model.Entity
{
    [Table("ManageConfig")]
    public class ManageConfigEntity: BasePoco
    {
        [Display(Name = "配置键值")]
        [StringLength(20, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string DataKey { get; set; }

        [Display(Name = "Ios下载地址")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string IosDownLoadUrl { get; set; }
        [Display(Name = "安卓下载地址")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string AndroidDownLoadUrl { get; set; }
        [Display(Name = "二维码地址")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string QrCodeUrl { get; set; }
 
    }
}
