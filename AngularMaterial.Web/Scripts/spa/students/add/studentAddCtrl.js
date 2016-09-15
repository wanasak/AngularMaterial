(function (app) {
    'use strict';

    app.controller('studentAddCtrl', studentAddCtrl);

    studentAddCtrl.$inject = ['$scope', '$http', '$location'];

    function studentAddCtrl($scope, $http, $location) {

        $scope.addStudent = addStudent;

        function addStudent() {
            $http.post("api/students/add", $scope.student)
               .then(function (result) {
                   $location.path("/student");
               }, function (response) { });
        }

    }

})(angular.module('angularMaterial'));