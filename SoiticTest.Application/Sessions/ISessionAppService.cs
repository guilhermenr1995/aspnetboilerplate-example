using System.Threading.Tasks;
using Abp.Application.Services;
using SoiticTest.Sessions.Dto;

namespace SoiticTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
