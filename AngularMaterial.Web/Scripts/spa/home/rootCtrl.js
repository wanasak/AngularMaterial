(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$mdSidenav', '$timeout'];

    function rootCtrl($scope, $mdSidenav, $timeout) {

        // App settings
        $scope.$root.app = {
            settings: {
                theme: 'indigo'
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