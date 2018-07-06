(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('expander', 'sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.jobTypes = [];
        $scope.totalJobTypes = [];
        $scope.$watch('jobTypes',
            function (newVal, oldVal) {
                if ($scope.properties != undefined)
                    $scope.properties.SerializedJobTypes.PropertyValue = angular.toJson(newVal, true);
            },
            true
        );

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
                for (var i = 0; i < $scope.jobTypes.length; i++) {
                    $scope.jobTypes[i].Selected = false;
                }
            }
            else {
              $scope.jobTypes[0].Selected = true;
            }
        };

       $scope.jobTypeChange = function (jobType) {
            if (!$scope.isJobTypeSelected())
                $scope.properties.IsAllJobs.PropertyValue = true;
        };

        $scope.isJobTypeSelected = function () {
            var isSelected = false;
            for (var i = 0; i < $scope.jobTypes.length; i++) {
                if ($scope.jobTypes[i].Selected == true) {
                    isSelected = true;
                    break;
                }
            }
            return isSelected;
        };

      
        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                if ($scope.properties.PageSize.PropertyValue === null || $scope.properties.PageSize.PropertyValue === 'undefined' || $scope.properties.PageSize.PropertyValue === '')
                    $scope.properties.PageSize.PropertyValue = 5;

                if ($scope.properties.SerializedJobTypes.PropertyValue != '' && $scope.properties.SerializedJobTypes.PropertyValue != 'undefined') {
                    $scope.jobTypes = $.parseJSON($scope.properties.SerializedJobTypes.PropertyValue);
                }
                if ($scope.properties.SerializedTotalJobTypes.PropertyValue != '' && $scope.properties.SerializedTotalJobTypes.PropertyValue != 'undefined') {
                    $scope.totalJobTypes = $.parseJSON($scope.properties.SerializedTotalJobTypes.PropertyValue);
                }

                if ($scope.jobTypes == 'null' || $scope.jobTypes == 'undefined' || $scope.jobTypes.length == 0) {
                    for (var i = 0; i < $scope.totalJobTypes.length; i++) {
                        $scope.jobTypes.push({ ID: $scope.totalJobTypes[i].ID, Label: $scope.totalJobTypes[i].Label, Selected: false });
                    }
                    if (!$scope.isJobTypeSelected())
                        $scope.properties.IsAllJobs.PropertyValue = true;
                }

                 if ($scope.properties.IsAllJobs.PropertyValue == "True")
                    $scope.properties.IsAllJobs.PropertyValue = true;
                else
                    $scope.properties.IsAllJobs.PropertyValue = false;

                if ($scope.totalJobTypes == 'null' || $scope.totalJobTypes == 'undefined' || $scope.totalJobTypes.length == 0) {
                    $scope.properties.IsAllJobs.PropertyValue = true;
                    $scope.jobTypes = [];
                }
            });
    }]);
})(jQuery);