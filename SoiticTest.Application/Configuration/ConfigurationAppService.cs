﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SoiticTest.Configuration.Dto;

namespace SoiticTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SoiticTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
