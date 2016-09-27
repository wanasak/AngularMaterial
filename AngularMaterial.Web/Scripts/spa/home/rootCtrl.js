(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$mdSidenav', '$timeout', '$cookies'];

    function rootCtrl($scope, $mdSidenav, $timeout, $cookies) {

        var themeCookie = $cookies.get('myTheme');

        // App settings
        $scope.$root.app = {
            settings: {
                theme: themeCookie || 'purple'
            }
        }
        $scope.toggleLeft = buildToggler('left');

        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            }
        }

    }

})(angular.module('angularMaterial'));