using Abp.Authorization;
using SoiticTest.Authorization.Roles;
using SoiticTest.Authorization.Users;

namespace SoiticTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
