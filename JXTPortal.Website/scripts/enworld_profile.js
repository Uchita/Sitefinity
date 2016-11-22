/*
Copyright (c) 2011, Daniel Guerrero
All rights reserved.
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
* Redistributions of source code must retain the above copyright
notice, this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright
notice, this list of conditions and the following disclaimer in the
documentation and/or other materials provided with the distribution.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL DANIEL GUERRERO BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

/**
* Uses the new array typed in javascript to binary base64 encode/decode
* at the moment just decodes a binary base64 encoded
* into either an ArrayBuffer (decodeArrayBuffer)
* or into an Uint8Array (decode)
* 
* References:
* https://developer.mozilla.org/en/JavaScript_typed_arrays/ArrayBuffer
* https://developer.mozilla.org/en/JavaScript_typed_arrays/Uint8Array
*/

var Base64Binary = {
    _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

    /* will return a  Uint8Array type */
    decodeArrayBuffer: function (input) {
        var bytes = (input.length / 4) * 3;
        var ab = new ArrayBuffer(bytes);
        this.decode(input, ab);

        return ab;
    },

    removePaddingChars: function (input) {
        var lkey = this._keyStr.indexOf(input.charAt(input.length - 1));
        if (lkey == 64) {
            return input.substring(0, input.length - 1);
        }
        return input;
    },

    decode: function (input, arrayBuffer) {
        //get last chars to see if are valid
        input = this.removePaddingChars(input);
        input = this.removePaddingChars(input);

        var bytes = parseInt((input.length / 4) * 3, 10);

        var uarray;
        var chr1, chr2, chr3;
        var enc1, enc2, enc3, enc4;
        var i = 0;
        var j = 0;

        if (arrayBuffer)
            uarray = new Uint8Array(arrayBuffer);
        else
            uarray = new Uint8Array(bytes);

        input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

        for (i = 0; i < bytes; i += 3) {
            //get the 3 octects in 4 ascii chars
            enc1 = this._keyStr.indexOf(input.charAt(j++));
            enc2 = this._keyStr.indexOf(input.charAt(j++));
            enc3 = this._keyStr.indexOf(input.charAt(j++));
            enc4 = this._keyStr.indexOf(input.charAt(j++));

            chr1 = (enc1 << 2) | (enc2 >> 4);
            chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
            chr3 = ((enc3 & 3) << 6) | enc4;

            uarray[i] = chr1;
            if (enc3 != 64) uarray[i + 1] = chr2;
            if (enc4 != 64) uarray[i + 2] = chr3;
        }

        //Mod to return binary array instead decimal array
        var decimalArray = new Array();
        for (var i = 0; i < uarray.length; i++) {
            //convert to binary string
            var binaryString = zeroFill(parseInt(uarray[i], 10).toString(2), 8); //always fill 8 bit

            for (var k = 0; k < binaryString.length; k++) {
                decimalArray.push(binaryString[k]);
            }
        }

        return decimalArray;
    }
}

function zeroFill(number, width) {
    width -= number.toString().length;
    if (width > 0) {
        return new Array(width + (/\./.test(number) ? 2 : 1)).join('0') + number;
    }
    return number + ""; // always return a string
}

function ShowNextTab() {

    var currentTab = $("#profileNavTabs li.active");

    if ($(currentTab).next("li").length > 0) {
        $(currentTab).next("li").find("a").click();
    }

    ShowHideNextPrevButtons();
}

function ShowPrevTab() {
    var currentTab = $("#profileNavTabs li.active");

    if ($(currentTab).prev("li").length > 0) {
        $(currentTab).prev("li").find("a").click();
    }

    ShowHideNextPrevButtons();
}

function ShowHideNextPrevButtons() {

    //detect the new current tab
    currentTab = $("#profileNavTabs li.active");

    //reset the prev button
    $("#formPrevBtn").removeClass("hide");
    //reset the next button
    $("#formNextBtn").removeClass("hide");

    if ($(currentTab).prev("li").length == 0) {
        $("#formPrevBtn").addClass("hide");
    }

    if ($(currentTab).next("li").length == 0) {
        $("#formNextBtn").addClass("hide");
    }
}

function NavTabDirectClick(isFirst, isLast) {

    //reset the prev button
    $("#formPrevBtn").removeClass("hide");
    //reset the next button
    $("#formNextBtn").removeClass("hide");

    if (isFirst)
        $("#formPrevBtn").addClass("hide");

    if (isLast)
        $("#formNextBtn").addClass("hide");

}



function DependantPicklistValuesGet(ddType, target) {

    switch (ddType) {

        case "skill":
            ProcessDependDropDown(target, skill__c, skill__name__c, $("#SkillNameDDL"), ddType);
            break;
        case "sector":
            ProcessDependDropDown(target, sector_experience__c, sector_detail__c, $("#SecDetailDDL"), ddType);
            break;
        case "jobfunction":
            ProcessDependDropDown(target, job_function__c, job_function_experience__c, $("#JobFuncExpDDL"), ddType);
            break;
    }
}

function ProcessDependDropDown(caller, dependantList, dependedList, targetDDL, type) {
    var selectedTxtValue = $(caller).val();

    if (selectedTxtValue == -1) {
        $(targetDDL).empty().append("<option value=\"-1\">- Please select a " + type + " -</option>");
    }
    else {
        //find this dependantList index
        var thisDependObjIndex;
        $.each(dependantList, function (index, value) {
            if (value.value == selectedTxtValue) {
                thisDependObjIndex = index;
                return;
            }
        });

        //loop dependedList and find matching "validFor"
        var validDependantSelectValue = new Array();
        $.each(dependedList, function (index, value) {

            var bitArray = Base64Binary.decode(value.validFor);

            if (parseInt(bitArray[thisDependObjIndex]) == 1)
                validDependantSelectValue.push(value);
        });

        //assign to dropdown
        $(targetDDL).empty();
        $.each(validDependantSelectValue, function (index, value) {
            var optionValue = $("<option></option").html(value.label).attr("value", value.value);
            $(targetDDL).append(optionValue);
        });
    }
}

function DropDownSelectedValueCheck(dependantSelectedVal, dependedSelectedVal, dependantList, dependedList, messageObjID) {

    //find this dependantList index
    var thisDependObjIndex;
    $.each(dependantList, function (index, value) {
        if (value.value == dependantSelectedVal) {
            thisDependObjIndex = index;
            return;
        }
    });

    if (thisDependObjIndex == null)
        return false;

    //loop dependedList and find matching "validFor"
    var validDependantSelectedValue = false;
    $.each(dependedList, function (index, value) {

        if (value.value == dependedSelectedVal) {
            var bitArray = Base64Binary.decode(value.validFor);

            if (parseInt(bitArray[thisDependObjIndex]) == 1)
                validDependantSelectedValue = true;
        }
    });

    return validDependantSelectedValue;

}

function SFObjAdd(type, dependantListObj, dependedListObj, messageObjID) {

    var targetDependantVarList, targetDependedVarList;

    switch (type) {
        case "skill":
            targetDependantVarList = skill__c; targetDependedVarList = skill__name__c;
            break;
        case "sector":
            targetDependantVarList = sector_experience__c; targetDependedVarList = sector_detail__c;
            break;
        case "jobfunction":
            targetDependantVarList = job_function__c; targetDependedVarList = job_function_experience__c;
            break;
    }

    //clear error msg first
    $("#" + messageObjID).empty();

    //value check
    if (!DropDownSelectedValueCheck($(dependantListObj).val(), $(dependedListObj).val(), targetDependantVarList, targetDependedVarList, messageObjID)) {
        $("#" + messageObjID).html("Please select a valid value for both of the drop down lists.");
        return;
    }

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                //add to list of display
                var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SFObjDelete('" + type + "', '" + result.jsonVal.d.EntityID + "', '" + messageObjID + "')\"><i class=\"fa fa-times\"></i>Delete</button>";

                $("#" + type + "Table tbody").append("<tr id=\"" + type + result.jsonVal.d.EntityID + "\"><td>" + $(dependantListObj).val() + "</td><td>" + $(dependedListObj).val() + "</td><td class=\"text-right\">" + buttons + "</td></tr>");

                //reset
                $(dependantListObj).val(-1);
                $(dependedListObj).empty().append("<option value=\"-1\">- Please select a " + type + " -</option>");
            }
            else {
                $("#" + messageObjID).append(result.jsonVal.d.Message);
            }
        }
    };

    var onFailure = function (result) {
    };

    $("#" + messageObjID).empty();
    var data = { dependantValue: $(dependantListObj).val(), dependedValue: $(dependedListObj).val(), objType: type };
    var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfobjadd", "POST", "json", data, onSuccess, onFailure);

}

function SFObjDelete(type, ID, messageObjID) {

    //clear error msg first
    $("#" + messageObjID).empty();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                $("tr#" + type + ID).remove();
            }
            else {
                $("#" + messageObjID).append(result.jsonVal.d.Message);
            }
        }
    };

    var onFailure = function (result) {
    };

    var data = { sfID: ID, objType: type };
    var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfobjdelete", "POST", "json", data, onSuccess, onFailure);
}

function SectorExpReferenceAdd(targetID, sectorExpRefStore, messageObjID, editSaveOnCompleteFunc) {

    //clear error msg first
    $("#" + messageObjID).empty();

    //check minimum fields
    if ($("#secExpRefName").val().length > 0 || $("#secExpRefComp").val().length > 0 || $("#secExpRefRole").val().length > 0 || $("#secExpRefPhone").val().length > 0 || $("#secExpRefEmail").val().length > 0) {
        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    var newRecord = jQuery.parseJSON(result.jsonVal.d.RecordJson);

                    //replace record from store
                    if (targetID != null) {
                        $.each(sectorExpRefStore, function (index, value) {
                            if (value["Id"] == targetID) {
                                sectorExpRefStore[index] = newRecord;

                                var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpReferenceEdit('" + result.jsonVal.d.EntityID + "', sector_reference_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpReferenceDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                                $("#secExpRefTable tbody tr#secExpRef" + targetID).empty().append("<td>" + $("#secExpRefName").val() + "</td><td>" + $("#secExpRefComp").val() + "</td><td>" + $("#secExpRefRole").val() + "</td><td>" + $("#secExpRefPhone").val() + "</td><td>" + $("#secExpRefEmail").val() + "</td><td class=\"text-right\">" + buttons + "</td>");

                                editSaveOnCompleteFunc();

                                return;
                            }
                        });
                    }
                    else {
                        //add to store
                        sectorExpRefStore.push(newRecord);
                        //add to list of display
                        var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpReferenceEdit('" + result.jsonVal.d.EntityID + "', sector_reference_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpReferenceDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                        $("#secExpRefTable tbody").append("<tr id=\"secExpRef" + result.jsonVal.d.EntityID + "\"><td>" + $("#secExpRefName").val() + "</td><td>" + $("#secExpRefComp").val() + "</td><td>" + $("#secExpRefRole").val() + "</td><td>" + $("#secExpRefPhone").val() + "</td><td>" + $("#secExpRefEmail").val() + "</td><td class=\"text-right\">" + buttons + "</td></tr>");
                    }

                    //reset
                    $("#secExpRefName, #secExpRefComp, #secExpRefRole, #secExpRefPhone, #secExpRefEmail").val("");
                }
                else {
                    var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                    $("#" + messageObjID).append(decrypt[0].message);
                }
            }
        };

        var onFailure = function (result) {
        };

        var data = { SFID: targetID, refName: $("#secExpRefName").val(), refComp: $("#secExpRefComp").val(), refRole: $("#secExpRefRole").val(), refPhone: $("#secExpRefPhone").val(), refEmail: $("#secExpRefEmail").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfsecexprefadd", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        $("#" + messageObjID).append("At least one field is required");
    }

}

function SectorExpReferenceEdit(ID, sectorExpRefStore, messageObjID) {

    //reset all table rows color
    $("#secExpRefTable tr").removeClass("success");

    var thisSectoExpRef;

    $.each(sectorExpRefStore, function (index, value) {
        if (value["Id"] == ID) {
            thisSectoExpRef = value;
            return;
        }
    });

    if (thisSectoExpRef == null)
        $("#" + messageObjID).html("Failed to load object, please refresh the page and try again");
    else {

        $("#secExpRefName").val(thisSectoExpRef["ts2__Name__c"]);
        $("#secExpRefComp").val(thisSectoExpRef["ts2__Company__c"]);
        $("#secExpRefRole").val(thisSectoExpRef["ts2__Role_Title__c"]);
        $("#secExpRefPhone").val(thisSectoExpRef["ts2__Phone__c"]);
        $("#secExpRefEmail").val(thisSectoExpRef["ts2__Email__c"]);

        $("#secExpRef" + ID).addClass("success");

        $("#SectorExpRefAddBtns").addClass("hide");
        $("#SectorExpRefEditBtns").removeClass("hide");

        $("#SectorExpRefEditBtns .btn-edit").attr("data-target", thisSectoExpRef["Id"]);

    }
}

function SectorExpReferenceSave(caller, sectorExpRefStore, messageObjID) {

    $("#" + messageObjID).empty();

    var targetID = $(caller).attr("data-target");

    if (targetID.length == 0)
        $("#" + messageObjID).html("Target ID is missing. Please reload the page and try again.");
    else {

        var onCompFunc = function () {
            $("#secExpRefTable tbody tr").removeClass("success");
            $("#SectorExpRefAddBtns").removeClass("hide");
            $("#SectorExpRefEditBtns").addClass("hide");
        };

        SectorExpReferenceAdd(targetID, sectorExpRefStore, messageObjID, onCompFunc);
    }
}



function SectorExpReferenceDelete(ID, messageObjID) {

    //clear error msg first
    $("#" + messageObjID).empty();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                $("tr#secExpRef" + ID).remove();
            }
            else {
                var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                $("#" + messageObjID).append(decrypt[0].message);
            }
        }
    };

    var onFailure = function (result) {
    };

    var data = { sfID: ID };
    var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfsecexprefdelete", "POST", "json", data, onSuccess, onFailure);
}

function SectorExpExperienceAdd(targetID, sectorExpExpStore, messageObjID, editSaveOnCompleteFunc) {

    //clear error msg first
    $("#" + messageObjID).empty();

    //check minimum fields
    if (($("#tbSecExpJobTitle").val().length > 0 || $("#tbSecExpCompanyName").val().length > 0 || $("#tbSecExpJobLocation").val().length > 0 || $("#tbSecExpReason").val().length > 0) && $("#tbSecExpStart").val().length > 0 && $("#tbSecExpEnd").val().length > 0) {
        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    var newRecord = jQuery.parseJSON(result.jsonVal.d.RecordJson);

                    //replace record from store
                    if (targetID != null) {
                        $.each(sectorExpExpStore, function (index, value) {
                            if (value["Id"] == targetID) {
                                sectorExpExpStore[index] = newRecord;

                                var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpExperienceEdit('" + result.jsonVal.d.EntityID + "', sector_experience_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpExperienceDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                                $("#secExpExperienceTable tbody tr#secExpExp" + targetID).empty().append("<td>" + $("#tbSecExpCompanyName").val() + "</td><td>" + $("#tbSecExpJobTitle").val() + "</td><td>" + $("#tbSecExpJobLocation").val() + "</td><td>" + $("#tbSecExpStart").val() + "</td><td>" + $("#tbSecExpEnd").val() + "</td><td class=\"text-right\">" + buttons + "</td>");

                                editSaveOnCompleteFunc();

                                return;
                            }
                        });
                    }
                    else {
                        //add to store
                        sectorExpExpStore.push(newRecord);
                        //add to list of display
                        var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpExperienceEdit('" + result.jsonVal.d.EntityID + "', sector_experience_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"SectorExpExperienceDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";

                        $("#secExpExperienceTable tbody").append("<tr id=\"secExpExp" + result.jsonVal.d.EntityID + "\"><td>" + $("#tbSecExpCompanyName").val() + "</td><td>" + $("#tbSecExpJobTitle").val() + "</td><td>" + $("#tbSecExpJobLocation").val() + "</td><td>" + $("#tbSecExpStart").val() + "</td><td>" + $("#tbSecExpEnd").val() + "</td><td class=\"text-right\">" + buttons + "</td></tr>");
                    }


                    //reset
                    $("#tbSecExpJobTitle, #tbSecExpCompanyName, #tbSecExpJobLocation, #tbSecExpReason").val("");
                    var today = new Date();
                    $("#tbSecExpStart, #tbSecExpEnd").val(today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + zeroFill(today.getDate(), 2));
                }
                else {
                    var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                    $("#" + messageObjID).append(decrypt[0].message);
                }
            }
        };

        var onFailure = function (result) {
        };

        var data = { SFID: targetID, expTitle: $("#tbSecExpJobTitle").val(), expCompany: $("#tbSecExpCompanyName").val(), expLocation: $("#tbSecExpJobLocation").val(), expReason: $("#tbSecExpReason").val(), expStart: $("#tbSecExpStart").val(), expEnd: $("#tbSecExpEnd").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfsecexpexperienceadd", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        $("#" + messageObjID).append("At least one field is required");
    }
}

function SectorExpExperienceEdit(ID, sectorExpExpStore, messageObjID) {

    //reset all table rows color
    $("#secExpExperienceTable tr").removeClass("success");

    var thisSectoExpExp;

    $.each(sectorExpExpStore, function (index, value) {
        //console.log(value["Id"] + "||" + ID);
        if (value["Id"] == ID) {
            thisSectoExpExp = value;
            return;
        }
    });

    if (thisSectoExpExp == null)
        $("#" + messageObjID).html("Failed to load object, please refresh the page and try again");
    else {
        $("#tbSecExpJobTitle").val(thisSectoExpExp["ts2__Job_Title__c"]);
        $("#tbSecExpCompanyName").val(thisSectoExpExp["ts2__Name__c"]);
        $("#tbSecExpJobLocation").val(thisSectoExpExp["ts2__Location__c"]);
        $("#tbSecExpReason").val(thisSectoExpExp["Resume_RFL__c"]);
        $("#tbSecExpStart").val(thisSectoExpExp["ts2__Employment_Start_Date__c"]);
        $("#tbSecExpEnd").val(thisSectoExpExp["ts2__Employment_End_Date__c"]);

        $("#secExpExp" + ID).addClass("success");

        $("#SectorExpExpAddBtns").addClass("hide");
        $("#SectorExpExpEditBtns").removeClass("hide");

        $("#SectorExpExpEditBtns .btn-edit").attr("data-target", thisSectoExpExp["Id"]);

    }
}

function SectorExpExperienceSave(caller, sectorExpExpStore, messageObjID) {

    $("#" + messageObjID).empty();

    var targetID = $(caller).attr("data-target");

    if (targetID.length == 0)
        $("#" + messageObjID).html("Target ID is missing. Please reload the page and try again.");
    else {

        var onCompFunc = function () {
            $("#secExpExperienceTable tbody tr").removeClass("success");
            $("#SectorExpExpAddBtns").removeClass("hide");
            $("#SectorExpExpEditBtns").addClass("hide");
        };

        SectorExpExperienceAdd(targetID, sectorExpExpStore, messageObjID, onCompFunc);
    }
}



function SectorExpExperienceDelete(ID, messageObjID) {

    //clear error msg first
    $("#" + messageObjID).empty();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                $("tr#secExpExp" + ID).remove();
            }
            else {
                var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                $("#" + messageObjID).append(decrypt[0].message);
            }
        }
    };

    var onFailure = function (result) {
    };

    var data = { sfID: ID };
    var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfsecexpexperiencedelete", "POST", "json", data, onSuccess, onFailure);
}


function EducationAdd(targetID, educationStore, messageObjID, editSaveOnCompleteFunc) {

    //clear error msg first
    $("#" + messageObjID).empty();

    //check minimum fields
    if ($("#tbEduInstitution").val().length > 0 || $("#tbEduMajor").val().length > 0) {
        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    var newRecord = jQuery.parseJSON(result.jsonVal.d.RecordJson);

                    //replace record from store
                    if (targetID != null) {
                        $.each(educationStore, function (index, value) {
                            if (value["Id"] == targetID) {
                                educationStore[index] = newRecord;

                                var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EducationEdit('" + result.jsonVal.d.EntityID + "', education_history_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EducationDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                                $("#eduHistoryTable tbody tr#eduHistory" + targetID).empty().append("<td>" + $("#tbEduInstitution").val() + "</td><td>" + $("#ddlEduDegree").val() + "</td><td>" + $("#tbEduMajor").val() + "</td><td>" + $("#ddlEduGradYear").val() + "</td><td class=\"text-right\">" + buttons + "</td>");

                                editSaveOnCompleteFunc();

                                return;
                            }
                        });
                    }
                    else {
                        //add to store
                        educationStore.push(newRecord);
                        //add to list of display
                        var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EducationEdit('" + result.jsonVal.d.EntityID + "', education_history_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"EducationDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                        $("#eduHistoryTable tbody").append("<tr id=\"eduHistory" + result.jsonVal.d.EntityID + "\"><td>" + $("#tbEduInstitution").val() + "</td><td>" + $("#ddlEduDegree").val() + "</td><td>" + $("#tbEduMajor").val() + "</td><td>" + $("#ddlEduGradYear").val() + "</td><td class=\"text-right\">" + buttons + "</td></tr>");
                    }

                    //reset
                    $("#tbEduInstitution, #tbEduMajor").val("");
                    $("#ddlEduGradYear option:first-child, #ddlEduDegree option:first-child").attr("selected", "selected");
                }
                else {
                    var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                    $("#" + messageObjID).append(decrypt[0].message);
                }
            }
        };

        var onFailure = function (result) {
        };

        var data = { SFID: targetID, refInstitution: $("#tbEduInstitution").val(), refDegree: $("#ddlEduDegree").val(), refMajor: $("#tbEduMajor").val(), refYear: $("#ddlEduGradYear").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfeduhistoryadd", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        $("#" + messageObjID).append("At least one field is required");
    }
}


function EducationEdit(ID, educationStore, messageObjID) {

    //reset all table rows color
    $("#eduHistoryTable tr").removeClass("success");

    var thisEducation;

    $.each(educationStore, function (index, value) {
        if (value["Id"] == ID) {
            thisEducation = value;
            return;
        }
    });

    if (thisEducation == null)
        $("#" + messageObjID).html("Failed to load object, please refresh the page and try again");
    else {
        $("#tbEduInstitution").val(thisEducation["ts2__Name__c"]);
        $("#ddlEduDegree").val(thisEducation["ts2__DegreePicklist__c"]);
        $("#tbEduMajor").val(thisEducation["ts2__Major__c"]);
        $("#ddlEduGradYear").val(thisEducation["ts2__Graduation_Year__c"]);

        $("#eduHistory" + ID).addClass("success");

        $("#EduHistAddBtns").addClass("hide");
        $("#EduHistEditBtns").removeClass("hide");

        $("#EduHistEditBtns .btn-edit").attr("data-target", thisEducation["Id"]);

    }
}

function EducationSave(caller, educationStore, messageObjID) {

    $("#" + messageObjID).empty();

    var targetID = $(caller).attr("data-target");

    if (targetID.length == 0)
        $("#" + messageObjID).html("Target ID is missing. Please reload the page and try again.");
    else {

        var onCompFunc = function () {
            $("#eduHistoryTable tbody tr").removeClass("success");
            $("#EduHistAddBtns").removeClass("hide");
            $("#EduHistEditBtns").addClass("hide");
        };

        EducationAdd(targetID, educationStore, messageObjID, onCompFunc);
    }
}




function EducationDelete(ID, messageObjID) {

    //clear error msg first
    $("#" + messageObjID).empty();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                $("tr#eduHistory" + ID).remove();
            }
            else {
                var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                $("#" + messageObjID).append(decrypt[0].message);
            }
        }
    };

    var onFailure = function (result) {
    };

    var data = { sfID: ID };
    var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfeduhistorydelete", "POST", "json", data, onSuccess, onFailure);
}



function EditCancel(addBtnID, editBtnID, formWrapID, dataTableDisplayID) {

    $("#" + addBtnID).removeClass("hide");
    $("#" + editBtnID).addClass("hide");

    //reset all table rows color
    $("#" + dataTableDisplayID + " tr").removeClass("success");

    $("#" + editBtnID + " .btn-edit").removeAttr("data-target");


    $.each($("#" + formWrapID).find("input[type=text], select"), function (index, value) {
        if ($(this).is("input")) {

            if ($(this).hasClass("dateInput")) {
                var today = new Date();
                $(this).val(today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + zeroFill(today.getDate(), 2));
            }
            else {
                $(this).val("");
            }
        }
        else if ($(this).is("select")) {
            $(this).find("option:first-child").attr("selected", "selected");
        }
    });


}

/* ------------------------------------------------ */


function Tab1Save(sender, loader) {

    //clear error msg first
    $(".errormsg").empty();

    //check minimum fields
    if ($("#ddlCountry").val() != "--None--" && $("#ddlNativeLanguage").val() != "--None--" ) {

        $(loader).removeClass("hide");
        $(sender).addClass("disabled");

        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    //goto next tab
                    ShowNextTab();
                    $("html, body").animate({ scrollTop: $('body').offset().top }, 500);
                }
                else {
                    var errorMsgs = result.jsonVal.d.Message;

                    if (Object.prototype.toString.call(errorMsgs) === '[object Array]') {

                        $.each(errorMsgs, function (index, value) {
                            $("#tab1Message").append(value + "<br/>");
                        });
                    }
                    else
                        $("#tab1Message").append(errorMsgs);
                }
            }
            else {
                $("#tab1Message").append("Failed to connect to the server, please reload the page and try again.");                
            }
            $(loader).addClass("hide");
            $(sender).removeClass("disabled");
        };

        var onFailure = function (result) {
            $("#tab1Message").append("Failed to connect to the server, please reload the page and try again.");
            $(loader).addClass("hide");
            $(sender).removeClass("disabled");
        };

        var data = { gender: $("#ddlGender").val(), dob: $("#tbDOB").val(), mobile: $("#tbMobilePhone").val(), phone: $("#tbHomePhone").val(), country: $("#ddlCountry").val(), secondEmail: $("#tbSecondEmail").val(), address: $("#tbAddress1").val(), city: $("#tbCity").val(), state: $("#ddlState").val(), zip: $("#tbZip").val(), nativeLang: $("#ddlNativeLanguage").val(), secondLanguage: $("#ddlSecondaryLanguage").val(), secondLanguageLevel: $("#ddlSecondaryLanguageLevel").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "tab1save", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        var fieldsToCheck = ["ddlCountry", "ddlNativeLanguage"];
        GenerateRequiredFieldsMessages(fieldsToCheck);
        //$("#tab1Message").append("At least one field is required");
    }
}

function Tab2Save(sender, loader) {

    //clear error msg first
    $(".errormsg").empty();

    if ($("#tbFixedSalary").val().length > 0 && ! $.isNumeric($("#tbFixedSalary").val()) ) {
        $("#tbFixedSalaryMsg").empty().append("Fixed salary must be in numeric form");
        return;
    }

    if ($("#tbIncentiveSalary").val().length > 0 && !$.isNumeric($("#tbIncentiveSalary").val())) {
        $("#tbIncentiveSalaryMsg").empty().append("Incentive salary must be in numeric form");
        return;
    }

    //check minimum fields
    if ($("#tbCurrentCompany").val().length != 0 && $("#tbCurrentJobTitle").val().length != 0
        && $("#ddlIndustry").val().length != 0 && $("#ddlIndustry").val() != "--None--"
        && $("#ddlJobCategory").val().length != 0 && $("#ddlJobCategory").val != "--None--"
        && $("#ddlJobFunctions").val() != null && $("#ddlJobFunctions").val().length != 0 && $("#ddlJobFunctions").val != "--None--"
        && $("#ddlEmploymentType").val().length != 0 && $("#ddlEmploymentType").val() != "--None--") {

        $(loader).removeClass("hide");
        $(sender).addClass("disabled");

        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    //goto next tab
                    ShowNextTab();
                    $("html, body").animate({ scrollTop: $('body').offset().top }, 500);
                }
                else {
                    var errorMsgs = result.jsonVal.d.Message;

                    if (Object.prototype.toString.call(errorMsgs) === '[object Array]') {

                        $.each(errorMsgs, function (index, value) {
                            $("#tab2Message").append(value + "<br/>");
                        });
                    }
                    else
                        $("#tab2Message").append(decrypt[0].message);
                }
            }
            else {
                $("#tab2Message").append("Failed to connect to the server, please reload the page and try again.");
            }
            $(loader).addClass("hide");
            $(sender).removeClass("disabled");
        };

        var onFailure = function (result) {
            $("#tab2Message").append("Failed to connect to the server, please reload the page and try again.");
            $(loader).addClass("hide");
            $(sender).removeClass("disabled");
        };

        var data = { company: $("#tbCurrentCompany").val(), jobtitle: $("#tbCurrentJobTitle").val(), industry: $("#ddlIndustry").val(), jobcategory: $("#ddlJobCategory").val(), jobfunctions: $("#ddlJobFunctions").val(), employmenttype: $("#ddlEmploymentType").val(), salaryperiod: $("#ddlSalaryPeriod").val(), fixedsalary: $("#tbFixedSalary").val(), incentivesalary: $("#tbIncentiveSalary").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "tab2save", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        var fieldsToCheck = ["tbCurrentCompany", "tbCurrentJobTitle", "ddlIndustry", "ddlJobCategory", "ddlJobFunctions", "ddlEmploymentType" ];
        GenerateRequiredFieldsMessages(fieldsToCheck);
    }
}


function Tab3Save(sender, loader) {

    //clear error msg first
    $("#tab3Message2").remove();
    $(".errormsg").empty();

    //check minimum fields
    if ($("#ctl00_ContentPlaceHolder1_ddlPrimDesiredCountry").val() != "--None--" && $("#ddlPrimDesiredLocation").val() != null && $("#ddlDesiredEmployType").val() != null && $("#ddlPrimDesiredIndustry").val() != "--None--" && $("#ctl00_ContentPlaceHolder1_ddlPrimDesiredJobCategory").val() != "--None--" && $("#ddlPrmDesiredJobFunction").val() != "--None--") {


        $(loader).removeClass("hide");
        $(sender).addClass("disabled");
        
        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    //finished
                    $("#tab3Message").after("<div id=\"tab3Message2\" class=\"col-xs-12 alert alert-success\">Profile saved successfully</div>");
                    //setTimeout(function () { $("#tab3Message2").animate({ opacity: 0 }, 500, function () { $(this).remove(); $(sender).removeClass("disabled"); }) }, 2000);
                    $(sender).removeClass("disabled");
                }
                else {
                    var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                    $("#tab3Message").append(decrypt[0].message);
                    $(sender).removeClass("disabled");
                }
            }
            else {
                $("#tab3Message").append("Failed to connect to the server, please reload the page and try again.");
                $(sender).removeClass("disabled");
            }
            $(loader).addClass("hide");
        };

        var onFailure = function (result) {
            $("#tab3Message").append("Failed to connect to the server, please reload the page and try again.");
            $(loader).addClass("hide");
            $(sender).removeClass("disabled");
        };

        var data = { dCountry: $("#ctl00_ContentPlaceHolder1_ddlPrimDesiredCountry").val(), dLocation: $("#ddlPrimDesiredLocation").val(), dEmployType: $("#ddlDesiredEmployType").val(), dIndustry: $("#ddlPrimDesiredIndustry").val(), dJobCate: $("#ctl00_ContentPlaceHolder1_ddlPrimDesiredJobCategory").val(), dJobFunc: $("#ddlPrmDesiredJobFunction").val(), dSecondCountry: $("#ddlSecondDesiredCountry").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "tab3save", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        var fieldsToCheck = ["ctl00_ContentPlaceHolder1_ddlPrimDesiredCountry", "ddlPrimDesiredLocation", "ddlDesiredEmployType", "ddlPrimDesiredIndustry", "ctl00_ContentPlaceHolder1_ddlPrimDesiredJobCategory", "ddlPrmDesiredJobFunction"];
        GenerateRequiredFieldsMessages(fieldsToCheck);
    }
}



function ExperienceAdd(targetID, messageObjID, editSaveOnCompleteFunc) {

    //clear error msg first
    $("#" + messageObjID).empty();

    //check minimum fields
    if ($("#expCompany").val().length > 0 || $("#ddlIndustry").val() != "--None--" || $("#ddlDesiredHiringType").val() != "--None--" || $("#ddlJobFunction").val() != "--None--") {
        //send request
        var onSuccess = function (result) {
            if (result.status) //ajax call success
            {
                if (result.jsonVal.d.Success) //execution success
                {
                    var newRecord = jQuery.parseJSON(result.jsonVal.d.RecordJson);

                    //replace record from store
                    if (targetID != null) {

                        var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"ExperienceEdit('" + result.jsonVal.d.EntityID + "', sector_reference_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"ExperienceDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                        //$("#secExpRefTable tbody tr#secExpRef" + targetID).empty().append("<td>" + $("#secExpRefName").val() + "</td><td>" + $("#secExpRefComp").val() + "</td><td>" + $("#secExpRefRole").val() + "</td><td>" + $("#secExpRefPhone").val() + "</td><td>" + $("#secExpRefEmail").val() + "</td><td class=\"text-right\">" + buttons + "</td>");

                        editSaveOnCompleteFunc();

                    }
                    else {
                        //add to store
                        sectorExpRefStore.push(newRecord);
                        //add to list of display
                        var buttons = "<button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"ExperienceEdit('" + result.jsonVal.d.EntityID + "', sector_reference_records, '" + messageObjID + "');\"><i class=\"fa fa-pencil\"></i>Edit</button><button type=\"button\" class=\"btn btn-success btn-xs\" onclick=\"ExperienceDelete('" + result.jsonVal.d.EntityID + "','" + messageObjID + "');\"><i class=\"fa fa-times\"></i>Delete</button>";
                        $("#secExpRefTable tbody").append("<tr id=\"secExpRef" + result.jsonVal.d.EntityID + "\"><td>" + $("#secExpRefName").val() + "</td><td>" + $("#secExpRefComp").val() + "</td><td>" + $("#secExpRefRole").val() + "</td><td>" + $("#secExpRefPhone").val() + "</td><td>" + $("#secExpRefEmail").val() + "</td><td class=\"text-right\">" + buttons + "</td></tr>");
                    }

//                    //reset
//                    $("#secExpRefName, #secExpRefComp, #secExpRefRole, #secExpRefPhone, #secExpRefEmail").val("");
                }
                else {
                    var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                    $("#" + messageObjID).append(decrypt[0].message);
                }
            }
        };

        var onFailure = function (result) {
        };

        var data = { expComp: $("#expCompany").val(), expInd: $("#ddlIndustry").val(), expHireType: $("#ddlDesiredHiringType").val(), expJobFunc: $("#ddlJobFunction").val(), expJobTitle: $("#expJobTitle").val(), expStartDate: $("#expStartDate").val(), expEndDate: $("#expEndDate").val(), expSalaryPeriod: $("#ddlSalaryPeriod").val(), expFixedSalary: $("#expFixedSalary").val(), expIncentive: $("#expIncentiveSalary").val(), expTotalSalary: $("#expTotalSalary").val() };
        var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sdexperienceadd", "POST", "json", data, onSuccess, onFailure);
    }
    else {
        $("#" + messageObjID).append("At least one field is required");
    }

}

function ExperienceEdit(ID, sectorExpRefStore, messageObjID) {

    //reset all table rows color
//    $("#secExpRefTable tr").removeClass("success");

//    var thisSectoExpRef;

//    $.each(sectorExpRefStore, function (index, value) {
//        if (value["Id"] == ID) {
//            thisSectoExpRef = value;
//            return;
//        }
//    });

//    if (thisSectoExpRef == null)
//        $("#" + messageObjID).html("Failed to load object, please refresh the page and try again");
//    else {

//        $("#secExpRefName").val(thisSectoExpRef["ts2__Name__c"]);
//        $("#secExpRefComp").val(thisSectoExpRef["ts2__Company__c"]);
//        $("#secExpRefRole").val(thisSectoExpRef["ts2__Role_Title__c"]);
//        $("#secExpRefPhone").val(thisSectoExpRef["ts2__Phone__c"]);
//        $("#secExpRefEmail").val(thisSectoExpRef["ts2__Email__c"]);

//        $("#secExpRef" + ID).addClass("success");

//        $("#SectorExpRefAddBtns").addClass("hide");
//        $("#SectorExpRefEditBtns").removeClass("hide");

//        $("#SectorExpRefEditBtns .btn-edit").attr("data-target", thisSectoExpRef["Id"]);

//    }
}

function SectorExpReferenceSave(caller, sectorExpRefStore, messageObjID) {

//    $("#" + messageObjID).empty();

//    var targetID = $(caller).attr("data-target");

//    if (targetID.length == 0)
//        $("#" + messageObjID).html("Target ID is missing. Please reload the page and try again.");
//    else {

//        var onCompFunc = function () {
//            $("#secExpRefTable tbody tr").removeClass("success");
//            $("#SectorExpRefAddBtns").removeClass("hide");
//            $("#SectorExpRefEditBtns").addClass("hide");
//        };

//        SectorExpReferenceAdd(targetID, sectorExpRefStore, messageObjID, onCompFunc);
//    } 
}



function ExperienceDelete(ID, messageObjID) {

    //clear error msg first
    $("#" + messageObjID).empty();

    var onSuccess = function (result) {
        if (result.status) //ajax call success
        {
            if (result.jsonVal.d.Success) //execution success
            {
                $("tr#secExpExp" + ID).remove();
            }
            else {
                var decrypt = jQuery.parseJSON(result.jsonVal.d.Message);
                $("#" + messageObjID).append(decrypt[0].message);
            }
        }
    };

    var onFailure = function (result) {
    };

    var data = { sfID: ID };
    var postResult = $("").sendAjaxWithExpectDataTypeReturn("member/enworld/profile.aspx", "sfsecexpexperiencedelete", "POST", "json", data, onSuccess, onFailure);
}



function GenerateRequiredFieldsMessages(fieldsList) {

    $.each(fieldsList, function (index, value) {

        $("#" + value + "Msg").empty();

        if ($("#" + value).val() == null || $("#" + value).val() == "--None--" || $("#" + value).val().length < 1) {
            $("#" + value + "Msg").append("This field is required"); // + $("#" + value).val() + ' ' + $("#" + value).text()
        }
        // ($("#" + value).val() == "--None--" && $("#" + value).text() != '- Not Available -') ||

    });

}












/*
-- Call this with element eg. $("#inputFormWrapper").sendAjaxWithExpectDataTypeReturn(controller, action, method, expect_return_type, extraparams)
-- This method automatically assign each <input> to data that can be found within this wrapper
-- Extraparams is strings like "a=55&b=44" or can be objs like var extraParam = { a:"1", b: true};
-- Expected Responses from Destinations:
=> When dataType is "html" 
Expected Response from call destination is...          
-- if action performed successfully, return ActionResult of View()
-- if action performed failed (eg Exceptions etc), return a JsonEntity with { status: false, message: errorMsg }       
=> When dataType is "json" 
Expected Response from call destination is...          
-- if action performed successfully, return a JsonEntity with { status: true, message: msgIfAny }  
-- if action performed failed (eg Exceptions etc), return a JsonEntity with { status: false, message: errorMsg }       
-- Return:
=> When dataType is "html" 
Expected Response from call destination is...          
-- Success: { status: true, html: htmlData }
-- Failed: { status: false, message: errorMsg }      
=> When dataType is "json"    
-- Success: json object from response
-- Failed: { status: false, message[]: errorMsgs }   
*/

$.fn.sendAjaxWithExpectDataTypeReturn = function () {
    var ajaxURL = "/" + arguments[0] + "/" + arguments[1];
    var method = arguments[2];
    var dataType = arguments[3];
    var extraQueryParams = arguments[4];
    var onSuccessFunction = arguments[5];
    var onFailFunction = arguments[6];

    var returnValue;
    var querydata = JSON.stringify(extraQueryParams); // getQueryData(this, extraQueryParams);
    //    var a = "";
    //    for (var k in querydata)
    //        a += k + ",";

    $.ajax({
        url: ajaxURL,
        type: method,
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: querydata,
        async: true,
        dataType: dataType,
        success: function (data, textStatus, xmlHttpRequest) {
            //because we want to standardise this ajax call returning objects from server,
            //we have to specificly checks for different expected dataTypes return
            //alert(dataType.toUpperCase());
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
                //other expected dataType return
                returnValue = { status: true, jsonVal: data };
            }

            //run onSuccess
            onSuccessFunction(returnValue);
        },
        error: function (xhr, error) {
            //        alert("error = " + error);
            //         alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.statusText);
            //            alert("responseText: " + xhr.responseText);
            var messageToDisplay = "Could not reach destination or Request failed, please try again";

            try {
                var responseData = jQuery.parseJSON(xhr.responseText);
                //response from error request is json
                messageToDisplay = responseData.message;
            }
            catch (err) { }

            returnValue = { status: false, message: messageToDisplay };

            //run onFailure
            onFailFunction(returnValue);
        }
    });
}


//call this with element eg. $("#inputFormWrapper").sendAjaxWithObjectInput(controller, action, method, expect_return_type, object)
$.fn.sendAjaxWithObjectInput = function () {
    var ajaxURL = "/" + arguments[0] + "/" + arguments[1];
    var method = arguments[2];
    var dataType = arguments[3];
    var objectInput = arguments[4];
    var returnValue;

    $.ajax({
        url: ajaxURL,
        type: method,
        data: objectInput,
        async: false,
        cache: false,
        dataType: dataType,
        success: function (data, textStatus, xmlHttpRequest) {
            //because we want to standardise this ajax call returning objects from server,
            //we have to specificly checks for different expected dataTypes return
            if (dataType.toUpperCase() == "HTML") {
                var contentType = xmlHttpRequest.getResponseHeader("Content-Type");
                if (contentType.indexOf("application/json") >= 0) {
                    //error, because we expecting html
                    //we parse the json and return
                    returnValue = eval('(' + data + ')');
                }
                else if (contentType.indexOf("text/html") >= 0) {
                    //html retreive success
                    returnValue = { status: true, html: data };
                }
            }
            else {
                //other expected dataType return
                returnValue = data;
            }
        },
        error: function (xhr, error) {
            //        alert("error = " + error);
            //         alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.statusText);
            //       alert("responseText: " + xhr.responseText);
            returnValue = { status: false, message: "Could not reach destination or Request failed, please try again" };
        }
    });
    return returnValue;
}


function getQueryData(thisObj, extraQueryParams) {
    //retreive and create data
    var querydata = {};
    var inputQuantity = $(thisObj).find("input, select, textarea").length;
    var counter = 1;

    $.each($(thisObj).find("input, select, textarea"), function () {
        //handle radio inputs because radio inputs have same name but will only be 1 input value
        //to determine, we only find checked radio input to add to query data
        if ($(this).attr("type") == "radio") {
            if ($(this).is(':checked')) {
                if ($(this).attr("name").length > 0)
                    querydata[$(this).attr("name")] = $(this).val();
                else
                    querydata[$(this).attr("class")] = $(this).val();
            }
        }
        else if ($(this).attr("type") == "checkbox") {

            var insertValue;
            if ($(this).is(":checked")) {
                if ($(this).attr("value").length == 0)
                    insertValue = $(this).is(":checked");
                else
                    insertValue = $(this).val();

                //we append using ',' if previously a same element name found
                if ($(this).attr("name").length > 0) {
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
        else {
            var insertValue = $(this).val();

            if ($(this).attr("type") == "textarea" || $(this).attr("type") == "text") {
                //if its textarea, we always encode before we submit
                insertValue = escape(insertValue);
            }

            if ($(this).attr("name").length > 0) {
                querydata[$(this).attr("name")] = insertValue;
            }
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

