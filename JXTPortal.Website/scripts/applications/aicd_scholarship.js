var requesting = false;
//var tabHasModified = false;
var isEditing = false;

!(function ($) {

    $(function () {

        $("textarea.maxtwohundred").textareaCounter({
            limit: 200
        });
        $("textarea.maxthreehundred").textareaCounter({
            limit: 300
        });


        $('.dropdown-toggle').dropdown();

        // Form element Bootstrap class
        $('#customApplication input:not([type=radio]):not([type=checkbox]):not([type=submit]):not([type=reset]):not([type=file]):not([type=image]):not([type=date]), #customApplication select, #customApplication textarea').addClass('form-control');
        $('#customApplication input[type=submit]').addClass('btn btn-primary');
        $('#customApplication input[type=reset]').addClass('btn btn-default');

        $('.multiselect').multiselect({
            maxHeight: 200
        });

        /*
        $('input[maxlength], textarea[maxlength]').maxlength({
        alwaysShow: true,
        threshold: 20
        });*/

        $('#rootwizard').bootstrapWizard({
            'tabClass': 'nav nav-pills nav-justified',
            'onPrevious': function () {
                if (isEditing)
                    return false;

                // Remove the save draft saved tick box
                $('li.draft').removeClass('saved');

                ClearErrorMessages();

                //scroll to top animation
                $("html, body").animate({ scrollTop: "0" });
                return true;
            },

            'onNext': function (tab, navigation, index) {
                //prevent next button to work when is editing
                if (isEditing)
                    return false;

                // Remove the save draft saved tick box
                $('li.draft').removeClass('saved');

                if (!requesting) {
                    requesting = true;

                    var callerObj;
                    var callerObjRef;

                    if (index == 7) //last tab, ie submit app button
                    {
                        callerObj = $("#finishTabBtn");
                        callerObjRef = $("#finishTabBtn");
                    }
                    else {
                        callerObj = $("#nextTabBtn");
                        callerObjRef = $("#nextTabBtn");
                    }

                    var loading = ReplaceObjectWithLoading(callerObj);

                    switch (index) {
                        case 1:
                            /*UpdateUpToSteps(2);
                            $(loading).replaceWith(callerObjRef);
                            requesting = false;
                            return true;*/
                            return Page1Submit(loading, callerObjRef);
                        case 2:
                            return Page2Submit(loading, callerObjRef);
                        case 3:
                            return Page3Submit(loading, callerObjRef);
                        case 4:
                            return Page4Submit(loading, callerObjRef);
                        case 5:
                            return Page5Submit(loading, callerObjRef);
                            /*case 6:
                            return Page6Submit(loading, callerObjRef);*/
                        case 6:
                            return Page7Submit(loading, callerObjRef);
                        case 7:
                            return DynamicFormSubmit(loading, callerObjRef);

                            return false;
                    }

                    return true;
                }
                else
                    return false;

            },
            'onTabClick': function (tab, navigation, currentIndex, clickedIndex) {
                /*if (tabHasModified) {
                alert("Unsaved changes detected. Click on the next button to save your changes.");
                return false;
                }

                //clickedIndex starts from 0
                var tabID = "#tab" + (clickedIndex + 1) + "Trigger";
                //clicking on disabled tabs will not show
                if ($(tabID).parent().hasClass("disabled"))
                return false;
                else
                return true;*/
                return false;
            },
            'onTabShow': function (tab, navigation, index) {
                var $total = navigation.find('li').length;
                var $current = index + 1;
                var $percent = ($current / $total) * 100;

                if ($current >= $total) {
                    $('#rootwizard').find('.pager .next').hide();
                    $('#rootwizard').find('.pager .finish').show();
                    $('#rootwizard').find('.pager .finish').removeClass('disabled');
                } else {
                    $('#rootwizard').find('.pager .next').show();
                    $('#rootwizard').find('.pager .finish').hide();
                }
            }
        });

        //$('input[value="Others"]').change(function () {
        //    if ($(this).is(':checked') || $(this).is(':selected')) {
        //        $(this).parent().parent().next('div.othersfield').show();
        //    } else {
        //        $(this).parent().parent().next('div.othersfield').hide();
        //    }
        //});

        $('select').on("change", function () {

            var newSelectedValHtml = $(this).find("option[value='" + $(this).val() + "']").html();

            if ($(this).val() == "Others" || newSelectedValHtml == "Others") {
                $(this).siblings('div.othersfield').show();
            } else {
                $(this).siblings('div.othersfield').hide();
            }
        });

        $('option[value="Others"]').each(function () {
            if ($(this).is(':selected')) {
                console.log('Selected Other');
                $(this).parent().parent().next('div.othersfield').show();
            } else {
                $(this).parent().next('div.othersfield').hide();
            }
        });

        //the following ordering matters
        //=================================
        //trigger change event so if any select field have "Others" selected will auto display the "please specify box"
        $('select').change();

        //bind events for modified monitoring
        //$("input[type='text'].changedMonitored, textarea.changedMonitored").on("keyup", HasModifiedData);
        //$("input[type='radio'].changedMonitored, input[type='checkbox'].changedMonitored, select.changedMonitored").on("change", HasModifiedData);

    });

})(jQuery);

function DynamicFormSubmit(loadingObj, callerObj) {

    ClearErrorMessages();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                // Redirect when successful.
                window.location.href = '/page/job-apply-success/';
                return;

            }
            else {
                var validateResults = result.jsonVal.d.ValidateResult;
                ProcessValidationMessage(8, validateResults);
                ScrollToFirstError();
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };
        
    SendDataToServer(8, loadingObj, callerObj, onSuccess, onFailure);
}



function Page1Submit(loadingObj, callerObj) {

    ClearErrorMessages();

    var modelhasErrors = $("#tab1").ValidateChilds();

    if (modelhasErrors) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    }
    else {

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);

        if (!($('#chkTermsAndConditions').is(':checked'))) {

            $('#validTermsAndConditions').text("Please agree to the terms and conditions");
            requesting = false;
            return false;
        }

        requesting = false;

        return true;
        /*
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    //update modify flag so the message won't show
                    //tabHasModified = false;

                    UpdateUpToSteps(2);
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    ProcessValidationMessage(1, validateResults);
                }
            }
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        var onFailure = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        SendDataToServer(1, loadingObj, callerObj, onSuccess, onFailure);*/
    }

    return false;
}

function Page2Submit(loadingObj, callerObj) {

    ClearErrorMessages();

    var modelhasErrors = $("#tab2").ValidateChilds();
    if (modelhasErrors) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    }
    else {
        var onSuccess = function (result) {
            
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    //update modify flag so the message won't show
                    //tabHasModified = false;

                    UpdateUpToSteps(3);
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    ProcessValidationMessage(2, validateResults);
                }
            }
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        var onFailure = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        SendDataToServer(2, loadingObj, callerObj, onSuccess, onFailure);
    }

    return false;
}

//this checks for an existing record before allowing to next step
function Page3Submit(loadingObj, callerObj) {

    ClearErrorMessages();

    // Check if the tab values were entered but not saved.
    var tabHasValues = CheckTabHasValues("#tab3");    
    if (tabHasValues) {
        $("span[data-valmsg-for='form_error']").html('You have entered details for a directorship experience role without saving it. Please click on "save & add another role" button above before continuing.');
        requesting = false;

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        
        return false;
    }

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
                UpdateUpToSteps(4);
            else {
                var validateResults = result.jsonVal.d.ValidateResult;
                ProcessValidationMessage(3, validateResults);
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    SendDataToServer(3, loadingObj, callerObj, onSuccess, onFailure);

    return false;
}

//this checks for an existing record before allowing to next step
function Page4Submit(loadingObj, callerObj) {

    ClearErrorMessages();

    // Check if the tab values were entered but not saved.
    var tabHasValues = CheckTabHasValues("#tab4");
    if (tabHasValues) {
        $("span[data-valmsg-for='form_error']").html('You have entered details for a professional experience role without saving it. Please click on "save & add another role" button above before continuing.');
        requesting = false;

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);

        return false;
    }

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
                UpdateUpToSteps(5);
            else {
                var validateResults = result.jsonVal.d.ValidateResult;
                ProcessValidationMessage(4, validateResults);
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    SendDataToServer(4, loadingObj, callerObj, onSuccess, onFailure);

    return false;
}

//this checks for an existing record before allowing to next step
function Page5Submit(loadingObj, callerObj) {

    ClearErrorMessages();


    // Check if the tab values were entered but not saved.
    var tabHasValues = CheckTabHasValues("#qualificationForm");
    if (tabHasValues) {
        $("span[data-valmsg-for='form_error']").html('You have entered details for education and qualification without saving it. Please click on "save qualification" button above before continuing.');
        requesting = false;

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);

        return false;
    }

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
                UpdateUpToSteps(6);
            else {
                var validateResults = result.jsonVal.d.ValidateResult;
                ProcessValidationMessage(5, validateResults);
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    SendDataToServer(5, loadingObj, callerObj, onSuccess, onFailure);

    return false;
}

/*
function Page6Submit(loadingObj, callerObj) {

    ClearErrorMessages();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                //update modify flag so the message won't show
                //tabHasModified = false;

                UpdateUpToSteps(7);
            }
            else {
                var validateResults = result.jsonVal.d.ValidateResult;
                ProcessValidationMessage(6, validateResults);
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    SendDataToServer(6, loadingObj, callerObj, onSuccess, onFailure);

    return false;
}*/

function Page7Submit(loadingObj, callerObj) {

    ClearErrorMessages();
    
    var modelhasErrors = $("#tab7").ValidateChilds();

    if (modelhasErrors) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    }
    else {
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    //update modify flag so the message won't show
                    //tabHasModified = false;

                    UpdateUpToSteps(7);
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    ProcessValidationMessage(7, validateResults);
                }
            }
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        var onFailure = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        SendDataToServer(7, loadingObj, callerObj, onSuccess, onFailure);
    }
    return false;
}

$("document").ready(function () {

    //$('#fileupload').on("change", function () {
    'use strict';

    // Change this to the location of your server-side upload handler:
    var url = "/fileupload.ashx?type=resume&jobid=" + $('#hfJobId').val();
    
    var callerObjUpload;
    var callerObjRefUpload;
    var loadingUpload;


    $('#fileupload').fileupload({
        url: url,
        dataType: 'json',
        sequentialUploads: true,
        start: function (e) {
            callerObjUpload = $('#resume-response');
            callerObjRefUpload = $('#resume-response');
            loadingUpload = ReplaceObjectWithLoading(callerObjUpload);
        },
        /*formData: [{ name: 'albumID', value: 1}],*/
        done: function (e, data) {
            //alert('done' + data);
            console.log(data.result);

            $(loadingUpload).replaceWith(callerObjRefUpload);

            if (data.result.files[0].ReturnString != '') {
                
                if (data.result.files[0].ReturnString.indexOf('expired') > 0) {
                    alert(data.result.files[0].ReturnString);
                    location.reload(true);
                }

                // Display the error.
                $('#resume-response').text(data.result.files[0].ReturnString);
            }
            else {

                $('#resume-response').text('Resume uploaded.');
            }

        },
        fail: function (e, data) {
            //alert("failed");
            console.log(data.result);
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            //$('#progress .progress-bar').css('width', progress + '%');
        }
    }).prop('disabled', !$.support.fileInput).parent().addClass($.support.fileInput ? undefined : 'disabled');


});

function SaveDraft(callerObj, isFinished) {
    
    if (isEditing)
        return false;

    ClearErrorMessages();

    if (!requesting) {

        if (isFinished) {

            /*if (!($('#chkTermsAndConditions').is(':checked'))) {

                $('#validTermsAndConditions').text("Please agree to the terms and conditions");
                return;
            }*/

        }

        var callerObjRef = callerObj;
        var loadingObj = ReplaceObjectWithLoading(callerObj);


        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {

                EditInProgressComplete();

                if (result.jsonVal.d.Success) //execution success
                {
                    if (isFinished) {
                        // Redirect when successful.
                        window.location.href = '/page/job-apply-success/';
                        return;
                    }
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    for (key in validateResults) {
                        $("span[data-valmsg-for='" + validateResults[key].MemberNames[0] + "']").html(validateResults[key].ErrorMessage);
                    }
                }
            }
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        var onFailure = function (result) {
            EditInProgressComplete();
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        EditInProgress();
        $("").sendAjaxForSaveDraft("/job/application/aicd_scholarship.aspx/savedraft", isFinished, onSuccess, onFailure);


    }

}

function AddDirectorshipExperience(callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    var DirectorshipTabID = "#tab3";

    ClearErrorMessages();

    var modelhasErrors = $(DirectorshipTabID).ValidateChilds();
    if (modelhasErrors) {

        // Scroll to the first error
        ScrollToFirstError();

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
        return false;
    }
    else {
        requesting = true;

        var onSuccess = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;

            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    UpdateDirectorshipRolesTable(result.jsonVal.d.ExperienceList);

                    //change the buttons regardless back to "Add another role"
                    $("#addDirectorshipExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save & add another role");
                    $("#editDirectorshipCancel").addClass("hide");
                    $("#resetDirectorshipExperience").removeClass("hide");
                    
                    ResetForm(DirectorshipTabID);
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    for (key in validateResults) {
                        $("span[data-valmsg-for='" + validateResults[key].MemberNames[0] + "']").html(validateResults[key].ErrorMessage);
                    }
                    
                    // Scroll to the first error
                    ScrollToFirstError();

                }
            }


            
            EditInProgressComplete();
        };

        var onFailure = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;

            EditInProgressComplete();
        };

        var result = $(DirectorshipTabID).sendAjaxWithExpectDataTypeReturn(-2, "/job/application/aicd_scholarship.aspx/directorshipexperienceadd", "POST", "json", null, onSuccess, onFailure);

    }

}


function EditDirectorshipRole(guid, callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    ClearErrorMessages();

    requesting = true;

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                //experience obj
                var thisExperience = result.jsonVal.d.Experience;

                UpdateFieldsWithModel("#tab3", thisExperience);

                //change the buttons
                $("#addDirectorshipExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save");
                $("#editDirectorshipCancel").removeClass("hide");
                $("#resetDirectorshipExperience").addClass("hide");


                $("#experienceSummary").textareaCounter({ limit: 200 });
                // Scroll to the top
                $("html, body").animate({ scrollTop: "0" });
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };


    var result = $("").sendAjaxWithExpectDataTypeReturn(-1, "/job/application/aicd_scholarship.aspx/directorshipexperienceedit", "POST", "json", "guid=" + guid, onSuccess, onFailure);


}

function CancelDirectorshipExperience() {

    ClearErrorMessages();

    ResetForm("#tab3");

    EditInProgressComplete();

    //change the buttons
    $("#addDirectorshipExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save & add another role");
    $("#editDirectorshipCancel").addClass("hide");
    $("#resetDirectorshipExperience").removeClass("hide");

    

}

function DeleteDirectorshipRole(guid, callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    ClearErrorMessages();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                UpdateDirectorshipRolesTable(result.jsonVal.d.ExperienceList);
                
                if (result.jsonVal.d.ExperienceList != null && result.jsonVal.d.ExperienceList.length == 0) {
                    $("#addDirectorshipExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save role");
                }
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var result = $("").sendAjaxWithExpectDataTypeReturn(-1, "/job/application/aicd_scholarship.aspx/directorshipexperienceremove", "POST", "json", "guid=" + guid, onSuccess, onFailure);


}

function DirectorRoleIsCurrentClick(callerObj) {

    $("span[data-valmsg-for='dirEndDateMonth']").empty();

    if ($(callerObj).is(":checked")) {
        $("#ddlDirectorshipExpJobEndMonth, #ddlDirectorshipExpJobEndYear").prop("disabled", "disabled");
    }
    else {
        $("#ddlDirectorshipExpJobEndMonth, #ddlDirectorshipExpJobEndYear").removeAttr("disabled");
    }
}

function AddProfessionalExperience(callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    var profExpTabID = "#tab4";

    ClearErrorMessages();

    var modelhasErrors = $(profExpTabID).ValidateChilds();
    if (modelhasErrors) {
    
        // Scroll to the first error
        ScrollToFirstError();

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
        return false;
    }
    else {

        requesting = true;

        var onSuccess = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;

            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    UpdateProfessionalRolesTable(result.jsonVal.d.ExperienceList);

                    //change the buttons regardless back to "Add another role"
                    $("#addProfessionalExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save & add another role");
                    $("#editProfessionalCancel").addClass("hide");
                    $("#resetProfessionalExperience").removeClass("hide");

                    ResetForm(profExpTabID);
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    for (key in validateResults) {
                        $("span[data-valmsg-for='" + validateResults[key].MemberNames[0] + "']").html(validateResults[key].ErrorMessage);
                    }
                    
                    // Scroll to the first error
                    ScrollToFirstError();

                }
            }


            EditInProgressComplete();

        };

        var onFailure = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;

            EditInProgressComplete();
        };

        $(profExpTabID).sendAjaxWithExpectDataTypeReturn(-2, "/job/application/aicd_scholarship.aspx/professionalexperienceadd", "POST", "json", null, onSuccess, onFailure);

    }

}

function EditProfessionalRole(guid, callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    ClearErrorMessages();

    requesting = true;

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                //experience obj
                var thisExperience = result.jsonVal.d.Experience;

                UpdateFieldsWithModel("#tab4", thisExperience);

                //change the buttons
                $("#addProfessionalExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save & add another role");
                $("#editProfessionalCancel").removeClass("hide");
                $("#resetProfessionalExperience").addClass("hide");

                $("#txtProfessionalExpSummary").textareaCounter({ limit: 200 });
                // Scroll to the top
                $("html, body").animate({ scrollTop: "0" });
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    $("").sendAjaxWithExpectDataTypeReturn(-1, "/job/application/aicd_scholarship.aspx/professionalexperienceedit", "POST", "json", "guid=" + guid, onSuccess, onFailure);


}

function CancelProfessionalExperience() {

    ClearErrorMessages();

    ResetForm("#tab4");

    EditInProgressComplete();

    //change the buttons
    $("#addProfessionalExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save & add another role");
    $("#editProfessionalCancel").addClass("hide");
    $("#resetProfessionalExperience").removeClass("hide");

    

}

function DeleteProfessionalRole(guid, callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    ClearErrorMessages();

    requesting = true;

    var onSuccess = function (result) {

        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                UpdateProfessionalRolesTable(result.jsonVal.d.ExperienceList);

                if (result.jsonVal.d.ExperienceList != null && result.jsonVal.d.ExperienceList.length == 0) {
                    $("#addProfessionalExperience").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save role");
                }
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var result = $("").sendAjaxWithExpectDataTypeReturn(-1, "/job/application/aicd_scholarship.aspx/professionalexperienceremove", "POST", "json", "guid=" + guid, onSuccess, onFailure);

}

function ProfessionalRoleIsCurrentClick(callerObj) {

    $("span[data-valmsg-for='profEndDateMonth']").empty();

    if ($(callerObj).is(":checked")) {
        $("#endProfessionalExpJobEndMonth, #endProfessionalExpJobEndYear").prop("disabled", "disabled");
    }
    else {
        $("#endProfessionalExpJobEndMonth, #endProfessionalExpJobEndYear").removeAttr("disabled");
    }
}

function AddQualification(callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    var qualificationTabID = "#qualificationForm";

    ClearErrorMessages();

    var modelhasErrors = $(qualificationTabID).ValidateChilds();
    if (modelhasErrors) {
        
        // Scroll to the first error
        ScrollToFirstError();

        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
        return false;
    }
    else {
        requesting = true;

        var onSuccess = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;

            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    UpdateQualificationTable(result.jsonVal.d.ExperienceList);

                    //change the buttons regardless back to "Add another qualification"
                    $("#add-qualification").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save and add another qualification");
                    $("#cancel-qualification").addClass("hide");
                    $("#resetQualification").removeClass("hide");
                    

                    ResetForm(qualificationTabID);
                }
                else {
                    var validateResults = result.jsonVal.d.ValidateResult;
                    for (key in validateResults) {
                        $("span[data-valmsg-for='" + validateResults[key].MemberNames[0] + "']").html(validateResults[key].ErrorMessage);
                    }

                    // Scroll to the first error
                    ScrollToFirstError();
                }
            }

            

        };

        var onFailure = function (result) {
            //reset requesting loading and variable 
            $(loadingObj).replaceWith(callerObj);
            requesting = false;
        };

        $(qualificationTabID).sendAjaxWithExpectDataTypeReturn(-2, "/job/application/aicd_scholarship.aspx/qualificationadd", "POST", "json", null, onSuccess, onFailure);
    }

}

function EditQualification(guid, callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    ClearErrorMessages();

    requesting = true;

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                //experience obj
                var thisExperience = result.jsonVal.d.Experience;

                UpdateFieldsWithModel("#tab5", thisExperience);

                //change the buttons
                $("#add-qualification").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save and add another qualification");
                $("#cancel-qualification").removeClass("hide");
                $("#resetQualification").addClass("hide");

                

            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    $("").sendAjaxWithExpectDataTypeReturn(-1, "/job/application/aicd_scholarship.aspx/qualificationedit", "POST", "json", "guid=" + guid, onSuccess, onFailure);

}

function CancelQualification() {

    ClearErrorMessages();

    ResetForm("#tab5");

    EditInProgressComplete();

    //change the buttons
    $("#add-qualification").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save and add another qualification");
    $("#cancel-qualification").addClass("hide");
    $("#resetQualification").removeClass("hide");

    

}

function DeleteQualification(guid, callerObj) {

    var callerObjRef = callerObj;
    var loadingObj = ReplaceObjectWithLoading(callerObj);

    ClearErrorMessages();

    requesting = true;

    var onSuccess = function (result) {

        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                UpdateQualificationTable(result.jsonVal.d.ExperienceList);

                if (result.jsonVal.d.ExperienceList != null && result.jsonVal.d.ExperienceList.length == 0) {
                    $("#add-qualification").empty().append("<i class='fa fa-plus'><!--ICON--></i>Save qualification");
                }
            }
        }
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };

    var onFailure = function (result) {
        //reset requesting loading and variable 
        $(loadingObj).replaceWith(callerObj);
        requesting = false;
    };


    var result = $("").sendAjaxWithExpectDataTypeReturn(-1, "/job/application/aicd_scholarship.aspx/qualificationremove", "POST", "json", "guid=" + guid, onSuccess, onFailure);

}

function QualificationIsCurrentClick(callerObj) {

    $("span[data-valmsg-for='qEndDateMonth']").empty();

    if ($(callerObj).is(":checked")) {
        $("#ddlEducationEndMonth, #ddlEducationEndYear").prop("disabled", "disabled");
    }
    else {
        $("#ddlEducationEndMonth, #ddlEducationEndYear").removeAttr("disabled");
    }
}

function SendDataToServer(tabNo, loadingObj, callerObj, onSuccess, onFailure) {

    $("#tab" + tabNo).sendAjaxWithExpectDataTypeReturn(tabNo, "/job/application/aicd_scholarship.aspx/pagesubmit", "POST", "json", null, onSuccess, onFailure);

}

/*
function UpdateUpToSteps(uptoStep) {

    for (var i = 0; i <= uptoStep; i++) {
        EnabledTab(i);
    }

    $("#tab" + uptoStep + "Trigger").click();

    //scroll to top of page on success
    $("html, body").animate({ scrollTop: "0" });
}*/

function UpdateUpToSteps(uptoStep) {

    //for (var i = 0; i <= uptoStep; i++) {
    //    EnabledTab(i);
    //}
    $('#rootwizard').bootstrapWizard('show', uptoStep - 1);

    //scroll to top of page on success
    $("html, body").animate({ scrollTop: "0" });
}


function EnabledTab(tabNo) {

    $("#tab" + tabNo + "Trigger").parent().removeClass("disabled");
    $("#tab" + tabNo + "Trigger").prop("href", "#tab" + tabNo);

}

function ResetForm(target) {
    $.each($(target).find("input, textarea, select"), function () {

        if ($(this).is("input")) {
            if ($(this).attr("type") == "text" || $(this).attr("type") == "hidden") {
                $(this).val("");
            }
            else if ($(this).attr("type") == "radio") {

            }
            else if ($(this).attr("type") == "checkbox") {
                $(this).attr('checked', false);
            }
        }
        if ($(this).is("textarea")) {
            $(this).val("");
            $(this).next('p').html('200 words left');
        }
        if ($(this).is("select")) {
            $(this).removeAttr("disabled").find("option:first-child").prop("selected", "selected");
            $(this).change();
        }
    });
}

function ClearErrorMessages() {
    $(".field-validation-error").empty();
    $(".field-validation-valid").empty();

}

function UpdateFieldsWithModel(tabID, model) {
    //dynamically populate
    for (var key in model) {
        //key is the name attr of the input fields
        //find the input fields and act base on input type
        var matchingElements = $(tabID + " *[name='" + key + "']");
        if (matchingElements.length > 0) {
            if ($(matchingElements[0]).is("input")) {

                if ($(matchingElements[0]).attr("type") == "checkbox") {

                    //creates a click event
                    if (model[key] == true) {
                        $(matchingElements[0]).prop("checked", false);
                        $(matchingElements[0]).click();
                    }
                    else {
                        $(matchingElements[0]).prop("checked", true);
                        $(matchingElements[0]).click();
                    }
                }
                else if ($(matchingElements[0]).attr("type") == "radio") {
                    if ($(matchingElements[0]).val() == model[key])
                        $(matchingElements[0]).prop("checked", true);
                    else
                        $(matchingElements[0]).prop("checked", false);
                }
                else
                    $(matchingElements[0]).val(model[key]);
            }
            else if ($(matchingElements[0]).is("textarea"))
                $(matchingElements[0]).val(model[key]);
            else if ($(matchingElements[0]).is("select")) {
                $(matchingElements[0]).val(model[key]);
                //create change event
                $(matchingElements[0]).change();
            }
        }
    }
}

function UpdateDirectorshipRolesTable(newList) {
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    //populate to the table for display
    var targetTableBody = $("#directorship-experience-table tbody");

    //clean entries
    targetTableBody.empty();

    var fullExpList = newList;


    if (fullExpList.length == 0) {
        var newTR = $("<tr></tr>");
        newTR.append(" <td colspan='6'><i>You have not added any directorship experience yet</i></td>");
        targetTableBody.append(newTR);
    }
    else {
        for (var i = 0; i < fullExpList.length; i++) {
            var newTR = $("<tr></tr>");

            //take the role name from select
            var roleTypeName = $("select[name='roleType'] option[value='" + fullExpList[i].roleType + "']").html();

            newTR.append("<td>" + roleTypeName + "</td>");
            newTR.append("<td>" + fullExpList[i].positionTitle + "</td>");
            newTR.append("<td>" + fullExpList[i].organisationName + "</td>");
            newTR.append("<td>" + monthNames[fullExpList[i].dirStartDateMonth - 1] + " " + fullExpList[i].dirStartDateYear + "</td>");

            if (fullExpList[i].directorshipIsCurrent)
                newTR.append("<td>Present</td>");
            else
                newTR.append("<td>" + monthNames[fullExpList[i].dirEndDateMonth - 1] + " " + fullExpList[i].dirEndDateYear + "</td>");

            newTR.append("<td class=\"text-right\"><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EditDirectorshipRole('" + fullExpList[i].internalGUID + "');\")\"><i class=\"fa fa-pencil\"><!--ICON--></i>Edit</button><button type=\"button\" class=\"btn btn-danger btn-xs\" onclick=\"DeleteDirectorshipRole('" + fullExpList[i].internalGUID + "');\"><i class=\"fa fa-times\"><!--ICON--></i>Delete</button></td>");
            targetTableBody.append(newTR);
        }
    }
}

function UpdateProfessionalRolesTable(newList) {
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    //populate to the table for display
    var targetTableBody = $("#professional-experience-table tbody");

    //clean entries
    targetTableBody.empty();

    var fullExpList = newList;

    if (fullExpList.length == 0) {
        var newTR = $("<tr></tr>");
        newTR.append("<td colspan='6'><i>You have not added any professional experience yet</i></td>");
        targetTableBody.append(newTR);
    }
    else {
        for (var i = 0; i < fullExpList.length; i++) {
            var newTR = $("<tr></tr>");
            //take the role name from select
            var roleTypeName = $("select[name='profRole'] option[value='" + fullExpList[i].profRole + "']").html();

            newTR.append("<td>" + roleTypeName + "</td>");
            newTR.append("<td>" + fullExpList[i].jobTitle + "</td>");
            newTR.append("<td>" + fullExpList[i].profOrgName + "</td>");
            newTR.append("<td>" + monthNames[fullExpList[i].profStartDateMonth - 1] + " " + fullExpList[i].profStartDateYear + "</td>");

            if (fullExpList[i].profIsCurrent)
                newTR.append("<td>Present</td>");
            else
                newTR.append("<td>" + monthNames[fullExpList[i].profEndDateMonth - 1] + " " + fullExpList[i].profEndDateYear + "</td>");
            newTR.append("<td class=\"text-right\"><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EditProfessionalRole('" + fullExpList[i].internalGUID + "');\")\"><i class=\"fa fa-pencil\"><!--ICON--></i>Edit</button><button type=\"button\" class=\"btn btn-danger btn-xs\" onclick=\"DeleteProfessionalRole('" + fullExpList[i].internalGUID + "');\"><i class=\"fa fa-times\"><!--ICON--></i>Delete</button></td>");

            targetTableBody.append(newTR);
        }
    }
}

function UpdateQualificationTable(newList) {
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    //populate to the table for display
    var targetTableBody = $("#qualification-table tbody");

    //clean entries
    targetTableBody.empty();

    var fullExpList = newList;

    if (fullExpList.length == 0) {
        var newTR = $("<tr></tr>");
        newTR.append("<td colspan='5'><i>You have not added any qualifications yet</i></td>");
        targetTableBody.append(newTR);
    }
    else {
        for (var i = 0; i < fullExpList.length; i++) {
            var newTR = $("<tr></tr>");

            newTR.append("<td>" + fullExpList[i].courseName + "</td>");
            newTR.append("<td>" + fullExpList[i].institution + "</td>");
            newTR.append("<td>" + monthNames[fullExpList[i].qStartDateMonth - 1] + " " + fullExpList[i].qStartDateYear + "</td>");
            if (fullExpList[i].qIsCurrent)
                newTR.append("<td>Present</td>");
            else
                newTR.append("<td>" + monthNames[fullExpList[i].qEndDateMonth - 1] + " " + fullExpList[i].qEndDateYear + "</td>");
            
            newTR.append("<td class=\"text-right\"><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EditQualification('" + fullExpList[i].internalGUID + "');\")\"><i class=\"fa fa-pencil\"><!--ICON--></i>Edit</button><button type=\"button\" class=\"btn btn-danger btn-xs\" onclick=\"DeleteQualification('" + fullExpList[i].internalGUID + "');\"><i class=\"fa fa-times\"><!--ICON--></i>Delete</button></td>");
            targetTableBody.append(newTR);
        }
    }

}

/*
function HasModifiedData() {
    tabHasModified = true;
}*/

function EditInProgressComplete()
{
        $("#nextTabBtn").parent().removeClass("disabled");
        $("#saveDraftBtn").parent().removeClass("disabled");
        $("#prevTabBtn").parent().removeClass("disabled");
        isEditing = false;   
}

function EditInProgress()
{
        $("#nextTabBtn").parent().addClass("disabled");
        $("#saveDraftBtn").parent().addClass("disabled");
        $("#prevTabBtn").parent().addClass("disabled");
        isEditing = true;
}


// Scroll to the first error 
function ScrollToFirstError()
{
    //find the first error
    if( $('.field-validation-error:visible').length > 0 )
    {
        var scrollOffsetTop = $('.field-validation-error:visible:first').offset().top;

        //scroll to the error
        $("html, body").animate({ scrollTop: scrollOffsetTop - 200 + "px" });
    }
}


function ProcessValidationMessage(tabNoINT, validateMsgsList) {
    //console.log(validateMsgsList);
    for (key in validateMsgsList) {
        //special case for generic error
        if (validateMsgsList[key].MemberNames[0] == "form_error")
            $("span[data-valmsg-for='" + validateMsgsList[key].MemberNames[0] + "']").html(validateMsgsList[key].ErrorMessage);
        else
            $("#tab" + tabNoINT + " span[data-valmsg-for='" + validateMsgsList[key].MemberNames[0] + "']").html(validateMsgsList[key].ErrorMessage);
    }
}


$.fn.ValidateChilds = function () {
    var hasErrors = false;
    $.each($(this).find("input, textarea[data-val='true']"), function () {
        //alert($(this).attr("name"));
        if ($(this).valid() == 0) {
            hasErrors = true;
        }
    });
    return hasErrors;
};

$.fn.sendAjaxWithExpectDataTypeReturn = function () {
    var tabNo = arguments[0];
    var ajaxURL = arguments[1];
    var method = arguments[2];
    var dataType = arguments[3];
    var extraQueryParams = arguments[4];
    var onSuccessFunction = arguments[5];
    var onFailFunction = arguments[6];

    var returnValue;
    var querydata = getQueryData(this, extraQueryParams, tabNo == 1 ? true : false); // only when tabNo is 1 send the Form field ID's instead of NAME attribute

    // disabled all of the  butttons
    EditInProgress();

    //sharing method but different data
    var data;
    if (tabNo == -2) {
        data = "{ model: " + JSON.stringify(querydata) + "}";
    }
    else if (tabNo == -1) {
        data = JSON.stringify(querydata);
    }
    else if (tabNo == 8) {
        
        // Get the dynamic questionaire form 
        querydata = getQueryData($("#tab8"), null, true);
        var newArrObj = [];
        for (var key in querydata) {
            var newObj = { name: key, value: querydata[key] };
            newArrObj.push(newObj);
        }

        data = "{ model: { tabSubmit: " + tabNo + ", tab" + tabNo + ":  { tab1Values:" + JSON.stringify(newArrObj) + "} } }";
    }
    else {
        data = "{ model: { tabSubmit: " + tabNo + ", tab" + tabNo + ":  " + JSON.stringify(querydata) + "} }";
    }

    $.ajax({
        url: ajaxURL,
        type: method,
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        async: true,
        dataType: dataType,
        success: function (data, textStatus, xmlHttpRequest) {
            //because we want to standardise this ajax call returning objects from server,
            //we have to specificly checks for different expected dataTypes return
            if (dataType.toUpperCase() == "HTML") {
                var contentType = xmlHttpRequest.getResponseHeader("Content-Type");
                if (contentType.indexOf("application/json") >= 0) {
                    //error, because we expecting html
                    //we parse the json and return
                    returnValue = { status: false, jsonVal: eval('(' + data + ')') };
                }
                else if (contentType.indexOf("text/html") >= 0) {
                    //html retreive success
                    returnValue = { status: true, html: data };
                }
            }
            else {

                //alert(data.d.Success);

                //other expected dataType return
                /*if (data.d.Success == false)
                {
                returnValue = { status: false, jsonVal: data };
                }
                else
                {*/
                // Check if the Session is expired, if it did refresh the page.
                if (data.d.Session != null) {
                    alert(data.d.Session);
                    location.reload(true);
                }
                returnValue = { status: true, jsonVal: data };
                //}
            }

            //run onSuccess
            onSuccessFunction(returnValue);

        },
        error: function (xhr, error) {
            returnValue = { status: false, message: "Could not reach destination or request failed, please try again" };
            //run onFailure
            onFailFunction(returnValue);
        },
        complete: function (a, b) {

            //alert(ajaxURL.indexOf("add") > 0 || ajaxURL.indexOf("remove") > 0 || ajaxURL.indexOf("pagesubmit") > 0 || ajaxURL.indexOf("savedraft") > 0 );
            //enable the button only when its an ADD, DELETE
            if (ajaxURL.indexOf("add") > 0 || ajaxURL.indexOf("remove") > 0 || ajaxURL.indexOf("pagesubmit") > 0 || ajaxURL.indexOf("savedraft") > 0) {
                EditInProgressComplete();
            }

        }
    });
}

$.fn.sendAjaxForSaveDraft = function () {
    var ajaxURL = arguments[0];
    var isFinishedForm = arguments[1];
    var onSuccessFunction = arguments[2];
    var onFailFunction = arguments[3];

    var returnValue;

    // Get the dynamic questionaire form 
    var querydata = getQueryData($("#tab8"), null, true);
    var newArrObj = [];
    for (var key in querydata) {
        var newObj = { name: key, value: querydata[key] };
        newArrObj.push(newObj);
    }

    //tab3-tab5 is not needed because you need to use the add button
    var data = "{ isFinished: " + isFinishedForm + ", model: { tab8: { tab1Values:" + JSON.stringify(newArrObj) + "}, tab2: " + JSON.stringify(getQueryData($("#tab2"))) + ", tab5: " + JSON.stringify(getQueryData($("#tab5"))) + ", tab7: " + JSON.stringify(getQueryData($("#tab7"))) + " } }";

    $.ajax({
        url: ajaxURL,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        async: true,
        dataType: "json",
        success: function (data, textStatus, xmlHttpRequest) {
            //other expected dataType return
            /*if (data.d.Success == false) {
            returnValue = { status: false, jsonVal: data };
            }
            else {*/
            // Check if the Session is expired, if it did refresh the page.
            if (data.d.Session != null) {
                alert(data.d.Session);
                location.reload(true);
            }

            //console.log(data.d.Success);

            if (data.d.Success) {
                // tick box on the save draft button when its saved
                $('li.draft').addClass('saved');
            }
            else {
                $('li.draft').removeClass('saved');
            }

            returnValue = { status: true, jsonVal: data };
            //}
            //run onSuccess
            onSuccessFunction(returnValue);

        },
        error: function (xhr, error) {
            returnValue = { status: false, message: "Could not reach destination or request failed, please try again" };
            //run onFailure
            onFailFunction(returnValue);
        }
    });
}

// Checks if the tab has values entered in textboxes or radio/checkbox is checked.
function CheckTabHasValues(tabName) {

    var blnResult = false;

    // Validates only textbox, radio and checkbox
    $.each($(tabName).find("input, textarea"), function () {
    
        if ($(this).is("input") && ($(this).attr("type") == "radio" || $(this).attr("type") == "checkbox")) {
            if ($(this).is(":checked")) {
                blnResult = true;
                return false;
            }
        }
        else {  //textareas & input texts
            if ($.trim($(this).val()).length > 0) {
                //alert($(this).attr('id') + $.trim($(this).val()).length);
                blnResult = true;
                return false;
            }
        }
    });

    return blnResult;
}


function getQueryData(thisObj, extraQueryParams, takeIDAsKey) {
    //retreive and create data
    var willTakeID = takeIDAsKey == null ? false : takeIDAsKey;
    var querydata = {};
    var inputQuantity = $(thisObj).find("input, select, textarea").length;
    var counter = 1;
    
    $.each($(thisObj).find("input, select, textarea"), function () {
        //handle radio inputs because radio inputs have same name but will only be 1 input value
        //to determine, we only find checked radio input to add to query data
        if ($(this).is("input") && $(this).attr("type") == "radio") {
            if ($(this).is(":checked")) {
                if (willTakeID && $(this).attr("id").length > 0) {
                    querydata[$(this).attr("id")] = $(this).val();
                }
                else if ($(this).attr("name").length > 0)
                    querydata[$(this).attr("name")] = $(this).val();
                else
                    querydata[$(this).attr("class")] = $(this).val();
            }
        }
        else if ($(this).is("input") && $(this).attr("type") == "checkbox") {

            var insertValue;
            if ($(this).is(":checked")) {
                if ($(this).attr("value").length == 0)
                    insertValue = $(this).is(":checked");
                else
                    insertValue = $(this).val();

                //we append using ',' if previously a same element name found
                if (willTakeID && $(this).attr("id").length > 0) {
                    if (querydata[$(this).attr("id")] == null)
                        querydata[$(this).attr("id")] = insertValue;
                    else
                        querydata[$(this).attr("id")] = querydata[$(this).attr("id")] + "," + insertValue;
                }
                else if ($(this).attr("name").length > 0) {
                    if (querydata[$(this).attr("name")] == null)
                        querydata[$(this).attr("name")] = insertValue;
                    else
                        querydata[$(this).attr("name")] = querydata[$(this).attr("name")] + "," + insertValue;
                }
                else if ($(this).attr("id").length > 0) {
                    if (querydata[$(this).attr("id")] == null)
                        querydata[$(this).attr("id")] = insertValue;
                    else
                        querydata[$(this).attr("id")] = querydata[$(this).attr("id")] + "," + insertValue;
                }
                else {
                    if (querydata[$(this).attr("class")] == null)
                        querydata[$(this).attr("class")] = insertValue;
                    else
                        querydata[$(this).attr("class")] = querydata[$(this).attr("class")] + "," + insertValue;
                }
            }
        }
        else { //textareas & input texts
            
            var insertValue = $(this).val();
            if (willTakeID && $(this).attr("id").length > 0)
                querydata[$(this).attr("id")] = insertValue;
            else if ($(this).attr("name").length > 0)
                querydata[$(this).attr("name")] = insertValue;
            else if ($(this).attr("id").length > 0)
                querydata[$(this).attr("id")] = insertValue;
            else
                querydata[$(this).attr("class")] = insertValue;
        }
    });

    if (extraQueryParams != null) {
        if (typeof (extraQueryParams) == "string" && extraQueryParams.length > 0) {
            var params = extraQueryParams.split("&");
            for (var i = 0; i < params.length; i++) {
                var tempSplit = params[i].split("=");
                if (tempSplit.length == 2) {
                    //correct format
                    querydata[tempSplit[0]] = tempSplit[1];
                }
                else if (tempSplit.length > 2)
                    querydata[tempSplit[0]] = "Error in JS level";
            }
        }
        else {
            for (var key in extraQueryParams) {
                querydata[key] = extraQueryParams[key];
            }
        }
    }
    //console.log(querydata);
    return querydata;
}

function processData(data) {
    //create new json object
    var processData = "{";
    var counter = 0;
    data.toJSON = function (key) {
        for (var val in this) {
            if (val != "toJSON") {
                if (counter != 0)
                    processData += ",";
                if (typeof (this[val]) == "object") {
                    if (isArray(this[val])) {
                        processData += "\"" + val + "\":" + processArrayToJsonText(this[val]);
                    }
                    else {
                        //else its not an array object
                        //processData += "\"" + val + "\":\"" + this[val] + "\"";
                    }
                }
                else if (typeof (this[val]) == "boolean") {
                    processData += "\"" + val + "\":" + this[val];
                }
                else
                    processData += "\"" + val + "\":\"" + this[val] + "\"";
            }
            counter++;
        }
        processData += "}";
    }
    var jsonText = JSON.stringify(data);
    return processData;
}

function processArrayToJsonText(array) {
    var jsonText = "[";
    for (var i = 0; i < array.length; i++) {
        if (i != 0)
            jsonText += ",";
        if (typeof (array[i]) == "object") {
            if (isArray(array[i])) {
                jsonText += processArrayToJsonText(array[i]);
            }
            else {
                //else its not an array object
                jsonText += processData(array[i]);
            }
        }
        else if (typeof (array[i]) == "boolean") {
            jsonText += array[i];
        }
        else {
            jsonText += "\"" + array[i] + "\"";
        }
    }
    jsonText += "]";
    return jsonText;
}

function isArray(obj) {
    return obj.constructor == Array;
}

function ReplaceObjectWithLoading(object) {

    var loading = $("<span></span>").addClass("loadingSmall");
    var img = $("<i/>").addClass("fa fa-spinner fa-spin");
    $(loading).css("width", $(object).outerWidth())
        .css({
            "line-height": $(object).height() + "px",
            "text-align": "center",
            display: "inline-block",
            margin: $(object).css("margin"),
            padding: $(object).css("padding")
        }).append(img);

    //adjust size
    $(loading).css("font-size", "100%");

    $(object).replaceWith(loading);

    return loading;
}

