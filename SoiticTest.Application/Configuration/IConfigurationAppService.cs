using System.Threading.Tasks;
using Abp.Application.Services;
using SoiticTest.Configuration.Dto;

namespace SoiticTest.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}