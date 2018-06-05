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

        $scope.allJobsChange = function () {
            if ($scope.properties.IsAllJobs.PropertyValue == true) {
                $scope.properties.IsPremiumJobs.PropertyValue = false;
                $scope.properties.IsStandoutJobs.PropertyValue = false;
            }
            else {
                $scope.properties.IsPremiumJobs.PropertyValue = true;
            }
        };

        $scope.premiumJobsChange = function () {
            if ($scope.properties.IsPremiumJobs.PropertyValue == true)
                $scope.properties.IsAllJobs.PropertyValue = false;
            else if ($scope.properties.IsStandoutJobs.PropertyValue == false)
                $scope.properties.IsAllJobs.PropertyValue = true;
        };

        $scope.standoutJobsChange = function () {
            if ($scope.properties.IsStandoutJobs.PropertyValue == true)
                $scope.properties.IsAllJobs.PropertyValue = false;
            else if ($scope.properties.IsPremiumJobs.PropertyValue == false)
                $scope.properties.IsAllJobs.PropertyValue = true;
        };

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                if ($scope.properties.PageSize.PropertyValue === null || $scope.properties.PageSize.PropertyValue === 'undefined' || $scope.properties.PageSize.PropertyValue === '')
                    $scope.properties.PageSize.PropertyValue = 5;

                if ($scope.properties.IsAllJobs.PropertyValue != "True" && $scope.properties.IsPremiumJobs.PropertyValue != "True" && $scope.properties.IsStandoutJobs.PropertyValue != "True")
                    $scope.properties.IsAllJobs.PropertyValue = true;

                if ($scope.properties.IsAllJobs.PropertyValue == "True")
                    $scope.properties.IsAllJobs.PropertyValue = true;
                else
                    $scope.properties.IsAllJobs.PropertyValue = false;

                if ($scope.properties.IsPremiumJobs.PropertyValue == "True")
                    $scope.properties.IsPremiumJobs.PropertyValue = true;
                else
                    $scope.properties.IsPremiumJobs.PropertyValue = false;

                if ($scope.properties.IsStandoutJobs.PropertyValue == "True")
                    $scope.properties.IsStandoutJobs.PropertyValue = true;
                else
                    $scope.properties.IsStandoutJobs.PropertyValue = false;
            });
    }]);
})(jQuery);