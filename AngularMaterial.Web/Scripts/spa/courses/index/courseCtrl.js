(function (app) {
    'use strict';

    app.controller('courseCtrl', courseCtrl);

    courseCtrl.$inject = ['$scope', '$http'];

    function courseCtrl($scope, $http) {

        $scope.courses = [];

        function loadCourses() {
            $http.get("api/courses", null)
                .then(function (result) {
                    $scope.courses = result.data;
                }, function (response) {

                });
        }

        loadCourses();

    }

})(angular.module('angularMaterial'));