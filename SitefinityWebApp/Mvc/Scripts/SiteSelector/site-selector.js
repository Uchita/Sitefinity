(function ($) {
    $(function () {
        /* dom class hooks */
        var $wrapper = $(".js-site-selector");

        if ($wrapper.length > 0) {
            /* event for the site selector inline links */
            $wrapper.on("click", "a", function (e) {
                var $this = $(this);

                e.preventDefault();

                if ($this.data("url")) {
                    redirect($this.data("url"));
                }
            });

            /* event for the site selector dropdown */
            $wrapper.on("change", "select", function (e) {
                var $this = $(this);

                if ($this.val()) {
                    redirect($this.val())
                }
            });

            /* redirect based on selected url */
            function redirect(url) {
                window.location = url;
            }
        }
    });
}(jq34));