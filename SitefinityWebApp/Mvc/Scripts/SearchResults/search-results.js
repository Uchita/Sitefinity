(function ($) {
    $(function () {
        let $wrapper = $(".js-search-results");

        if ($wrapper.length > 0) {
            // Grab all the data we need for this section
            let $trigger = $(".o-search-results-list-item");

            // Trigger to activate search funciton
            $($trigger).click((e) => {
                let location = $(e.currentTarget).find("input[name='o-search-results-list-item-link']").val();
                
                navigateToLink(location);
            });
        }
    });
})(jq34);

function navigateToLink(location) {
    window.location = location;
}
