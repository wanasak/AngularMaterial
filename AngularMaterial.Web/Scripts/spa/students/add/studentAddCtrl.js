(function (app) {
    'use strict';

    app.controller('studentAddCtrl', studentAddCtrl);

    studentAddCtrl.$inject = ['$scope', '$http'];

    function studentAddCtrl($scope, $http) {

        $scope.addStudent = addStudent;

        // TODO: Add student
        function addStudent() {
            console.log($scope.student);
            //$http.post("api/students/add", $scope.student)
            //    .then(function (result) {

            //    }, function (response) { });
        }

    }

})(angular.module('angularMaterial'));