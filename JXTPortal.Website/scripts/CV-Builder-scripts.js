!(function ($) {

    $(function () {
        // Form element Bootstrap class
        $('input:not([type=checkbox]):not([type=submit]):not([type=reset]):not([type=file]):not([type=image]):not([type=date]):not([type=radio]), select, textarea').addClass('form-control');
        $('input[type=submit]').addClass('btn btn-primary');
        $('input[type=reset]').addClass('btn btn-default');

        // Convert top menu to Boostrap Responsive menu
        $('.navbar .navbar-collapse ul').addClass('nav navbar-nav');
        $('.navbar .navbar-collapse > ul > li').has('ul').addClass('dropdown');
        $('.navbar .navbar-collapse > ul > li.dropdown > a').attr('data-toggle', 'dropdown').append('<b class="caret"></b>');
        $('.navbar .navbar-collapse > ul > li > ul').addClass('dropdown-menu');

        $('.multiselect').multiselect();

        $('#ddlArea').on('change', function () {
            $('#hfArea').val($('#ddlArea').val());
        });

        $('#ddlSubClassification').on('change', function () {
            $('#hfSubClassification').val($('#ddlSubClassification').val());
        });

        $('#ddlWorkType').on('change', function () {
            $('#hfWorkType').val($('#ddlWorkType').val());
        });

        $('input[maxlength], textarea[maxlength]').maxlength({
            alwaysShow: true,
            threshold: 20
        });

        $.fn.editable.defaults.mode = 'inline';
        $('.editable').editable();

        $('.editable-textarea').editable({
            type: 'textarea',
            rows: 10,
            mode: 'popup'
        });

        $('#CV-Builder #skillTags').tagsInput({
            'defaultText': 'type and press enter to add new'
        });

        var $validator = $("#aspnetForm").validate({
            rules: {
            }
        });

        $('#rootwizard').bootstrapWizard({
            'tabClass': 'nav nav-pills nav-justified',
            'nextSelector': '.wizard li.next2',
            onTabShow: function (tab, navigation, index) {
                var $total = navigation.find('li').length;
                var $current = index + 1;
                console.log($current);
                var $percent = ($current / $total) * 100;
                $('#rootwizard').find('.bar').css({ width: $percent + '%' });
                if ($current >= $total) {
                    $('#rootwizard').find('.pager .next2').hide();
                    $('#rootwizard').find('.pager .finish').show();
                    $('#rootwizard').find('.pager .finish').removeClass('disabled');
                } else {
                    $('#rootwizard').find('.pager .next2').show();
                    $('#rootwizard').find('.pager .finish').hide();
                }
            }
        });

        $('input[value="option-other"]').change(function () {
            if ($(this).is(':checked')) {
                $(this).parent().parent().next('div.othersfield').show();
            } else {
                $(this).parent().parent().next('div.othersfield').hide();
            }
        });

    });

})(jQuery);