(function (app) {
    'use strict';

    app.controller('courseAddCtrl', courseAddCtrl);

    courseAddCtrl.$inject = ['$scope', '$http', '$location', '$mdToast'];

    function courseAddCtrl($scope, $http, $location, $mdToast) {

        $scope.addCourse = addCourse;
        $scope.departments = [];

        function addCourse() {
            $http.post("api/courses/add", $scope.course)
                .then(function (result) {
                    $location.path("/course");
                }, function (response) {
                    addCourseFailed(response.data.Message);
                });
        }
        function addCourseFailed(msg) {
            $mdToast.show(
                $mdToast.simple()
                    //.textContent('Create a new course failed. Please try again.')
                    .textContent(msg)
                    .position('top rigth')
                    .hideDelay(2000)
            );
        }
        function loadDepartments() {
            $http.get("api/departments", null)
                .then(function (result) {
                    $scope.departments = result.data;
                }, function (response) {});
        }

        loadDepartments();

    }

})(angular.module('angularMaterial'));