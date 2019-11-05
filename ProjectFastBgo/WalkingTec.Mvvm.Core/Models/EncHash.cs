using System;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core.Config;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// EncHash
    /// </summary>
    [Table(CoreConfig.TablePreName + "EncHashs")]
    public class EncHash : BasePoco
    {
        public Guid Key { get; set; }
        public int Hash { get; set; }
    }
}
