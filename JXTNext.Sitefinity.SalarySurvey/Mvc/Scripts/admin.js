var salarySurveyAdmin = salarySurveyAdmin || {};

salarySurveyAdmin.initImport = function () {
    jQuery('.fileinput-button').each(function () {
        var button = jQuery(this);

        var wait = button.siblings('.wait');

        var container = button.closest('.entry-details');

        button.fileupload({
            dataType: 'json',
            url: SalarySurvey_CurrentPage + '/Import',
            dropZone: null,
            pasteZone: null,

            submit: function (e, data) {
                hideError(container);
                hideMessage(container);

                if (button.hasClass('disabled')) {
                    return false;
                }

                data.formData = {};

                var elData;

                elData = button.data('taxonomy');
                if (elData != null) {
                    data.formData.taxonomy = elData;
                }

                wait.show();
            },

            progress: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);

                button.addClass('disabled');

                wait.find('.per').html(progress + '%');
            },

            done: function (event, data) {
                var response = data.result;

                if (response.success) {
                    var msg = '';

                    for (var i in response.messages.global) {
                        msg += response.messages.global[i] + "<br />";
                    }

                    if (msg == '') {
                        showMessage(container, 'File was successfully uploaded and processed.<br>' + response.imported + ' / ' + response.records + ' records were imported.', true, 30000);
                    }
                    else {
                        showMessage(container, msg, true, 30000);
                    }
                }
                else {
                    var msg = '';

                    for (var i in response.messages.global) {
                        msg += response.messages.global[i] + "<br />";
                    }

                    showError(container, msg, true, false);
                }
            },

            fail: function (e, data) {
                showError(container, 'An error occured while uploading your file.');
            },

            always: function (e, data) {
                button.removeClass('disabled');

                wait.hide();
            }
        });
    });
}

$(document).ready(function () {
    if ($('.salary-survey-widget-import-salaries').length != 0 || $('.salary-survey-widget-import-taxonomies').length != 0) {
        salarySurveyAdmin.initImport();
    }
});
