(function () {
    // The 'sfSelectors' module needs to be pushed into the 'designer' module.
    // The 'designer' module is the module that is responsible for the current widget designer.
    angular.module('designer').requires.push('sfSelectors');

    angular.module('designer')
        .controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {           
            propertyService
                .get()
                .then(function (data) {
                    if (data) {
                        // Get all widget controller properties
                        $scope.properties = propertyService.toAssociativeArray(data.Items);
                    }
                });
        }]);
}());
