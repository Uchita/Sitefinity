(function ($) {
    $(function () {
        /* dom class hooks */
        var $wrapper = $(".js-language-selector");

        if ($wrapper.length > 0) {
            /* event for the language selector inline links */
            $wrapper.on("click", "a", function (e) {
                var url;
                var $this = $(this);

                e.preventDefault();

                if ($this.data("culture")) {
                    redirect($this.data("culture"));
                }
            });

            /* event for the language selector dropdown */
            $wrapper.on("change", "select", function () {
                var url;
                var $this = $(this);

                if ($this.val()) {
                    redirect($this.val())
                }
            });

            /* redirect based on selected culture */
            function redirect(culture) {
                var url = $('[data-sf-role="' + culture + '"]').val();
                window.location = url;
            }
        }
    });
}(jq34));