(function (app) {
    'use strict';

    app.controller('studentAddCtrl', studentAddCtrl);

    studentAddCtrl.$inject = ['$scope', '$http', '$location'];

    function studentAddCtrl($scope, $http, $location) {

        $scope.student = {
            Courses: []
        };
        $scope.addStudent = addStudent;
        $scope.courses = [];
        //$scope.student.Courses = [];
        $scope.toggle = function (item, list) {
            var idx = list.indexOf(item);
            if (idx > -1) {
                list.splice(idx, 1);
            }
            else {
                list.push(item);
            }
        };
        $scope.exists = function (item, list) {
            //console.log(item);
            //console.log(list.indexOf(item) > -1);
            return list.indexOf(item) > -1;
        };
        $scope.isIndeterminate = function () {
            return ($scope.student.Courses.length !== 0 &&
                $scope.student.Courses.length !== $scope.courses.length);
        };
        $scope.isChecked = function () {
            return $scope.student.Courses.length === $scope.courses.length;
        };
        $scope.toggleAll = function () {
            if ($scope.student.Courses.length === $scope.courses.length) {
                $scope.student.Courses = [];
            } else if ($scope.student.Courses.length === 0 || $scope.student.Courses.length > 0) {
                $scope.courses.map(function (val, index) {
                    $scope.student.Courses[index] = val.ID;
                });
                //$scope.student.Courses = $scope.courses.slice(0);
            }
        };

        function addStudent() {
            console.log(JSON.stringify($scope.student));
            $http.post("api/students/add", $scope.student)
                .then(function (result) {
                    $location.path("/student");
                }, function (response) { });
        }
        function loadAllCourses() {
            $http.get("api/courses", null)
                .then(function (result) {
                    $scope.courses = result.data;
                }, function (response) {});
        }

        loadAllCourses();

    }

})(angular.module('angularMaterial'));