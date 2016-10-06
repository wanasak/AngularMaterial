(function (app) {
    'use strict';

    app.controller('chartCtrl', chartCtrl);

    chartCtrl.$inject = ['$scope', '$http'];

    function chartCtrl($scope, $http) {

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
        $scope.enrollmentStudentGoup = {
            labels: [],
            data: []
        };
        function loadEnrollmentStudentGroup() {
            $http.get("api/enrollments", null)
                .then(function (result) {
                    for (var i = 0, len = result.data.length; i < len; i++) {
                        $scope.enrollmentStudentGoup.labels.push('Course ID ' + result.data[i].CourseID);
                        $scope.enrollmentStudentGoup.data.push(result.data[i].StudentCount);
                    }
                }, function (response) {});
        }
        loadEnrollmentStudentGroup();
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