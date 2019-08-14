(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('expander', 'sfSelectors');

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
            var newRow = { 'RowId': newRowId, 'ID':'', 'ControlType': '', 'FilterType': '', DefaultValue: '', PlaceholderText: '', Filters: [] };
            $scope.rows.push(newRow);
            $scope.properties.SerializedJobSearchParams.PropertyValue = angular.toJson($scope.rows);
        };

        $scope.removeRow = function (id) {
            $scope.rows.splice($scope.rows.findIndex(item => item.RowId === id), 1);
            $scope.properties.SerializedJobSearchParams.PropertyValue = angular.toJson($scope.rows);
        };

        $scope.processSubLevels = function (items, level, rowId) {
            var listIndex = $scope.rows.findIndex(item => item.RowId === rowId);
            for (var j = 0; j < items.length; j++) {
                if (items[j]["Filters"] != null || items[j]["Filters"] != undefined)
                    $scope.processSubLevels(items[j]["Filters"], level + 1, rowId);
            }
        };

        $scope.processLevels = function (key, rowId) {
            if ($scope.jobSearchList.JobSearchParams[key].Filters != null || $scope.jobSearchList.JobSearchParams[key].Filters != undefined) {
                $scope.processSubLevels($scope.jobSearchList.JobSearchParams[key].Filters, 1, rowId);
            }
        };

        $scope.processSubLevelsIds = function (items, level, parentId) {
            for (var j = 0; j < items.length; j++) {
                items[j].Level = "level_" + level;
                items[j].Show = false;
                items[j].ParentId = parentId;
                if (items[j]["Filters"] != null || items[j]["Filters"] != undefined)
                    $scope.processSubLevelsIds(items[j]["Filters"], level + 1, items[j].ID);
            }
        };

        $scope.processLevelsIds = function () {
            for (var i = 0; i < $scope.DataValues.length;i++) {
                $scope.processSubLevelsIds($scope.DataValues[i], 1, "");
            }
         };

        $scope.onFilterChange = function (row) {
            if (row.FilterType != null && row.FilterType != undefined) {
                $scope.rows[$scope.rows.findIndex(item => item.RowId === row.RowId)].Filters = [];
                var index = $scope.FilterTypes.indexOf(row.FilterType);
                $scope.rows[$scope.rows.findIndex(item => item.RowId === row.RowId)].Filters = $scope.DataValues[index];
                $scope.rows[$scope.rows.findIndex(item => item.RowId === row.RowId)].ID = $scope.RootIdValues[index];

            }
        };

        var resolveIsSelected = function (item) {
            if (item.Show) {
                return true;
            }
            else if (item.Filters != undefined) {
                var flag = false;
                for (var i = 0; i < item.Filters.length; i++) {
                    flag = resolveIsSelected(item.Filters[i]);
                    if (flag)
                        return flag;
                }
            }
            else {
                return false;
            }
        };

        $scope.isSelected = function (item) {
                 return resolveIsSelected(item);
        };

        $scope.clickValuesMulti = function (t, event) {
            event.stopImmediatePropagation();
        };
        $scope.clickEvent = function (t, e) {
            if (t.Show) {
                t.Show = false;
            }
            else {
                t.Show = true;

            }
            e.stopPropagation();
        };

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                if ($scope.properties.SerializedJobSearchParams.PropertyValue != '' && $scope.properties.SerializedJobSearchParams.PropertyValue != 'undefined') {
                    $scope.rows = $.parseJSON($scope.properties.SerializedJobSearchParams.PropertyValue);
                }
                if ($scope.properties.SerializedFilterData.PropertyValue != '' && $scope.properties.SerializedFilterData.PropertyValue != 'undefined') {
                    $scope.filterDataList = $.parseJSON($scope.properties.SerializedFilterData.PropertyValue);
                }

                $scope.componentTypeList = ["TextBox", "DropDown Single", "DropDown Multi", "Map Search", "List"];
                $scope.FilterTypes = [];
                $scope.RootIdValues = [];
                $scope.DataValues = [];

                for (var i = 0; i < $scope.filterDataList.length; i++) {
                    $scope.FilterTypes.push($scope.filterDataList[i].Name);
                    $scope.RootIdValues.push($scope.filterDataList[i].ID);
                    $scope.DataValues.push($scope.filterDataList[i].Filters);
                }

                $scope.processLevelsIds();

                if ($scope.rows.length == 0) {
                    $scope.rows = [
                        {
                            RowId: 1,
                            ID: '',
                            ControlType: '',
                            FilterType: '',
                            DefaultValue: '',
                            PlaceholderText: '',
                            Filters: []
                        }
                    ];
                }
            });
   }]);
})(jQuery);