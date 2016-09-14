(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$mdSidenav', '$timeout'];

    function rootCtrl($scope, $mdSidenav, $timeout) {

        $scope.toggleLeft = buildToggler('left');

        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            }
        }

    }

})(angular.module('angularMaterial'));