using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LHOfficeBgo.Model.Entity;
using WalkingTec.Mvvm.Core;

namespace LHOfficeBgo.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<IndexLayOutEntity> IndexLayOuts { get; set; }
        public DbSet<IndexMenusEntity> IndexMenus { get; set; }
        public DbSet<IndexContentEntity> IndexContent { get; set; }
        public DbSet<IndexImgsEntity> IndexImgs { get; set; }
        public DbSet<ManageConfigEntity> ManageConfigs { get; set; }
        public DataContext(string cs, DBTypeEnum dbtype)
             : base(cs, dbtype)
        {
        }

    }
}
