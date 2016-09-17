(function (app) {
    'use strict';

    app.controller('courseAddCtrl', courseAddCtrl);

    courseAddCtrl.$inject = ['$scope', '$http', '$location', '$mdToast'];

    function courseAddCtrl($scope, $http, $location, $mdToast) {

        $scope.addCourse = addCourse;

        function addCourse() {
            $http.post("api/courses/add", $scope.course)
                .then(function (result) {
                    $location.path("/course");
                }, function (response) {
                    addCourseFailed();
                });
        }
        function addCourseFailed() {
            $mdToast.show(
                $mdToast.simple()
                    .textContent('Create a new course failed. Please try again.')
                    .position('top rigth')
                    .hideDelay(2000)
            );
        }

    }

})(angular.module('angularMaterial'));