(function (app) {
    'use strict';

    app.controller('bottomSheetListTemplateCtrl', bottomSheetListTemplateCtrl);

    bottomSheetListTemplateCtrl.$inject = ['$scope', '$mdBottomSheet', 'items'];

    function bottomSheetListTemplateCtrl($scope, $mdBottomSheet, items) {

        // $scope.items = [
        //     { name: 'Edit', icon: 'action:build' },
        //     { name: 'Delete', icon: 'action:delete' }
        // ];

        $scope.items = items;

        $scope.listItemClick = function($index) {
            var clickedItem = $scope.items[$index];
            $mdBottomSheet.hide(clickedItem);
        };

    }

})(angular.module('angularMaterial'));