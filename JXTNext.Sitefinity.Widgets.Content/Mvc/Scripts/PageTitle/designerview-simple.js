(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('expander');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
      

        $scope.$watch('properties.CssClass.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.CssClass.PropertyValue = newVal;
            }
        );
       
        $scope.defaultChange = function () {
            $scope.properties.IsDefaultTitle.PropertyValue = true;
            $('#custom-text').hide();
        
        };

        $scope.customChange = function () {
            $scope.properties.IsDefaultTitle.PropertyValue = false;
            $('#custom-text').show();
        };
      
        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                
                if ($scope.properties.IsDefaultTitle.PropertyValue == "True") {
                    $scope.properties.IsDefaultTitle.PropertyValue = true;
                    $('#custom-text').hide();
                }
                else {
                    $scope.properties.IsDefaultTitle.PropertyValue = false;
                    $('#custom-text').show();
                }

            });
    }]);
})(jQuery);