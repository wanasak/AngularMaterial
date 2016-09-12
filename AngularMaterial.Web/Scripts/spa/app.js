(function () {
    'use strict';

    angular.module('angularMaterial', ['common.core'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', '$mdIconProvider'];

    function config($routeProvider, $mdIconProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/students/index/index.html",
                controller: "studentCtrl"
            })
        .otherwise({ redirectTo: "/" });
        // Config Material Icons
        $mdIconProvider
            .iconSet('action', 'contents/img/icons/sets/action-icons.svg', 24)
            .iconSet('social', 'contents/img/icons/sets/social-icons.svg', 24)
            .iconSet('navigation', 'contents/img/icons/sets/navigation-icons.svg', 24)
            .iconSet('communication', 'contents/img/icons/sets/communication-icons.svg', 24)
            .defaultIconSet('contents/img/icons/sets/core-icons.svg', 24);
    }
    
    run.$inject = ['$rootScope', '$location', '$http'];

    function run($rootScope, $location, $http) {}

})();