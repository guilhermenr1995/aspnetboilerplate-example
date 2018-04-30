(function () {
    angular.module('app').controller('app.views.providers.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.provider', 'id',
        function ($scope, $uibModalInstance, providerService, id) {

            var vm = this;

            vm.provider = {};

            function init() {
                providerService.getById({
                    id: id
                }).then(function (result) {
                    vm.provider = result.data;
                });
            }

            init();

            vm.save = function () {
                abp.ui.setBusy();
                providerService.update(vm.provider)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
        }
    ]);
})();