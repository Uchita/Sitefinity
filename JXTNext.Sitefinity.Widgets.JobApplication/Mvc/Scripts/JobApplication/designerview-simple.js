(function ($) {

    // This module is required for using the Expander in our designer form 
    // To accpet the CSS Classes from More Options
    // sfSelectors will be used for drag and drop select
    angular.module('designer').requires.push('sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {

        $scope.$watch('applyWithSocialMediaList', function (applyWithSocialMediaList) {
            $scope.properties.SerializedApplyWithSocialMedia.PropertyValue = angular.toJson(applyWithSocialMediaList, true);
        }, true);

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

        $scope.sortItems = function (e) {
            var element = $scope.applyWithSocialMediaList[e.oldIndex];
            $scope.applyWithSocialMediaList.splice(e.oldIndex, 1);
            $scope.applyWithSocialMediaList.splice(e.newIndex, 0, element);
            $scope.applyWithSocialMediaList[0].Title = $scope.applyWithSocialMediaList[0].Title;
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
                $scope.applyWithSocialMediaList = $.parseJSON($scope.properties.SerializedApplyWithSocialMedia.PropertyValue);
            });
    }]);
})(jQuery);