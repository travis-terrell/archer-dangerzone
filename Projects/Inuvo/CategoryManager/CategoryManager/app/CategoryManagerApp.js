(function() {

    var app = angular.module('categoryManagerApp', []);

    app.controller('categoryController', function($scope) {
        $scope.models = {
            helloAngular: 'I work!'
        };
    
        categoryController.$inject = ['$scope'];
    });



})();2