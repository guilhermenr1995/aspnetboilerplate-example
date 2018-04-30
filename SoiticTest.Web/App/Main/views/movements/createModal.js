(function () {

    angular.module('app').controller('app.views.movements.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.movement',
        function ($scope, $uibModalInstance, movementService) {

            var vm = this;
            vm.products = [];

            function getProducts() {
                movementService.getProducts()
                    .then(function (result) {
                        vm.products = result.data;
                    });
            }

            vm.save = function () {
                console.log('vm.movement', vm.movement);
                movementService.create(vm.movement)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getProducts();
            
        }
    ]);
})();