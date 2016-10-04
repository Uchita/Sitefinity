!(function ($) {

    $(function () {

        // Form element Bootstrap class
        $('#customQuestions input:not([type=radio]):not([type=checkbox]):not([type=submit]):not([type=reset]):not([type=file]):not([type=image]):not([type=date]), #customQuestions select, #customQuestions textarea').addClass('form-control');
        $('#customQuestions input[type=submit]').addClass('btn btn-primary');
        $('#customQuestions input[type=reset]').addClass('btn btn-default');


        $('input[maxlength], textarea[maxlength]').maxlength({
            alwaysShow: true,
            threshold: 20
        });

        $(".sorted_table").sortable({
            containerSelector: 'table',
            itemPath: '> tbody',
            itemSelector: 'tr',
            placeholder: '<tr class="placeholder"/>'
        })
        // Sortable column heads
        var oldIndex
        $('.sorted_head tr').sortable({
            containerSelector: 'tr',
            itemSelector: 'th',
            placeholder: '<th class="placeholder"/>',
            vertical: false,
            onDragStart: function (item, group, _super) {
                oldIndex = item.index()
                item.appendTo(item.parent())
                _super(item)
            },
            onDrop: function (item, container, _super) {
                var field,
		    newIndex = item.index()

                if (newIndex != oldIndex)
                    item.closest('table').find('tbody tr').each(function (i, row) {
                        row = $(row)
                        field = row.children().eq(oldIndex)
                        if (newIndex)
                            field.before(row.children()[newIndex])
                        else
                            row.prepend(field)
                    })

                _super(item)
            }
        })

    });

})(jQuery);