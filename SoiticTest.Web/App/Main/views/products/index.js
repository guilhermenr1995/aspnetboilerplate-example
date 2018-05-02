(function () {
    angular.module('app').controller('app.views.products.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.product',
        function ($scope, $timeout, $uibModal, productService) {
            var vm = this;

            vm.products = [];

            function getProducts() {
                productService.getAll({}).then(function (result) {
                    vm.products = result.data;
                });
            }

            vm.openProductCreationModal = function () {

                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/products/createModal.cshtml',
                    controller: 'app.views.products.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    setTimeout(function () {
                        $.AdminBSB.input.activate();
                    }, 3000);
                });

                modalInstance.result.then(function () {
                    getProducts();
                });
            };

            vm.openProductEditModal = function (product) {

                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/products/editModal.cshtml',
                    controller: 'app.views.products.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return product.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    
                        $.AdminBSB.input.activate();
                    
                });

                modalInstance.result.then(function () {
                    getProducts();
                });
            };

            vm.delete = function (product) {
                abp.message.confirm(
                    "Deletar produto " + product.name + "?",
                    function (result) {
                        if (result) {
                            productService.delete({ id: product.id })
                                .then(function () {
                                    abp.notify.info("Excluído: " + product.name);
                                    getProducts();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getProducts();
            };

            getProducts();
        }
    ]);
})();