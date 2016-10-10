(function (app) {
    'use strict';

    app.controller('chartCtrl', chartCtrl);

    chartCtrl.$inject = ['$scope', '$http'];

    function chartCtrl($scope, $http) {

        // Angular Chart 
        $scope.enrollmentStudentCount = {
            labels: [],
            data: []
        };
        // Angular Chart - Bar
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
        $scope.students = loadAllStudents();
        $scope.searchStudents = searchStudents;
        $scope.selectedStudentChange = selectedStudentChange;
        $scope.isNoGrade = false;
        $scope.searchTextStudents = '';
        $scope.loadEnrollmentStudentCount = loadEnrollmentStudentCount;

        function searchStudents(query) {
            var result = query ? $scope.students.filter(createFilterFor(query)) : $scope.students;
            return result;
        }
        function selectedStudentChange(item) {
            console.log('Item changed to ' + JSON.stringify(item));
            if (item !== undefined) {
                $http.get("api/enrollments/student/" + item.value, null)
                    .then(function (result) {
                        $scope.enrollmentStudentGrade.labels.length = 0;
                        $scope.enrollmentStudentGrade.data.length = 0;
                        result.data.map(function (val, index) {
                            $scope.enrollmentStudentGrade.labels[index] = val.CourseTitle;
                            $scope.enrollmentStudentGrade.data[index] = val.GradePoint;
                        });
                        $scope.isNoGrade = (result.data.length === 0);
                    }, function (response) { });
            } else { $scope.isNoGrade = false; }
        }
        function loadEnrollmentStudentCount() {
            $http.get("api/enrollments", null)
                .then(function (result) {
                    $scope.enrollmentStudentCount.labels.length = 0;
                    $scope.enrollmentStudentCount.data.length = 0;
                    result.data.map(function (val, index) {
                        $scope.enrollmentStudentCount.labels[index] = 'Course ID ' + val.CourseID;
                        $scope.enrollmentStudentCount.data[index] = val.StudentCount;
                    });
                }, function (response) { });
        }
        function loadAllStudents() {
            var allStudents = [];
            $http.get("api/students", null)
                .then(function (result) {
                    //allStudents.length = 0;
                    result.data.map(function (item, index) {
                        allStudents[index] = {
                            value: item.ID,
                            display: item.FirstName + ' ' + item.LastName
                        };
                    });
                }, function (response) { });
            return allStudents;
        }
        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(student) {
                return (student.display.toLowerCase().indexOf(lowercaseQuery) > -1);
            }
        }

        loadEnrollmentStudentCount();

    }

})(angular.module('angularMaterial'));