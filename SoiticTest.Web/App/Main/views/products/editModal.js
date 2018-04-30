(function () {
    angular.module('app').controller('app.views.products.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.product', 'id',
        function ($scope, $uibModalInstance, productService, id) {
            var vm = this;
        
            vm.providers = [];

            var setAssignedProviders = function (product, providers) {

                console.log('product', product);
                console.log('providers', providers);

                for (var i = 0; i < providers.length; i++) {
                    //providers = todos fornecedores
                    //product.providers = os selecionados

                    console.log('product.providers', product.providers);

                    for (var j = 0; j < product.providers.length; j++) {

                        console.log('providers[i]', providers[i]);
                        console.log('product.providers[j]', product.providers[j]);

                        if (providers[i] == product.providers[j]) {
                            providers[i].isAssigned = true;
                        }
                    }
                    
                }
            }

            var init = function () {
                productService.getProviders()
                    .then(function (result) {
                        vm.providers = result.data;

                        productService.get({ id: id })
                            .then(function (result) {
                                vm.product = result.data;
                                console.log('vm.product', vm.product);
                                console.log('vm.providers', vm.providers);

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

                vm.product.providerNames = assignedProviders;
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