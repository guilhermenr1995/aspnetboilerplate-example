using Abp.MultiTenancy;
using SoiticTest.Authorization.Users;

namespace SoiticTest.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}