using System.Linq;
using SoiticTest.EntityFramework;
using SoiticTest.MultiTenancy;

namespace SoiticTest.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly SoiticTestDbContext _context;

        public DefaultTenantCreator(SoiticTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
