(function ($) {
    $(function () {
        $('[data-sf-role="login-status-button"]').on('click', function () {

            if ($('[data-sf-role="sf-allow-windows-sts-login"]').val().toLowerCase() === 'true') {
                location.href = '?stsLogin=true';
            } else {
                location.href = $('[data-sf-role="sf-login-redirect-url"]').val() || '#';
            }
            return false;
        });

        if ($('[data-sf-role="sf-is-design-mode-value"]').val().toLowerCase() !== 'true') {
            $.ajax({
                url: $('[data-sf-role="sf-status-json-endpoint-url"]').val(),
                cache: false,
                success: function (statusViewModel) {
                    if (statusViewModel && statusViewModel.IsLoggedIn) {
                        sessionStorage.setItem('loggedIn', true);
                        var loggedInView = $('[data-sf-role="sf-logged-in-view"]');
                        loggedInView.find('[data-sf-role="sf-logged-in-avatar"]').attr('src', statusViewModel.AvatarImageUrl).attr('alt', statusViewModel.DisplayName);
                        loggedInView.find('[data-sf-role="sf-logged-in-name"]').html(statusViewModel.DisplayName);
                        loggedInView.find('[data-sf-role="sf-logged-in-email"]').html(statusViewModel.Email);
                        loggedInView.show();
                    }
                    else {
                        sessionStorage.removeItem('loggedIn');
                        if (sessionStorage.getItem('loggedIn') !== 'true' && window.location.href.indexOf('jobseeker-profile') > -1) {
                            window.location.assign(window.location.protocol + "//" + window.location.host);
                        }
                        $('[data-sf-role="sf-logged-out-view"]').show();
                    }
                }
            });
        }
        else {
            sessionStorage.removeItem('loggedIn');
            if (sessionStorage.getItem('loggedIn') !== 'true' && window.location.href.indexOf('jobseeker-profile') > -1) {
                window.location.assign(window.location.protocol + "//" + window.location.host);
            }
            $('[data-sf-role="sf-logged-out-view"]').show();
        }
    });
}(jQuery));