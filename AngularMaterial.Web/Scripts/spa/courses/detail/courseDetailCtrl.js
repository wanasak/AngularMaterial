(function (app) {
    'use strict';

    app.controller('courseDetailCtrl', courseDetailCtrl);

    courseDetailCtrl.$inject = ['$scope', '$http', '$routeParams', '$mdBottomSheet', '$mdDialog', '$location'];

    function courseDetailCtrl($scope, $http, $routeParams, $mdBottomSheet, $mdDialog, $location) {

        $scope.course = {};
        $scope.showMoreAction = showMoreAction;

        function loadCourse() {
            $http.get("api/courses/" + $routeParams.id, null)
                .then(function (result) {
                    $scope.course = result.data;
                }, function (response) {});
        }
        function showMoreAction() {
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
                performMoreAction(clickedItem['name']);
            });
        }
        function showConfirmDelete() {
            var confirm = $mdDialog.confirm()
                .textContent('Would you like to delete this course?')
                .ariaLabel('Confirm')
                //.targetEvent(ev)
                .ok('Yes')
                .theme($scope.$root.app.settings.theme)
                .cancel('No');
            $mdDialog.show(confirm).then(function () {
                deleteCourse();
            }, function () { });
        }
        function performMoreAction(action) {
            if (action == "Delete") {
                showConfirmDelete();
            } else {

            }
        }
        function deleteCourse() {
            $http.delete("api/courses/" + $routeParams.id, null)
                .then(function (result) {
                    $location.path("/course");
                }, function (response) { });
        }

        loadCourse();
    }

})(angular.module('angularMaterial'));