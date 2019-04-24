(function ($) {

    var simpleViewModule = angular.module('simpleViewModule', ['expander', 'designer', 'ngSanitize']);
    angular.module('designer').requires.push('simpleViewModule');
    angular.module('designer').requires.push('sfFields');
    angular.module('designer').requires.push('sfSelectors');

    simpleViewModule.controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;

        propertyService.get()
            .then(function (data) {
                if (!data) {
                    return;
                }

                $scope.properties = propertyService.toAssociativeArray(data.Items);

                var usePageTitle = $scope.properties.UsePageTitle.PropertyValue;
                $scope.properties.UsePageTitle.PropertyValue = usePageTitle.toLowerCase() === "true";

                var usePageDescription = $scope.properties.UsePageDescription.PropertyValue;
                $scope.properties.UsePageDescription.PropertyValue = usePageDescription.toLowerCase() === "true";

                var disableHeading = $scope.properties.DisableHeading.PropertyValue;
                $scope.properties.DisableHeading.PropertyValue = disableHeading.toLowerCase() === "false";

                var disableDescription = $scope.properties.DisableDescription.PropertyValue;
                $scope.properties.DisableDescription.PropertyValue = disableDescription.toLowerCase() === "false";

            },
            function (data) {
                $scope.feedback.showError = true;
                if (data)
                    $scope.feedback.errorMessage = data.Detail;
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });
    }]);
})(jQuery);