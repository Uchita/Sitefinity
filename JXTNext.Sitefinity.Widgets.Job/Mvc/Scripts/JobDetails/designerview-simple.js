(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('expander', 'sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.$watch('roleList', function (roleList) {
            $scope.properties.SerializedJobDetailsRoles.PropertyValue = angular.toJson(roleList, true);
        }, true);

        $scope.$watch('properties.CssClass.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.CssClass.PropertyValue = newVal;
            }
        );

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                $scope.roleList = $.parseJSON($scope.properties.SerializedJobDetailsRoles.PropertyValue);
            });
    }]);
})(jQuery);