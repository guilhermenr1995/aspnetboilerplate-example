﻿(function () {

    angular.module('app').controller('app.views.movements.index', [
        '$scope', '$uibModal', 'abp.services.app.movement',
        function ($scope, $uibModal, movementService) {
            var vm = this;

            vm.movements = [];

            function getMovements() {
                movementService.getAll({}).then(function (result) {
                    console.log('result', result);
                    vm.movements = result.data;
                });
            }

            vm.openMovementCreationModal = function () {
                
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/movements/createModal.cshtml',
                    controller: 'app.views.movements.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getMovements();
                });
            };


            vm.openMovementEditModal = function (movement) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/movements/editModal.cshtml',
                    controller: 'app.views.movements.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return movement.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {

                    $('#movementphone').inputmask([{ mask: '(99) 9999-9999' }, { mask: '(99) 99999-9999' }]);
                    $('#movementcpf').inputmask([{ mask: '999.999.999-99' }, { mask: '99.999.999/9999-99' }]);

                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getMovements();
                });
            };

            vm.delete = function (movement) {
                abp.message.confirm(
                    "Deseja excluir " + movement.name + "?",
                    function (result) {
                        if (result) {

                            movementService.delete({ id: movement.id })
                                .then(function () {
                                    abp.notify.info("Excluído: " + movement.name);
                                    getMovements();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getMovements();
            };

            getMovements();
        }
    ]);
})();