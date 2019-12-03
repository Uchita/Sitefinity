; (function ($) {
    $(document).ready(function () {
        var populateDefaultItem = function () {
            var defaultElementIndex = 0;
            var firstImageElement = $('.o-imagegallery__imagelistitem').find('a')[defaultElementIndex];
            if (firstImageElement) {
                populateSelecteditem(firstImageElement);
            }
        };

        var populateSelecteditem = function (element, updateUrl) {
            $(element).addClass('is-selected');
            var item = $.parseJSON($(element).attr('data-item') || null);
            var selectedElementIndex = $(element).index();

            $('.o-imagegallery__selecteditem').find('img').attr('src', item.MediaUrl);
            $('.o-imagegallery__selecteditem').find('img').attr('title', item.Title);
            $('.o-imagegallery__selecteditem').find('img').attr('alt', item.AlternativeText);

            if (item.Width) {
                $('.o-imagegallery__selecteditem').find('img').attr("width", item.Width);
            }
            else {
                $('.o-imagegallery__selecteditem').find('img').removeAttr("width");
            }

            if (item.Height) {
                $('.o-imagegallery__selecteditem').find('img').attr("height", item.Height);
            }
            else {
                $('.o-imagegallery__selecteditem').find('img').removeAttr("height");
            }

            $('.o-imagegallery__hdg').html(item.Title);
            $('.o-imagegallery__desc').html(item.Description);
            $('.o-imagegallery__count').html(selectedElementIndex + 1);

            if (updateUrl) {
                var detailUrl = $(element).attr('data-detail-url');
                if (detailUrl) {
                    history.pushState(detailUrl, item.Title, detailUrl);
                }
            }
        };

        var removeCurrentlySelected = function () {
            var currentlySelected = $('.o-imagegallery__imagelistitem').find('a.is-selected');
            currentlySelected.removeClass('is-selected');
        };

        $('.o-imagegallery__imagelistitem').find('a').bind('click', function (e) {
            removeCurrentlySelected();
            populateSelecteditem(this, true);
        });

        $('.o-imagegallery__navigationprev').bind('click', function (e) {
            var currentlySelected = $('.o-imagegallery__imagelistitem').find('a.is-selected');
            if (currentlySelected && currentlySelected.length > 0) {
                var prevElement = currentlySelected.prev('a');
                if (prevElement && prevElement.length > 0) {
                    removeCurrentlySelected();
                    populateSelecteditem(prevElement, true);
                }
            }
        });

        $('.o-imagegallery__navigationnext').bind('click', function (e) {
            var currentlySelected = $('.o-imagegallery__imagelistitem').find('a.is-selected');
            if (currentlySelected && currentlySelected.length > 0) {
                var nextElement = currentlySelected.next('a');
                if (nextElement && nextElement.length > 0) {
                    removeCurrentlySelected();
                    populateSelecteditem(nextElement, true);
                }
            }
        });

        populateDefaultItem();

        window.addEventListener('popstate', function (e) {
            if (e.state) {
                var img = $('[data-detail-url="' + e.state + '"]');
                if (img.length > 0) {
                    populateSelecteditem(img[0]);
                }
            }
            else {
                populateDefaultItem();
            }
        });
    });
})(jQuery);