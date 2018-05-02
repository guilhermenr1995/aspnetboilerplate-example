(function () {
    angular.module('app').controller('app.views.products.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.product', 'id',
        function ($scope, $uibModalInstance, productService, id) {
            var vm = this;
        
            vm.providers = [];

            var setAssignedProviders = function (product, providers) {

                for (var i = 0; i < providers.length; i++) {
                    //providers = todos fornecedores
                    //product.providers = os selecionados

                    for (var j = 0; j < product.providers.length; j++) {

                        if (providers[i].id == product.providers[j].id) {
                            providers[i].isAssigned = true;
                        }
                    }
                    
                }
            }

            var init = function () {
                productService.getProviders()
                    .then(function (result) {

                        vm.providers = result.data;

                        productService.getById({ id: id })
                            .then(function (result) {
                                vm.product = result.data;
                                setAssignedProviders(vm.product, vm.providers);
                            });
                    });
            }

            init();

            vm.save = function () {
                var assignedProviders = [];

                for (var i = 0; i < vm.providers.length; i++) {
                    var provider = vm.providers[i];

                    if (!provider.isAssigned) {
                        continue;
                    }

                    assignedProviders.push(provider.id);
                }

                vm.product.ProviderIds = assignedProviders;

                productService.update(vm.product)
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