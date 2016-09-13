(function (app) {
    'use strict';

    app.controller('studentCtrl', studentCtrl);

    studentCtrl.$inject = ['$scope', '$mdDialog', '$http', '$timeout', '$mdSidenav'];

    function studentCtrl($scope, $mdDialog, $http, $timeout, $mdSidenav) {

        $scope.students = [];
        $scope.toggleLeft = buildToggler('left');

        function loadStudents() {
            $http.get("api/students", null)
                .then(function (result) {
                    $scope.students = result.data;
                }, function (response) {

                });
        }
        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            }
        }

        loadStudents();

    }

})(angular.module('angularMaterial'));