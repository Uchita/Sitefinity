
// For Members page - TABS
$(document).ready(function() {

    if (0 == $('#side-left, #job-side-column').children().length) {
        $('#side-left, #job-side-column').hide();
        $("#content").css("box-sizing", "border-box");
        $("#content").css("width", "100%");
    }

    //When page loads...
    $(".tab_content").hide(); //Hide all content
    $("ul.tabs li:first").addClass("active").show(); //Activate first tab
    $(".tab_content:first").show(); //Show first tab content

    //On Click Event
    $("ul.tabs li").click(function() {

        $("ul.tabs li").removeClass("active"); //Remove any "active" class
        $(this).addClass("active"); //Add "active" class to selected tab
        $(".tab_content").hide(); //Hide all tab content

        var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
        $(activeTab).fadeIn(); //Fade in the active ID content
        return false;
    });

    // This is to disable the advanced search paging which are active.
    $(".disabled_tnt_pagination").click(function (e) {
        e.preventDefault();
        return false;
    });

});

var IsDynamicWidgetTemp = "''";

/* Start of Advanced Search */

$(window).load(function () {
    /*if (Sys != null) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            SalaryChange();
        });
    }*/

});

$(document).ready(function () {

    // Decimal value valiation
    $('.numbersOnly').keyup(function () {
        this.value = this.value.replace(/[^0-9\.]/g, '');
    });

    // on change for sorting button
    $(".sorting-button > select").change(function () {
        $(this).parent().children("a").text($(this).children("option:selected").text());
    });

    // ** Salary - Search Results Filter - when Annual Selected
    $("#salaryAnnualTab").click(function () {
        $("#salaryAnnualTab").css("font-weight", "bold");
        $("#salaryHourlyTab").css("font-weight", "");
        $("#liAnnualTab").addClass("active");
        $("#liHourlyTab").removeClass("active");
        $("#hiddenSalaryTypeID").val(1);

    });

    // Salary - Search Results Filter - when Hourly Selected 
    $("#salaryHourlyTab").click(function () {
        $("#salaryHourlyTab").css("font-weight", "bold");
        $("#salaryAnnualTab").css("font-weight", "");
        $("#liHourlyTab").addClass("active");
        $("#liAnnualTab").removeClass("active");

        $("#hiddenSalaryTypeID").val(2);

    });


    // ** Job Alert - Salary
    /*$('#txtSalaryLowerBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));
    $('#txtSalaryUpperBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));

    $('#ddlSalary').change(function () {

    SalaryChange();
    $("#txtSalaryLowerBand").focus();
    });*/

    /
    // Advanced search - When you select location - Add the currency
    $('#locationID').change(function () {
        $(".divSalaryCurrency").html($("#locationID option:selected").data('placeholdertag') + ' ');

        var blnLocationSelected = ($("#locationID option:selected").val() < 1);

        if ($('#hfCountryCount').val() != "1") {
            $('#salaryID').prop('disabled', blnLocationSelected);
            $('#salarylowerband').prop('disabled', blnLocationSelected);
            $('#salaryupperband').prop('disabled', blnLocationSelected);
        }

    });
    $("#locationID").change();

    // Advanced search - When you select Profession
    $('#professionID').change(function () {

        $("#divRoleID").html("<img src='/images/loading.gif' alt='loading' />");

        var professionID = "";
        $("#professionID option:selected").each(function () {
            professionID += $(this).val();
        });

        //alert('You selected: ' + professionID);
        $.ajax({
            type: "POST",
            cache: false,
            url: "/job/ajaxcalls/ajaxmethods.asmx/getroles",
            data: "{'ProfessionId':" + professionID + ", 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $("#divRoleID").replaceWith(msg.d);
            },
            fail: function () {
                // Replace the div's content with the page method's return.
                $("#divRoleID").html("It didn't work");
            }
        });

    });
    
    // Advanced search
    $('#salaryID').change(function () {

        var salaryTypeId = "";

        $("#salaryID option:selected").each(function () {
            salaryTypeId += $(this).val();
        });

        $("#salarylowerband").val('');
        $("#salaryupperband").val('');

        $("#salarylowerband").focus();

        /*
        $.ajax({
        type: "POST",
        cache: false,
        url: "/job/ajaxcalls/ajaxmethods.asmx/GetSalaryRangeFrom",
        data: "{'salaryTypeid': '" + salaryTypeId + "','SalaryValueSet': '0;0', 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
        // Replace the div's content with the page method's return.
        $("#divSalaryFrom").html(msg.d);
        },
        fail: function() {
        // Replace the div's content with the page method's return.
        $("#divSalaryFrom").html("It didn't work");
        }
        });

        $.ajax({
        type: "POST",
        cache: false,
        url: "/job/ajaxcalls/ajaxmethods.asmx/GetSalaryRangeTo",
        data: "{'salaryTypeid': '" + salaryTypeId + "','SalaryValueSet': '0;0', 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
        // Replace the div's content with the page method's return.
        $("#divSalaryTo").html(msg.d);
        },
        fail: function() {
        // Replace the div's content with the page method's return.
        $("#divSalaryTo").html("It didn't work");
        }
        });*/

    });

    // When you select Country

    $('#countryID').change(function () {

        $("#divLocation").html("<img src='/images/loading.gif' alt='loading' />");

        var countryID = "";
        var defaultLocationID = "-1";

        $("#countryID option:selected").each(function () {
            countryID += $(this).val();
        });

        //alert('You selected: ' + professionID);
        $.ajax({
            type: "POST",
            cache: false,
            url: "/job/ajaxcalls/ajaxmethods.asmx/getlocations",
            data: "{'CountryID':" + countryID + ", 'DefaultLocationID':" + defaultLocationID + ", 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $("#divLocation").html(msg.d);
            },
            fail: function () {
                // Replace the div's content with the page method's return.
                $("#divLocation").html("It didn't work");
            }
        });

        $.ajax({
            type: "POST",
            cache: false,
            url: "/job/ajaxcalls/ajaxmethods.asmx/getareas",
            data: "{'LocationId':-1, 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $("#divArea").html(msg.d);
            },
            fail: function () {
                // Replace the div's content with the page method's return.
                $("#divArea").html("It didn't work");
            }
        });

        $.ajax({
            type: "POST",
            cache: false,
            url: "/job/ajaxcalls/ajaxmethods.asmx/getareasdropdown",
            data: "{'LocationId':-1, 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $("#divAreaDropDown").html(msg.d);
            },
            fail: function () {
                // Replace the div's content with the page method's return.
                $("#divAreaDropDown").html("It didn't work");
            }
        });
    });


});

function SalaryChange() {

    $('#txtSalaryLowerBand').val('');
    $('#txtSalaryUpperBand').val('');
    $('#txtSalaryLowerBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));
    $('#txtSalaryUpperBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));

}


function LoadRoles(professionSelectedValue, rolesID) {

    $.ajax({
        type: "POST",
        cache: false,
        url: "/job/ajaxcalls/ajaxmethods.asmx/getrolesjson",
        data: "{'ProfessionId':" + professionSelectedValue + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            // Replace the div's content with the page method's return.
            //$("#divRoleID").replaceWith(msg.d);
            //console.log(data.d);
            //var jsdata = JSON.parse(data.d);
            //console.log(jsdata);
            $('#' + rolesID + ' option').remove();

            $.each(data.d, function (key, value) {
                $('#' + rolesID).append($("<option></option>").val(value.ID).html(value.Value));
            });
        },
        fail: function () {
            // Replace the div's content with the page method's return.
            //$("#divRoleID").html("It didn't work");
        }
    });

}

/*
function SalaryFromChange() {
    var salaryFromId = "";

    $("#salarylowerband option:selected").each(function() {
        salaryFromId += $(this).val();
    });

    var salaryTypeId = "";

    $("#salaryID option:selected").each(function() {
        salaryTypeId += $(this).val();
    });

    $.ajax({
        type: "POST",
        cache: false,
        url: "/job/ajaxcalls/ajaxmethods.asmx/GetSalaryRangeTo",
        data: "{'salaryTypeid': '" + salaryTypeId + "','SalaryValueSet': '" + salaryFromId + "'" + ", 'IsDynamicWidget':" + IsDynamicWidgetTemp + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
            // Replace the div's content with the page method's return.
            $("#divSalaryTo").html(msg.d);
        },
        fail: function() {
            // Replace the div's content with the page method's return.
            $("#divSalaryTo").html("It didn't work");
        }
    });
}*/

/* End of Advanced Search */

/* Get Advanced Search Values */
var strValue = '?search=1';
function JobSearch(url) {
    if (url == null)
        url = '';

    strValue = '?search=1';

    GetValues("keywords");
    GetValues("professionID");
    GetValues("roleIDs");
    GetValues("countryID");
    GetValues("locationID");
    GetValues("areaIDs");
    GetValues("salaryID");
    GetValues("salarylowerband");
    GetValues("salaryupperband");
    GetValues("workTypeID");
    GetValues("advertiserid");
    
    
    if (strValue.indexOf("&", 0) < 1) {
        var str = url + "/advancedsearch.aspx?search=1";
        var load = window.open(str, "_top");
    }
    else {
        var str = url + "/advancedsearch.aspx";
        var finalPage = str + strValue;

        var load = window.open(finalPage, "_top");
    }
}

function GetValues(variableID) {
    var _value = $.trim($('#' + variableID).val());
    if (_value != "" && _value != "-1" && _value != "0") {
        if (variableID == 'salarylowerband' || variableID == 'salaryupperband')
            strValue = strValue + "&" + variableID + "=1;" + encodeURIComponent(_value);
        else
            strValue = strValue + "&" + variableID + "=" + encodeURIComponent(_value);
    }
}

/* End */


/* Get Advanced Search Values */
var strValue = '?search=1';
function SiteSearch(url) {
    if (url == null)
        url = '';

    strValue = '?search=1';

    GetValues("keywords");
    GetValues("language");

    if (strValue.indexOf("&", 0) < 1) {
        alert('Please select at least one of the fields.');
        //return false;
    }
    else {
        var str = url + "/sitesearch.aspx";
        var finalPage = str + strValue;

        var load = window.open(finalPage, "_top");
    }
}

/* Start of Save Job */
var saveJobRequesting = false;
function SaveJob(callerObj, varJobID, intJobID) {

    if (!saveJobRequesting) {
        saveJobRequesting = true;

        var blnOpenUrl = false;

        //    $("a.search-result-save-job-link").click(function (e) {
        //        e.preventDefault();
        //    });

        //
        var saveJobOrignialObject = callerObj;

        $(callerObj).replaceWith("<img id='img_" + varJobID + "' src='/images/ajax-loading.gif' />");


        $.ajax({
            type: "POST",
            cache: false,
            url: "/job/ajaxcalls/ajaxmethods.asmx/savejobformember",
            data: "{'JobID':" + intJobID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            //async: false,
            success: function (msg) {
                //
                //$("#messageBox").html(msg.d);
                //console.log(msg.d);
                $("#img_" + varJobID).replaceWith(saveJobOrignialObject);
                console.log(msg.d.Success);
                switch (msg.d.Action) {
                    case "Login":
                        //$(".search-result-save-job-link").removeAttr('disabled');
                        blnOpenUrl = true;
                        location.href = '/member/mysavedjobs.aspx?id=' + intJobID;

                        break;

                    case "Deleted":
                        $.each($("." + varJobID), function (i, l) {
                            $(this).text(msg.d.Message).removeClass('job-saved');
                        });

                        break;
                    case "Saved":
                        $.each($("." + varJobID), function (i, l) {
                            $(this).text(msg.d.Message).addClass('job-saved');
                        });
                        break;
                    default:
                        break;
                }


                /*
                $(".search-result-save-job-link").each(function () {
                //$(this).removeAttr('disabled');
                $(this).unbind('click');
                //console.log('Enabled: ' + $(this).attr('id'));

                });*/


            },
            fail: function () {

                location.href = '/member/mysavedjobs.aspx?id=' + intJobID;
                blnOpenUrl = true;
            },
            complete: function (a, b) {
                saveJobRequesting = false;
            }
        });

        //$("#" + varJobID).removeAttr('disabled');

        /*}
        else {
        $("#messageBox").html("Already Saved");
        }*/

        //$('#messageBox').css("left", offset.left + "px");
        //$('#messageBox').css("top", offset.top + 15 + "px");
        //$('#messageBox').fadeTo("slow", 1).animate({ opacity: 1.0 }, 1000).fadeTo("slow", 0);

        return blnOpenUrl;
    }
    return false;
}

function SaveSelectedJobs() {
    var ids = "";
    $("input:checkbox[name=chkSaveJob]:checked").each(function() {
        // add $(this).val() to your array
        if (ids == "")
            ids = ($(this).val());
        else
            ids = ids + "," + ($(this).val());

    });

    window.location = "/member/mysavedjobs.aspx?id=" + ids;
}
/* End of Save Job */



/* Start of Modal popup for Candidate and Advertiser */
$(document).ready(function () {
    $('#boardy-popup').appendTo('body');

    //select all the a tag with name equal to modal
    $('a[name=boardy-modal]').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();

        //Get the A tag
        var id = $(this).attr('href');

        //insert title and content
        $(id + " .boardy-poptitle").html($(this).attr('data-title'));
        $(id + " .boardy-popcontent").html($(this).attr('data-content'));

        //Get the screen height and width
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        //Set heigth and width to mask to fill up the whole screen
        $('#boardy-popshadow').css({ 'width': maskWidth, 'height': maskHeight });

        //transition effect		
        $('#boardy-popshadow').fadeIn(500);
        $('#boardy-popshadow').fadeTo("fast", 0.7);

        //Get the window height and width
        var winH = $(window).height();
        var winW = $(window).width();

        //Set the popup window to center
        //$(id).css('top',  winH/2-$(id).height()/2);
        $(id).css('left', winW / 2 - $(id).width() / 2);

        //transition effect
        $(id).fadeIn(500);

    });

    //if boardy-popclose button is clicked
    $('.window .boardy-popclose').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();

        $('#boardy-popshadow').hide();
        $('.window').hide();
    });

    //if mask is clicked
    $('#boardy-popshadow').click(function () {
        $(this).hide();
        $('.window').hide();
    });

    $(window).resize(function () {

        var box = $('#boardy-popup .window');

        //Get the screen height and width
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        //Set height and width to mask to fill up the whole screen
        $('#boardy-popshadow').css({ 'width': maskWidth, 'height': maskHeight });

        //Get the window height and width
        var winH = $(window).height();
        var winW = $(window).width();

        //Set the popup window to center
        //box.css('top',  winH/2 - box.height()/2);
        box.css('left', winW / 2 - box.width() / 2);

    });


    /* Start of Dropdown toggle */
    $(document).click(function (e) {
        var target = e.target;
        if (!$(target).is('.boardy-dropdown-toggle') && !$(target).parents().is('.boardy-dropdown-toggle')) {
            $('.boardy-dropdown').hide();
        }
    });
    /* End of Dropdown toggle */

});

function BoardyDropDownToggle(target) {
    $(target).next('.boardy-dropdown').toggle();
    //return false;
}

/* End of Modal popup for Candidate and Advertiser */

/* Code For Side Drop Down For Advertiser */
function initMenu() {
    //$('#side-drop-menu ul').hide();
    $('#side-drop-menu li a').click(
    function () {
        $(this).next().slideToggle('normal');
    }
    );
}
$(document).ready(function () { initMenu(); });
