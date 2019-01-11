(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('ngAutocomplete');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.rows = [];

        $scope.$watch('rows',
            function (newVal, oldVal) {
                if ($scope.properties != undefined)
                    $scope.properties.SerializedMapsParams.PropertyValue = angular.toJson(newVal, true);
            },
            true
        );

        $scope.addNewRow = function () {
            var newRowId = $scope.rows.length + 1;
            var newRow = { 'RowId': newRowId, 'ID': '', 'Address': '', 'AddressLat': '', 'AddressLng': '','MarkerIconPath': '', 'PopupTitle': '', 'PopupText': '', 'PopupAdditionalInfo': ''};
            $scope.rows.push(newRow);
            $scope.properties.SerializedMapsParams.PropertyValue = angular.toJson($scope.rows);
        };

        $scope.removeRow = function (id) {
            $scope.rows.splice($scope.rows.findIndex(item => item.RowId === id), 1);
            $scope.properties.SerializedMapsParams.PropertyValue = angular.toJson($scope.rows);
        };

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);
                if ($scope.properties.SerializedMapsParams.PropertyValue != '' && $scope.properties.SerializedMapsParams.PropertyValue != 'undefined') {
                    $scope.rows = $.parseJSON($scope.properties.SerializedMapsParams.PropertyValue);
                }

                if ($scope.properties.ZoomLevel.PropertyValue === null || $scope.properties.ZoomLevel.PropertyValue === 'undefined' || $scope.properties.ZoomLevel.PropertyValue === '')
                    $scope.properties.ZoomLevel.PropertyValue = 10;

                if ($scope.rows.length == 0) {
                    $scope.rows = [
                        {
                            RowId: 1,
                            ID: '',
                            Address: '',
                            MarkerIconPath: '',
                            PopupTitle: '',
                            PopupText: '',
                            PopupAdditionalInfo:''
                        }
                    ];
                }
          });
    }]);
})(jQuery);