(function (app) {
    'use strict';

    app.controller('bottomSheetListTemplateCtrl', bottomSheetListTemplateCtrl);

    bottomSheetListTemplateCtrl.$inject = ['$scope', '$mdBottomSheet'];

    function bottomSheetListTemplateCtrl($scope, $mdBottomSheet) {

        $scope.items = [
            { name: 'Edit', icon: 'action:build' },
            { name: 'Delete', icon: 'action:delete' }
        ];

        $scope.listItemClick = function($index) {
            var clickedItem = $scope.items[$index];
            $mdBottomSheet.hide(clickedItem);
        };

    }

})(angular.module('angularMaterial'));