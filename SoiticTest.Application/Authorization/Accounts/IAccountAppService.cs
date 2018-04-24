using System.Threading.Tasks;
using Abp.Application.Services;
using SoiticTest.Authorization.Accounts.Dto;

namespace SoiticTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
