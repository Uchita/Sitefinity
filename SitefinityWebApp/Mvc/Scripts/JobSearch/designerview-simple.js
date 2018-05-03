(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('expander');

    angular.module('designer').controller('SimpleCtrl', ['$scope', '$http', 'propertyService', function ($scope, $http, propertyService) {
        $scope.rows = [];

        $scope.$watch('rows',
            function (newVal, oldVal) {
                if ($scope.properties != undefined)
                    $scope.properties.SerializedJobSearchParams.PropertyValue = angular.toJson(newVal, true);
            },
            true
        );

        $scope.$watch('properties.CssClass.PropertyValue',
            function (newVal, oldVal) {
                if (newVal)
                    $scope.properties.CssClass.PropertyValue = newVal;
            }
        );

        $scope.addNewRow = function () {
            var newRowId = $scope.rows.length + 1;
            var newRow = { 'RowId': newRowId, 'ControlType': '', 'FilterType': $scope.FilterTypes[0], DefaultValue: '', PlaceholderText: '', Data: $scope.DataValues[0] };
            $scope.rows.push(newRow);
            //$scope.processLevels(0, newItemNo);
            $scope.properties.SerializedJobSearchParams.PropertyValue = angular.toJson($scope.rows);
        };

        $scope.removeRow = function (id) {
            $scope.rows.splice($scope.rows.findIndex(item => item.RowId === id), 1);
            $scope.properties.SerializedJobSearchParams.PropertyValue = angular.toJson($scope.rows);
        };

        $scope.processSubLevels = function (items, level, rowId) {
            var listIndex = $scope.rows.findIndex(item => item.RowId === rowId);
            for (var j = 0; j < items.length; j++) {
                if (items[j]["Data"] != null || items[j]["Data"] != undefined)
                    $scope.processSubLevels(items[j]["Data"], level + 1, rowId);
            }
        };

        $scope.processLevels = function (key, rowId) {
            if ($scope.jobSearchList.JobSearchParams[key].Data != null || $scope.jobSearchList.JobSearchParams[key].Data != undefined) {
                $scope.processSubLevels($scope.jobSearchList.JobSearchParams[key].Data, 1, rowId);
            }
        };

        $scope.onFilterChange = function (row) {
            if (row.FilterType != null && row.FilterType != undefined) {
                $scope.rows[$scope.rows.findIndex(item => item.RowId === row.RowId)].Data = [];
                $scope.processLevels($scope.FilterTypes.indexOf(row.FilterType), row.RowId);
                $scope.rows[$scope.rows.findIndex(item => item.RowId === row.RowId)].Data = $scope.DataValues[$scope.FilterTypes.indexOf(row.FilterType)];

            }
        };

        $scope.clickValuesMulti = function (t, event) {
            event.stopImmediatePropagation();
        };
        $scope.clickEvent = function (t, e) {
            if (t.Selected) {
                t.Selected = false;
            }
            else {
                t.Selected = true;

            }
            e.stopPropagation();
        };

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                if ($scope.properties.SerializedJobSearchParams.PropertyValue != '') {
                    $scope.rows = $.parseJSON($scope.properties.SerializedJobSearchParams.PropertyValue);
                }
            });

        $http.get('/Frontend-Assembly/SitefinityWebApp/Mvc/Views/JobSearch/JobSearchMockData.json').then(function (response) {
            $scope.jobSearchList = response.data;

            $scope.componentTypeList = ["TextBox", "DropDown Single", "DropDown Multi", "Map Search"];
            $scope.FilterTypes = [];
            $scope.DataValues = [];
            for (var k = 0; k < $scope.jobSearchList.JobSearchParams.length; k++) {
                $scope.FilterTypes.push($scope.jobSearchList.JobSearchParams[k].Label);
                $scope.DataValues.push($scope.jobSearchList.JobSearchParams[k].Data);
            }


            $scope.ddl2Value = $scope.FilterTypes[0];
            if ($scope.rows.length == 0) {
                $scope.rows = [
                    {
                        RowId: 1,
                        ControlType: '',
                        FilterType: $scope.FilterTypes[0],
                        DefaultValue: '',
                        PlaceholderText: '',
                        Data: $scope.DataValues[0]
                    }
                ];

                $scope.categories = [];
                $scope.categories = $scope.jobSearchList.JobSearchParams[0].Data;

            }
        });
    }]);
})(jQuery);