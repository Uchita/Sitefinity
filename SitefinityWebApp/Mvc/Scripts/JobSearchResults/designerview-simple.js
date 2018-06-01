(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('expander', 'sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {

        $scope.$watch('properties.CssClass.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.CssClass.PropertyValue = newVal;
            }
        );

        $scope.$watch('properties.Sorting.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.Sorting.PropertyValue = newVal;
            }
        );

        $scope.$watch('properties.DetailsPageId.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.DetailsPageId.PropertyValue = newVal;
            }
        );

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                if ($scope.properties.PageSize.PropertyValue === null || $scope.properties.PageSize.PropertyValue === 'undefined' || $scope.properties.PageSize.PropertyValue === '')
                    $scope.properties.PageSize.PropertyValue = 5;
            });
    }]);
})(jQuery);