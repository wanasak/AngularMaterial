(function (app) {
    'use strict';

    app.controller('settingCtrl', settingCtrl);

    settingCtrl.$inject = ['$scope', '$mdToast'];

    function settingCtrl($scope, $mdToast) {

        $scope.saveSettings = saveSettings;
        $scope.selectedTheme = $scope.$root.app.settings.theme;
        $scope.themes = ThemeService();

        // $scope.$watch('selectedTheme', function (value) {
        //     if (value != undefined) {
        //         $scope.$root.app.settings.theme = value;
        //         //$scope.$apply();
        //         //$scope.$digest();
        //     }
        // });

        function ThemeService() {
            var themes = [
                'indigo',
                'pink',
                'green',
                'yellow',
                'orange'
            ];
            return themes;
        }

        function saveSettings() {
            $scope.$root.app.settings.theme = $scope.selectedTheme;
            $mdToast.show(
                $mdToast.simple()
                    .textContent('Your settings have been saved.')
                    .position('top right' )
                    .hideDelay(2000)
                );
        }

    }

})(angular.module('angularMaterial'));