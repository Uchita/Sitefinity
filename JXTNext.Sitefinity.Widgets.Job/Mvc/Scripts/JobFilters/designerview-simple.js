(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {

        $scope.$watch('list', function (list) {
            $scope.properties.SerializedJobFilterModel.PropertyValue = angular.toJson(list, true);
        }, true);

      
        $scope.sortItems = function (e) {
            var element = $scope.list[e.oldIndex];
            $scope.list.splice(e.oldIndex, 1);
            $scope.list.splice(e.newIndex, 0, element);
            $scope.list[0].Title = $scope.list[0].Title;
        };

        $scope.isItemSelected = function (id) {
            if ($scope.selectedSocialItems) {
                for (var i = 0; i < $scope.selectedSocialItems.length; i++) {
                    if ($scope.selectedSocialItems[i].Id === id) {
                        return true;
                    }
                }
            }

            return false;
        };

        $scope.itemClicked = function (item) {
            if (!$scope.selectedSocialItems) {
                $scope.selectedSocialItems = [];
            }

            var selectedItemIndex;
            var alreadySelected = false;
            for (var i = 0; i < $scope.selectedSocialItems.length; i++) {
                if ($scope.selectedSocialItems[i].Id === item.Id) {
                    selectedItemIndex = i;
                    alreadySelected = true;
                    break;
                }
            }

            if (alreadySelected) {
                $scope.selectedSocialItems.splice(selectedItemIndex, 1);
            }
            else {
                $scope.selectedSocialItems.push(item);
            }
        };

        $scope.sortableOptions = {
            hint: function (element) {
                return $('<div class="sf-backend-wrp"><div class="list-group-item list-group-item-multiselect list-group-item-draggable list-group-item-hint">' +
                    element.html() +
                    '</div></div>');
            },
            placeholder: function (element) {
                return $('<div class="list-group-item list-group-item-placeholder"></div>');
            },
            handler: ".handler",
            axis: "y"
        };

        propertyService.get()
            .then(function (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);

                $scope.list = $.parseJSON($scope.properties.SerializedJobFilterModel.PropertyValue);
            });
    }]);
})(jQuery);