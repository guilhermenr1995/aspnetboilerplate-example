using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoiticTest.MultiTenancy.Dto;

namespace SoiticTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
