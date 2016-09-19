(function (app) {
    'use strict';

    app.controller('departmentDetailCtrl', departmentDetailCtrl);

    departmentDetailCtrl.$inject = ['$scope', '$http', '$routeParams'];

    function departmentDetailCtrl($scope, $http, $routeParams) {

        $scope.department = {};

        function loadDepartment() {
            $http.get("api/departments/" + $routeParams.id, null)
                .then(function (result) {   
                    $scope.department = result.data;
                }, function (response) {});
        }

        loadDepartment();

    }

})(angular.module('angularMaterial'));