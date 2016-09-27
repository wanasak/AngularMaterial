(function () {
    'use strict';

    angular.module('angularMaterial', ['common.core'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', '$mdIconProvider', '$mdThemingProvider'];

    function config($routeProvider, $mdIconProvider, $mdThemingProvider) {
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
            .when("/course/add", {
                templateUrl: "scripts/spa/courses/add/courseAdd.html",
                controller: "courseAddCtrl"
            })
            .when("/course/:id", {
                templateUrl: "scripts/spa/courses/detail/courseDetail.html",
                controller: "courseDetailCtrl"
            })
            .when("/department", {
                templateUrl: "scripts/spa/departments/index/index.html",
                controller: "departmentCtrl"
            })
            .when("/department/:id", {
                templateUrl: "scripts/spa/departments/detail/departmentDetail.html",
                controller: "departmentDetailCtrl"
            })
            .when("/setting", {
                templateUrl: "scripts/spa/settings/index.html",
                controller: "settingCtrl"
            })
            .otherwise({ redirectTo: "/" });
        // Config Material Icons
        $mdIconProvider
            .iconSet('action', 'contents/img/icons/sets/action-icons.svg', 24)
            .iconSet('social', 'contents/img/icons/sets/social-icons.svg', 24)
            .iconSet('navigation', 'contents/img/icons/sets/navigation-icons.svg', 24)
            .iconSet('communication', 'contents/img/icons/sets/communication-icons.svg', 24)
            .defaultIconSet('contents/img/icons/sets/content-icons.svg', 24);
        // Create the other theme options
        var themes = ThemeService();
        for (var index = 0; index < themes.length; ++index) {
            $mdThemingProvider.theme(themes[index])// + '-theme')
                .primaryPalette(themes[index]);
        }
        // Enable theme watching.
        $mdThemingProvider.alwaysWatchTheme(true);
    }

    function ThemeService() {
        var themes = [
            'purple',
            'indigo',
            'pink',
            'green',
            'yellow',
            'orange',
            'teal'
        ];
        return themes;
    }

    run.$inject = ['$rootScope', '$location', '$http'];

    function run($rootScope, $location, $http) { }

})();