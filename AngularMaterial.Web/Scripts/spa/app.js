(function () {
    'use strict';

    angular.module('angularMaterial', ['common.core'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', '$mdIconProvider'];

    function config($routeProvider, $mdIconProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/student", {
                templateUrl: "scripts/spa/students/index/index.html",
                controller: "studentCtrl"
            })
            .when("/student/add", {
                templateUrl: "scripts/spa/students/add/studentAdd.html",
                controller: "studentAddCtrl"
            })
            .when("/student/:id", {
                templateUrl: "scripts/spa/students/detail/studentDetailCtrl.html",
                controller: "studentDetailCtrl"
            })
            .when("/course", {
                templateUrl: "scripts/spa/courses/index/index.html",
                controller: "courseCtrl"
            })
            .when("/course/:id", {
                templateUrl: "scripts/spa/courses/detail/courseDetail.html",
                controller: "courseDetailCtrl"
            })
            .otherwise({ redirectTo: "/" });
        // Config Material Icons
        $mdIconProvider
            .iconSet('action', 'contents/img/icons/sets/action-icons.svg', 24)
            .iconSet('social', 'contents/img/icons/sets/social-icons.svg', 24)
            .iconSet('navigation', 'contents/img/icons/sets/navigation-icons.svg', 24)
            .iconSet('communication', 'contents/img/icons/sets/communication-icons.svg', 24)
            .defaultIconSet('contents/img/icons/sets/content-icons.svg', 24);
    }
    
    run.$inject = ['$rootScope', '$location', '$http'];

    function run($rootScope, $location, $http) {}

})();