(function (app) {
    'use strict';

    app.controller('courseAddCtrl', courseAddCtrl);

    courseAddCtrl.$inject = ['$scope', '$http', '$location', '$mdToast'];

    function courseAddCtrl($scope, $http, $location, $mdToast) {

        $scope.course = {
            Instructors: []
        }
        $scope.addCourse = addCourse;
        $scope.departments = [];
        $scope.instructor = {
            items: [],
            searchText: null,
            selectedItem: null,
            transformChip: transformChip,
            selectedInstructors: [],
            querySearch: querySearch
        };

        function addCourse() {
            getSelectedInstructorsID()
            $http.post("api/courses/add", $scope.course)
                .then(function (result) {
                    $location.path("/course");
                }, function (response) {
                    addCourseFailed(response.data.Message);
                });
        }
        function addCourseFailed(msg) {
            $mdToast.show(
                $mdToast.simple()
                    //.textContent('Create a new course failed. Please try again.')
                    .textContent(msg)
                    .position('top right')
                    .hideDelay(2000)
            );
        }
        function loadDepartments() {
            $http.get("api/departments", null)
                .then(function (result) {
                    $scope.departments = result.data;
                }, function (response) { });
        }
        function loadInstructor() {
            $http.get("api/instructors", null)
                .then(function (result) {
                    $scope.instructor.items = result.data;
                }, function (response) { });
        }
        function transformChip(chip) {
            // If it is an object, it's already a known chip
            if (angular.isObject(chip)) {
                return chip;
            }
            // Otherwise, create a new one
            return { FullName: chip }
        }
        function getSelectedInstructorsID() {
            $scope.course.Instructors.length = 0;
            $scope.instructor.selectedInstructors
                .map(function (value) {
                    $scope.course.Instructors.push(value.ID);
                });
        }
        function querySearch(query) {
            //console.log(query);
            var results = query ? $scope.instructor.items.filter(createFilterFor(query)) : $scope.instructor.items;
            return results;
        }
        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(instructor) {
                return (instructor.FullName.toLowerCase().indexOf(lowercaseQuery) > -1);
            }
        }

        loadDepartments();
        loadInstructor();

    }

})(angular.module('angularMaterial'));