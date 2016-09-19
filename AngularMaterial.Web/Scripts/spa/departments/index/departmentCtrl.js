(function (app) {
    'use strict';

    app.controller('departmentCtrl', departmentCtrl);

    departmentCtrl.$inject = ['$scope', '$http'];

    function departmentCtrl($scope, $http) {

        $scope.departments = [];

        function loadDepartments() {
            $http.get("api/departments", null)
                .then(function (result) {
                    $scope.departments = result.data;
                }, function (response) {});
        }

        loadDepartments();

    }

})(angular.module('angularMaterial'));