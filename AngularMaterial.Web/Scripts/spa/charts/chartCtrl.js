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
        $scope.enrollmentStudentCount = {
            labels: [],
            data: []
        };
        function loadEnrollmentStudentGroup() {
            $http.get("api/enrollments", null)
                .then(function (result) {
                    result.data.map(function (val, index) {
                        $scope.enrollmentStudentCount.labels[index] = 'Course ID ' + val.CourseID;
                        $scope.enrollmentStudentCount.data[index] = val.StudentCount;
                    });
                    // for (var i = 0, len = result.data.length; i < len; i++) {
                    //     $scope.enrollmentStudentGoup.labels.push('Course ID ' + result.data[i].CourseID);
                    //     $scope.enrollmentStudentGoup.data.push(result.data[i].StudentCount);
                    // }
                }, function (response) { });
        }

        // Angular Chart - Redar
        $scope.enrollmentStudentGrade = {
            labels: [],
            data: [],
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                            max: 4,
                            stepSize: 1
                        }
                    }]
                }
            }
        }
        function loadenrollmentStudentGrade() {
            $http.get("api/enrollments/student/1", null)
                .then(function (result) {
                    result.data.map(function (val, index) {
                        $scope.enrollmentStudentGrade.labels[index] = val.CourseTitle;
                        $scope.enrollmentStudentGrade.data[index] = val.GradePoint;
                    });
                }, function (response) { });
        }

        loadEnrollmentStudentGroup();
        loadenrollmentStudentGrade();
    }

})(angular.module('angularMaterial'));