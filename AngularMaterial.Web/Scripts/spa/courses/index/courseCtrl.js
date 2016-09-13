(function (app) {
    'use strict';

    app.controller('courseCtrl', courseCtrl);

    courseCtrl.$inject = ['$scope', '$http', '$timeout', '$mdSidenav'];

    function courseCtrl($scope, $http, $timeout, $mdSidenav) {

        $scope.courses = [];
        $scope.toggleLeft = buildToggler('left');

        function loadCourses() {
            $http.get("api/courses", null)
                .then(function (result) {
                    $scope.courses = result.data;
                }, function (response) {

                });
        }
        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            }
        }

        loadCourses();

    }

})(angular.module('angularMaterial'));