(function ($) {
    $(function () {
        let $wrapper = $(".js-search-box-slide-out");

        if ($wrapper.length > 0) {
            // Grab all the data we need for this section
            let $trigger = $wrapper.find(".search-box-button-trigger");
            let $popout = $wrapper.find(".search-box-wrapper");
            let $searchTextBoxId = $(`[data-sf-role='searchTextBoxId']`).val();
            let $searchTextBox = $($searchTextBoxId);

            let resultsUrl = $(`[data-sf-role='resultsUrl']`).val();
            let indexCatalogue = $(`[data-sf-role='indexCatalogue']`).val();
            let wordsMode = $(`[data-sf-role='wordsMode']`).val();

            let $popoutOpen = false;

            // Listen for enter key
            $($searchTextBox).keyup((e) => {
                if (e.keyCode === 13) {
                    let searchText = $($searchTextBoxId).val().trim();
                    let location = getLocation(searchText, resultsUrl, indexCatalogue, wordsMode);

                    $popoutOpen = false;
                    navigateToResults(location);
                }
            });

            // Trigger to slide textbox area out
            $($trigger).click(() => {
                if ($popoutOpen) {
                    let searchText = $($searchTextBoxId).val().trim();
                    let location = getLocation(searchText, resultsUrl, indexCatalogue, wordsMode);

                    $popoutOpen = false;

                    if (searchText.length > 0)
                        navigateToResults(location);
                }
                else {
                    $($popout).addClass("active");
                    $($searchTextBoxId).focus();
                    $popoutOpen = true;
                }
            });

            // When clicking out of the textbox, slide back in.
            // TODO: Tie the focus out so it works on the whole wrapper so we don't get a blink on clicking the search button again
            $($searchTextBox).focusout(() => {
                $($popout).removeClass("active");
                setTimeout(() => $popoutOpen = false, 100);
            });
        }
    });
})(jq34);

/* Helper methods - Adapted from Sitefinity original code in DLL */
function navigateToResults(location) {
    window.location = location;
}

function getLocation(query, resultsUrl, indexCatalogue, wordsMode) {
    let separator = (resultsUrl.indexOf("?") == -1) ? "?" : "&";
    let catalogueParam = separator + "indexCatalogue=" + encodeURIComponent(indexCatalogue);
    let searchQueryParam = "&searchQuery=" + encodeURIComponent(query);
    let wordsModeParam = "&wordsMode=" + wordsMode;

    return resultsUrl + catalogueParam + searchQueryParam + wordsModeParam;
}
