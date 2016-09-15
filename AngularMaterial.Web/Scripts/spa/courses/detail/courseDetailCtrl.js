(function (app) {
    'use strict';

    app.controller('courseDetailCtrl', courseDetailCtrl);

    courseDetailCtrl.$inject = ['$scope', '$http', '$routeParams'];

    function courseDetailCtrl($scope, $http, $routeParams) {

        $scope.course = {};

        function loadCourse() {
            $http.get("api/courses/" + $routeParams.id, null)
                .then(function (result) {
                    $scope.course = result.data;
                }, function (response) {});
        }

        loadCourse();
    }

})(angular.module('angularMaterial'));