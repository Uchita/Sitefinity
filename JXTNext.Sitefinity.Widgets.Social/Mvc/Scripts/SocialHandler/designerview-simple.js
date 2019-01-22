(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {

       
        $scope.$watch('properties.CssClass.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.CssClass.PropertyValue = newVal;
            }
        );

        $scope.$watch(
            'properties.AdvertiserEmailTemplateName.PropertyValue',
            function (newVal, oldVal) {
                if (!!newVal && newVal !== oldVal) {
                    $scope.properties.AdvertiserEmailTemplateName.PropertyValue = JSON.stringify(newVal);
                }
            },
            true
        );

        $scope.$watch(
            'properties.AdvertiserEmailTemplateId.PropertyValue',
            function (newVal, oldVal) {
                if (!!newVal && newVal !== oldVal) {
                    $scope.properties.AdvertiserEmailTemplateId.PropertyValue = newVal;
                }
            },
            true
        );


        $scope.$watch(
            'properties.EmailTemplateName.PropertyValue',
            function (newVal, oldVal) {
                if (!!newVal && newVal !== oldVal) {
                    $scope.properties.EmailTemplateName.PropertyValue = JSON.stringify(newVal);
                }
            },
            true
        );

        $scope.$watch(
            'properties.EmailTemplateId.PropertyValue',
            function (newVal, oldVal) {
                if (!!newVal && newVal !== oldVal) {
                    $scope.properties.EmailTemplateId.PropertyValue = newVal;
                }
            },
            true
        );

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
            });
    }]);
})(jQuery);