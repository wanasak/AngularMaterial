(function (app) {
    'use strict';

    app.controller('studentDetailCtrl', studentDetailCtrl);

    studentDetailCtrl.$inject = ['$scope', '$routeParams', '$http', '$timeout', '$mdBottomSheet', '$mdToast', '$mdDialog', '$location'];

    function studentDetailCtrl($scope, $routeParams, $http, $timeout, $mdBottomSheet, $mdToast, $mdDialog, $location) {

        $scope.student = {};
        $scope.showMoreAction = showMoreAction;

        function loadStudentDetail() {
            $http.get("api/students/" + $routeParams.id, null)
                .then(function (result) {
                    $scope.student = result.data;
                }, function (response) { });
        }
        function showMoreAction() {
            //$scope.alert = '';
            $mdBottomSheet.show({
                templateUrl: 'scripts/spa/layouts/bottomSheetListTemplate.html',
                controller: 'bottomSheetListTemplateCtrl',
                resolve: {
                    items: function () {
                        return [
                            { name: 'Edit', icon: 'action:build' },
                            { name: 'Delete', icon: 'action:delete' }
                        ]
                    }
                }
            }).then(function (clickedItem) {
                //$scope.alert = clickedItem['name'] + ' clicked!';
                performMoreAction(clickedItem['name']);
            });
        }
        function showConfirmDelete() {
            var confirm = $mdDialog.confirm()
                //.title('Would you like to delete this student?')
                .textContent('Would you like to delete this student?')
                .ariaLabel('Confirm')
                //.targetEvent(ev)
                .ok('Yes')
                .theme($scope.$root.app.settings.theme)
                .cancel('No');
            $mdDialog.show(confirm).then(function () {
                deleteStudent();
            }, function () { });
        }
        function performMoreAction(action) {
            if (action == "Delete") {
                showConfirmDelete();
            } else {

            }
        }
        function deleteStudent() {
            $http.delete("api/students/" + $routeParams.id, null)
                .then(function (result) {
                    $location.path("/student");
                }, function (response) { });
        }

        loadStudentDetail();

    }

})(angular.module('angularMaterial'));