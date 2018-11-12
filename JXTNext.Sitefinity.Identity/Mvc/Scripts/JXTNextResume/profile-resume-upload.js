(function ($) {
    $(function () {
       
        var resumes;
        
        var resumeInput = $('[data-sf-role=profile-resume-attachment-upload]');

        resumeInput.on('change', function (e) {
            resumes = e.target.files;
        });

        $('[data-sf-role=profile-resume-attachment-upload]').click(function () {
            resumeInput.click();
        });

        $("#myFile").change(function () {
            if ($(this).val()) {
                $("#uploadBtn").prop("disabled", false);
            }
            else {
                $("#uploadBtn").prop("disabled", true);
            }
        });


        $('[data-sf-role=profile-resume-delete]').click(function (event) {
            var model = {};
            model.id = $('.myModelId').val();
            model.fileName = $('.myModelFileName').val();
            model.attachmentType = $('.myModelAttachmentType').val();
            var urlPath = $(location).attr('pathname') + "/DeleteResume";
            $.ajax({
                url: urlPath,
                type: 'DELETE',
                data: '{deleteResumeFileItem: ' + JSON.stringify(model) + '}',
                cache: false,
                dataType: 'json',
                processData: false, // Don't process the files
                contentType: false, // Set content type to false as jQuery will tell the server its a query string request
                success: function (data) {
                    //console.log('success response: ' + response);
                },
                error: function (data) {
                    //console.log('error response: ' + response);
                }
            });
        });
        
        $('[data-sf-role=profile-resume-attachment-save]').click(function (event) {
            
            event.stopPropagation();
            event.preventDefault();

            // START A LOADING SPINNER HERE

            // Create a formdata object and add the files
            var data = new FormData();
            $.each(resumes, function (key, value) {
                data.append(key, value);
            });

            var urlPath = $(location).attr('pathname') + "/UploadResume";
            $.ajax({
                url: urlPath,
                type: 'POST',
                data: data,
                cache: false,
                dataType: 'json',
                processData: false, // Don't process the files
                contentType: false, // Set content type to false as jQuery will tell the server its a query string request
                success: function (data) {
                    //console.log('success response: ' + response);
                    console.log(data);
                },
                error: function (data) {
                    //console.log('error response: ' + response);
                    console.log(data);
                }
            });
        });

       
    });
}(jQuery));