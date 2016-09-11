(function () {
    'use strict';

    angular.module('angularMaterial', ['common.core'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/students/index/index.html",
                controller: "studentCtrl"
            })
        .otherwise({ redirectTo: "/" });
    }
    
    run.$inject = ['$rootScope', '$location', '$http'];

    function run($rootScope, $location, $http) {}


})();