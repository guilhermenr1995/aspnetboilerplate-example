(function () {
    angular.module('app').controller('app.views.products.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.product',
        function ($scope, $uibModalInstance, productService) {
            var vm = this;

            vm.product = {};
            vm.providers = [];

            function getProviders() {
                productService.getProviders()
                    .then(function (result) {
                        vm.providers = result.data;
                    });
            }

            vm.save = function () {

                var assignedProviders = [];

                for (var i = 0; i < vm.providers.length; i++) {

                    var provider = vm.providers[i];
                    if (!provider.isAssigned) {
                        continue;
                    }

                    assignedProviders.push(provider);
                }

                vm.product.providers = assignedProviders;

                productService.create(vm.product)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getProviders();
        }
    ]);
})();