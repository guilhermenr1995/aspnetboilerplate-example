using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using SoiticTest.Authorization.Roles;
using SoiticTest.Authorization.Users;
using SoiticTest.MultiTenancy;

namespace SoiticTest.EntityFramework
{
    public class SoiticTestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SoiticTestDbContext() : base("Default")
        {

        }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Provider> Providers { get; set; }
        public DbSet<Models.Movement> Movements { get; set; }


        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SoiticTestDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SoiticTestDbContext since ABP automatically handles it.
         */
        public SoiticTestDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SoiticTestDbContext(DbConnection existingConnection) : base(existingConnection, false)
        {

        }

        public SoiticTestDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
