(function (app) {
    'use strict';

    app.controller('departmentCtrl', departmentCtrl);

    departmentCtrl.$inject = ['$scope', '$http'];

    function departmentCtrl($scope, $http) {

        $scope.departments = [];
        $scope.orderDepartment = 'Name';
        $scope.onClickOrderDepartment = onClickOrderDepartment;

        function loadDepartments() {
            $http.get("api/departments", null)
                .then(function (result) {
                    $scope.departments = result.data;
                }, function (response) {});
        }
        function onClickOrderDepartment(order) {
            $scope.orderDepartment = (order === 'aesc') ? 'Name' : '-Name';
        }

        loadDepartments();

    }

})(angular.module('angularMaterial'));