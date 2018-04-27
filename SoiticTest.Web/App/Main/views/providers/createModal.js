(function () {

    angular.module('app').controller('app.views.providers.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.provider',
        function ($scope, $uibModalInstance, providerService) {

            var vm = this;

            vm.save = function () {
                providerService.create(vm.provider)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            
        }
    ]);
})();