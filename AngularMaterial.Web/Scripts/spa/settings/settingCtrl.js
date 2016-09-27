(function (app) {
    'use strict';

    app.controller('settingCtrl', settingCtrl);

    settingCtrl.$inject = ['$scope', '$mdToast', '$cookies'];

    function settingCtrl($scope, $mdToast, $cookies) {

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
                'purple',
                'indigo',
                'pink',
                'green',
                'yellow',
                'orange',
                'teal'
            ];
            return themes;
        }

        function saveSettings() {
            $cookies.put('myTheme', $scope.selectedTheme);
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