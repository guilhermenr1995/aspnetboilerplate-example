using Abp.Application.Navigation;
using Abp.Localization;
using SoiticTest.Authorization;

namespace SoiticTest.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SoiticTestNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Providers",
                        L("Providers"),
                        url: "#/providers"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Products",
                        L("Products"),
                        url: "#/products"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Movements",
                        L("Movements"),
                        url: "#/movements"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SoiticTestConsts.LocalizationSourceName);
        }
    }
}
