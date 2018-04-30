(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in SoiticTestNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            $stateProvider
                .state('products', {
                    url: '/products',
                    templateUrl: '/App/Main/views/products/index.cshtml',
                    menu: 'Products' //Matches to name of 'Products' menu in SoiticTestNavigationProvider
                });

            $stateProvider
                .state('providers', {
                    url: '/providers',
                    templateUrl: '/App/Main/views/providers/index.cshtml',
                    menu: 'Providers' //Matches to name of 'Providers' menu in SoiticTestNavigationProvider
                });

            $stateProvider
                .state('movements', {
                    url: '/movements',
                    templateUrl: '/App/Main/views/movements/index.cshtml',
                    menu: 'Movements' //Matches to name of 'Movements' menu in SoiticTestNavigationProvider
                });
        }
    ]);

})();