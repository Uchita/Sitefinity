(function ($) {

    var simpleViewModule = angular.module('simpleViewModule', ['expander', 'designer', 'ngSanitize']);
    angular.module('designer').requires.push('simpleViewModule');
    angular.module('designer').requires.push('sfFields');
    angular.module('designer').requires.push('sfSelectors');

    simpleViewModule.controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;
        $scope.showAddCardPopup = false;
        $scope.currentCard = {};
        $scope.currentCardSelectedImage = null;

        $scope.addCard = function () {
            if ($scope.showAddCardPopup)
                return;

            $scope.initializeCardState();

            $scope.showAddCardPopup = true;
        }
        
        $scope.doneAdding = function () {
            $scope.cards.push(objCopy($scope.currentCard));

            $scope.initializeCardState();

            $scope.showAddCardPopup = false;
        }

        $scope.cancelAdding = function () {
            $scope.initializeCardState();

            $scope.showAddCardPopup = false;
        }

        $scope.removeItem = function (index) {
            $scope.cards.splice(index, 1);
        };

        $scope.sortItems = function (e) {
            var element = $scope.cards[e.oldIndex];
            $scope.cards.splice(e.oldIndex, 1);
            $scope.cards.splice(e.newIndex, 0, element);
        };

        $scope.initializeCardState = function () {
            $scope.currentCard.Heading = null;
            $scope.currentCard.Description = null;
            $scope.currentCard.LinkedPageId = "00000000-0000-0000-0000-000000000000";
            $scope.currentCard.LinkedUrl = null;
            $scope.currentCard.IsPageSelectMode = true;
            $scope.currentCard.ActionName = null;
            $scope.currentCard.ImageId = "00000000-0000-0000-0000-000000000000";
            $scope.currentCard.ImageProviderName = null;

            $scope.currentCardSelectedImage = null;
        }

        $scope.sortableOptions = {
            hint: function (element) {
                return $('<div class="sf-backend-wrp"><div class="list-group-item-radio list-group-item list-group-item-draggable-2 list-group-item-hint list-group-item-hint-2">' +
                    element.html() +
                    '</div></div>');
            },
            placeholder: function (element) {
                return $('<div class="list-group-item list-group-item-placeholder list-group-item-placeholder-2"></div>');
            },
            handler: ".handler",
            axis: "y"
        };

        function objCopy(origin) {
            if (!origin)
                return origin;

            return JSON.parse(JSON.stringify(origin));
        }

        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);

                    var isPageSelectMode = $scope.properties.IsPageSelectMode.PropertyValue;
                    $scope.properties.IsPageSelectMode.PropertyValue = isPageSelectMode.toLowerCase() === "true";

                    if ($scope.properties.SerializedCardsList &&
                        $scope.properties.SerializedCardsList.PropertyValue) {
                        $scope.cards = JSON.parse($scope.properties.SerializedCardsList.PropertyValue);
                    }
                }
            },
                function (data) {
                    $scope.feedback.showError = true;
                    if (data)
                        $scope.feedback.errorMessage = data.Detail;
                })
            .then(function () {
                $scope.feedback.savingHandlers.push(function () {
                    $scope.properties.SerializedCardsList.PropertyValue = JSON.stringify($scope.cards);
                });
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });
    }]);
})(jQuery);
