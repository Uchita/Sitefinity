$(document).ready(function ($) {

    // hide initial values before form interaction
    $('.myCheckbox').prop('checked', true);

    if ($("#rbUploadResume").prop("checked")) {
        $('.boardy-upload-resume').css('display', 'block');
        $('.boardy-select-profile-resume').css('display', 'none');
    }

    if ($("#rbExistingResume").prop("checked")) {
        $('.boardy-upload-resume').css('display', 'none');
        $('.boardy-select-profile-resume').css('display', 'block');
    }

    if ($("#rbUseMyProfile").prop("checked")) {
        $('.boardy-upload-resume').css('display', 'none');
        $('.boardy-select-profile-resume').css('display', 'none');
    }

    if ($("#rbUploadCoverLetter").prop("checked")) {
        $('.boardy-upload-coverletter').css('display', 'block');
        $('.boardy-write-coverletter').css('display', 'none');
        $('.boardy-select-profile-coverletter').css('display', 'none');
    }

    if ($("#rbWriteOneNow").prop("checked")) {
        $('.boardy-upload-coverletter').css('display', 'none');
        $('.boardy-write-coverletter').css('display', 'block');
        $('.boardy-select-profile-coverletter').css('display', 'none');
    }

    if ($("#rbExistingCoverLetter").prop("checked")) {
        $('.boardy-upload-coverletter').css('display', 'none');
        $('.boardy-write-coverletter').css('display', 'none');
        $('.boardy-select-profile-coverletter').css('display', 'block');
    }


    $('.boardy-apply-register').css('display', 'block');
    $('.boardy-coverletter-options').css('display', 'block');

    $('#cvNoResume').css('display', 'none');


    // Show hide logic for apply options

    $('.boardy-apply-options input:radio').click(function () {

        // Login & apply
        if ($(this).val() === 'apply2') {
            $('.boardy-apply-login-option').css('display', 'block');
            $('.boardy-apply-register').css('display', 'none');
            $('.boardy-coverletter-options').css('display', 'block');
            $('.boardy-resume-options').css('display', 'block');
            $('#cvUseExiting').css('display', 'block');
            $('#cvUseProfile').css('display', 'block');
            $('#cvNoResume').css('display', 'none');
            $('#clUseExisting').css('display', 'block');
            $('#cvRadios-2').removeAttr('required');
            $('#firstname').removeAttr('required');
            $('#lastname').removeAttr('required');
            $('#email').removeAttr('required');
            $('#passwordReg').removeAttr('required');
            $('#passwordRegConfirm').removeAttr('required');
        }
        // Quick Register & Apply
        if ($(this).val() === 'apply3') {
            $('.boardy-apply-login-option').css('display', 'none');
            $('.boardy-apply-register').css('display', 'block');
            $('.boardy-resume-options').css('display', 'block');
            $('.boardy-coverletter-options').css('display', 'block');
            $('#cvUseExiting').css('display', 'none');
            $('#cvUseProfile').css('display', 'none');
            $('#clUseExisting').css('display', 'none');
            $('#cvNoResume').css('display', 'block');
            $('#cvRadios-2').attr('required', true);
            $('#firstname').attr('required', true);
            $('#lastname').attr('required', true);
            $('#email').attr('required', true);
            $('#phone').attr('required', true);
            $('#passwordReg').attr('required', true);
            $('#passwordRegConfirm').attr('required', true);
        }
    });


    // show hide logic for cover letter

    $('.boardy-coverletter-options input:radio').click(function () {

        if ($(this).val() === 'coverletter1') {
            $('.boardy-upload-coverletter').css('display', 'block');
            $('.boardy-write-coverletter').css('display', 'none');
            $('.boardy-select-profile-coverletter').css('display', 'none');
            $('#divCoverLetterFormatNotValid').hide();

        }
        if ($(this).val() === 'coverletter2') {
            $('.boardy-upload-coverletter').css('display', 'none');
            $('.boardy-write-coverletter').css('display', 'block');
            $('.boardy-select-profile-coverletter').css('display', 'none');
            $('#divCoverLetterFormatNotValid').hide();
        }

        if ($(this).val() === 'coverletter3') {
            $('.boardy-upload-coverletter').css('display', 'none');
            $('.boardy-write-coverletter').css('display', 'none');
            $('.boardy-select-profile-coverletter').css('display', 'block');
            $('#divCoverLetterFormatNotValid').hide();
        }

    });

    // show hide logic for resume

    $('.boardy-resume-options input:radio').click(function () {

        if ($(this).val() === 'resume1') {
            $('.boardy-upload-resume').css('display', 'none');
            $('.boardy-select-profile-resume').css('display', 'none');

            $('#pResumeRequired').hide();
        }

        if ($(this).val() === 'resume2') {
            $('.boardy-upload-resume').css('display', 'block');
            $('.boardy-select-profile-resume').css('display', 'none');

            $('#pResumeRequired').hide();
        }

        if ($(this).val() === 'resume3') {
            $('.boardy-upload-resume').css('display', 'none');
            $('.boardy-select-profile-resume').css('display', 'block');

            $('#pResumeRequired').hide();
        }

        if ($(this).val() === 'resume4') {
            $('.boardy-upload-resume').css('display', 'none');
            $('.boardy-select-profile-resume').css('display', 'none');

            $('#pResumeRequired').hide();
        }

    });

});

$(document).on('click', '.regtrigger', function (event) {
    event.preventDefault();
    var target = "#registerSec";
    $('html, body').animate({
        scrollTop: $(target).offset().top
    }, 1000);
});