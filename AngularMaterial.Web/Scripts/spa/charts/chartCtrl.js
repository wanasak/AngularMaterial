(function (app) {
    'use strict';

    app.controller('chartCtrl', chartCtrl);

    chartCtrl.$inject = ['$scope'];

    function chartCtrl($scope) {

        // Google Angular Chart
        $scope.myChartObject = {};
        $scope.myChartObject.type = "PieChart";
        $scope.onions = [
            { v: "Onions" },
            { v: 3 },
        ];
        $scope.myChartObject.data = {
            "cols": [
                { id: "t", label: "Topping", type: "string" },
                { id: "s", label: "Slices", type: "number" }
            ], "rows": [
                {
                    c: [
                        { v: "Mushrooms" },
                        { v: 3 },
                    ]
                },
                { c: $scope.onions },
                {
                    c: [
                        { v: "Olives" },
                        { v: 31 }
                    ]
                },
                {
                    c: [
                        { v: "Zucchini" },
                        { v: 1 },
                    ]
                },
                {
                    c: [
                        { v: "Pepperoni" },
                        { v: 2 },
                    ]
                }
            ]
        };
        $scope.myChartObject.options = {
            //'title': 'Number of students by department.'
        };

        // Angular Chart 
        $scope.labels = ["Accounting", "Nurse", "Engineering", "Economic", "Medicine", "Science"];
        $scope.data = [2, 5, 8, 1, 4, 10];

        // var test = [
        //     {id: 1, text: "aaa"},
        //     {id: 2, text: "bbb"},
        // ];

        // for (var i = 0, len = test.length; i < len; i++) {
        //     alert(test[i].text);
        // }

        // Angular Chart - Redar
        $scope.redar = {};
        $scope.redar.labels = ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"];

        $scope.redar.data = [
            [65, 59, 90, 81, 56, 55, 40]
        ];
    }

})(angular.module('angularMaterial'));