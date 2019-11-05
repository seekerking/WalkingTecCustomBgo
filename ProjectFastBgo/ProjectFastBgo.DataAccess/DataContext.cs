
using ProjectFastBgo.Model.Entity.TikTokSound;
using Microsoft.EntityFrameworkCore;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using WalkingTec.Mvvm.Core;

namespace ProjectFastBgo.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public override DbContext GetContext()
        {
            return this;
        }

        #region TikTokSound

        public DbSet<TopHotSoundEntity> TopHotSoundEntities { get; set; }
        public DbSet<AdLayOutEntity> AdLayOutEntities { get; set; }
        public DbSet<SysSettingEntity> SysSettingEntities { get; set; }




        public DbSet<PushTasksEntity> PushTasksEntity { get; set; }

        #endregion



        #region EmojiMaster

        public DbSet<EmojiEntity> EmojiEntities { get; set; }
        public DbSet<GroupDicEntity> GroupDicEntities { get; set; }
        public DbSet<PaintMapEntity> PaintMapEntities { get; set; }

        #endregion

        public DataContext(string cs, DBTypeEnum dbtype)
             : base(cs, dbtype)
        {
        }

    }
}
