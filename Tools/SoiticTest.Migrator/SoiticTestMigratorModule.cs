using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using SoiticTest.EntityFramework;

namespace SoiticTest.Migrator
{
    [DependsOn(typeof(SoiticTestDataModule))]
    public class SoiticTestMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SoiticTestDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}