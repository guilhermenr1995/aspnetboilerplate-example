(function () {

    angular.module('app').controller('app.views.providers.index', [
        '$scope', '$uibModal', 'abp.services.app.provider',
        function ($scope, $uibModal, providerService) {
            var vm = this;

            vm.providers = [];

            function getProviders() {
                providerService.getAll({}).then(function (result) {
                    vm.providers = result.data;
                });
            }

            vm.openProviderCreationModal = function () {
                
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/providers/createModal.cshtml',
                    controller: 'app.views.providers.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $('#providerphone').inputmask([{ mask: '(99) 9999-9999' }, { mask: '(99) 99999-9999' }]);
                    $('#providercpf').inputmask([{ mask: '999.999.999-99' }, { mask: '99.999.999/9999-99' }]);
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getProviders();
                });
            };


            vm.openProviderEditModal = function (provider) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/providers/editModal.cshtml',
                    controller: 'app.views.providers.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return provider.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {

                    $('#providerphone').inputmask([{ mask: '(99) 9999-9999' }, { mask: '(99) 99999-9999' }]);
                    $('#providercpf').inputmask([{ mask: '999.999.999-99' }, { mask: '99.999.999/9999-99' }]);

                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getProviders();
                });
            };

            vm.delete = function (provider) {
                abp.message.confirm(
                    "Deseja excluir'" + provider.name + "'?",
                    function (result) {
                        if (result) {

                            providerService.delete({ id: provider.id })
                                .then(function () {
                                    abp.notify.info("Excluído: " + provider.name);
                                    getProviders();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getProviders();
            };

            getProviders();
        }
    ]);
})();