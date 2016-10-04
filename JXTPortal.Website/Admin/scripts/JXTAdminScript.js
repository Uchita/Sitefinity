function SelectAll(cbAll) {

    var targetAction = $(cbAll).is(':checked');

    $.each($('input[type=checkbox]'), function (prop, value) {

        if ($(value) != $(cbAll) ) {

                $(value).prop('checked', targetAction);

        }

    });
}