(function (app) {
    'use strict';

    app.directive('sideNav', sideNav);

    function sideNav() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/spa/layouts/sideNav.html'
        }
    }

})(angular.module('angularMaterial'));