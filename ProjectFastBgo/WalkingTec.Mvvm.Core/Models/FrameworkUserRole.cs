using System;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core.Attributes;
using WalkingTec.Mvvm.Core.Config;

namespace WalkingTec.Mvvm.Core
{
    [MiddleTable]
    [Table(CoreConfig.TablePreName+ "FrameworkUserRole")]
    public class FrameworkUserRole : BasePoco
    {
        public FrameworkUserBase User { get; set; }
        public FrameworkRole Role { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
