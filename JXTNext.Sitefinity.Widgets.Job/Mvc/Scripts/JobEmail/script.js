var jobEmailWidget = jobEmailWidget || {};

(function ($) {
    function showHideFriendAction(list) {
        var group = list.closest('.form-group-Friends');

        if (list.find('.row').length > 1) {
            group.find('.col-action').show();
        }
        else {
            group.find('.col-action').hide();
        }
    }

    function showHideFriends(widget) {
        var group = widget.find('.form-group-Friends');

        if (widget.find('[name="EmailFriend"]').is(':checked')) {
            group.show();
        }
        else {
            group.hide();
        }
    }

    function updateFriendListIndex(list) {
        var idx = 0;
        var row;

        list.find('> .row').each(function () {
            row = $(this);

            row.find('.col-name input').attr('name', 'Friend[' + idx + '][Name]');
            row.find('.col-email input').attr('name', 'Friend[' + idx + '][Email]');

            idx++;
        });
    }

    jobEmailWidget.addFriend = function (btn) {
        btn = $(btn);

        var widget = btn.closest('.job-email-widget');
        if (widget.length == 0) {
            return;
        }

        var list = widget.find('.friends-list');

        var row = list.find('> .row');
        if (row.length == 0) {
            return;
        }
        else if (row.length >= parseInt(list.data('max'))) {
            alert('Maximum allowed friends is ' + list.data('max'));

            return;
        }

        row = $(row[0]).clone();
        row.find('input').val('');

        list.append(row);

        showHideFriendAction(list);
        updateFriendListIndex(list);
    }

    jobEmailWidget.removeFriend = function (btn) {
        btn = $(btn);

        var list = btn.closest('.friends-list');

        if (list.find('.row').length < 2) {
            alert('Cannot remove this friend. At least one is required.');

            return;
        }

        if (!confirm('Are you sure you want to remove this friend?')) {
            return;
        }

        btn.closest('.row').remove();

        showHideFriendAction(list);
        updateFriendListIndex(list);
    }

    $(function () {
        $('.job-email-widget').each(function () {
            var widget = $(this);

            widget.find('[name="EmailFriend"]').change(function () {
                showHideFriends(widget);
            });

            showHideFriends(widget);
        });
    });
})(jQuery);
