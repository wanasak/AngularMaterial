(function (app) {
    'use strict';

    app.controller('studentCtrl', studentCtrl);

    studentCtrl.$inject = ['$scope', '$mdDialog', '$http'];

    function studentCtrl($scope, $mdDialog, $http) {

        $scope.students = [];

        function loadStudents() {
            $http.get("api/students", null)
                .then(function (result) {
                    $scope.students = result.data;
                }, function (response) {

                });
        }

        loadStudents();

    }

})(angular.module('angularMaterial'));