using SoiticTest.EntityFramework;
using EntityFramework.DynamicFilters;

namespace SoiticTest.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly SoiticTestDbContext _context;

        public InitialHostDbBuilder(SoiticTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
