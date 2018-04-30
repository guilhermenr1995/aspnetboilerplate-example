(function () {
    var controllerId = 'app.views.layout.sidebarNav';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;

            vm.menuItems = [
                createMenuItem(App.localize("Providers"), "", "person", "providers"),
                createMenuItem(App.localize("Products"), "", "archive", "products"),
                createMenuItem(App.localize("Movements"), "", "equalizer", "movements"),
                createMenuItem(App.localize("Users"), "Pages.Users", "people", "users")
            ];

            vm.showMenuItem = function (menuItem) {
                if (menuItem.permissionName) {
                    return abp.auth.isGranted(menuItem.permissionName);
                }

                return true;
            }

            function createMenuItem(name, permissionName, icon, route, childItems) {
                return {
                    name: name,
                    permissionName: permissionName,
                    icon: icon,
                    route: route,
                    items: childItems
                };
            }
        }
    ]);
})();