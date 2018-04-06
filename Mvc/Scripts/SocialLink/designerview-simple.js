(
    function ($) {

        // This module is required for using the Expander in our designer form 
        // To accpet the CSS Classes from More Options
        angular.module('designer').requires.push('expander');

        // Here 'SimpleCtrl' is the our view name plus Ctrl
        // Our view name here is 'Simple'
        angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
            $scope.$watch('properties.FbUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.FbUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsFbEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsFbEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.TwitterUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.TwitterUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsTwitterEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsTwitterEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.LinkedInUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.LinkedInUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsLinkedInEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsLinkedInEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.MailToUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.MailToUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsMailToEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsMailToEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.GooglePlusUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.GooglePlusUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsGooglePlusEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsGooglePlusEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.YouTubeUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.YouTubeUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsYouTubeEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsYouTubeEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.InstagramUrl.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.InstagramUrl.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.IsInstagramEnabled.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.IsInstagramEnabled.PropertyValue = newVal;
                }
            );

            $scope.$watch('properties.CssClass.PropertyValue',
                function (newVal, oldVal) {
                    if (newVal)
                        $scope.properties.CssClass.PropertyValue = newVal;
                }
            );

            propertyService.get()
                .then(function (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);
                })
        }]);
    }
)(jQuery);