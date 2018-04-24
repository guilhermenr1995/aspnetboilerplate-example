using Abp.AutoMapper;
using SoiticTest.Sessions.Dto;

namespace SoiticTest.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}