function AddNewTypeRow(targetTableID, currentCounter) {

    var lastRow = $(targetTableID + " tr.dataRow:not(.defaultRow)").last();

    var copyRow = lastRow.clone();

    $(copyRow).find("input, select").each(function (idx, value) {

        var thisName = $(value).attr("name");
        var thisNewName = thisName.replace(/\[.+\]/, "[" + rowCounter + "]");

        $(value).attr("name", thisNewName);

        //clear all input text fields when cloning
        if ($(value).is("input[type=text]")) {
            $(value).val("");
        }

    });

    $(lastRow).after(copyRow);

    rowCounter++;
}

function UpdateIDFromDropDown(caller, target) {

    var displayStr = $(caller).val();
    var selectedDDOption = $(caller).find('option:selected');

    if ($(selectedDDOption).data("countryid") != null && $(selectedDDOption).data("locationid") != null) {
        displayStr = $(selectedDDOption).data("countryid") + " / " + $(selectedDDOption).data("locationid") + " / " + $(caller).val()
    }

    if ($(selectedDDOption).data("professionid") != null) {
        displayStr = $(selectedDDOption).data("professionid") + " / " + $(caller).val()
    }


    $(caller).closest(".dataRow").find(target).html(displayStr);
}


function ValidateMappingSelection(formCaller) {

    //currently disabled
    return true;

    //clears
    $("td.has-error").removeClass("has-error");
    $(".jsValidate").remove();

    var formValid = true;

    $(formCaller).find(".mappingSelect").each(function (idx, selectElement) {

        if ($(selectElement).val() == -1) {
            formValid = false;
            var newError = "<span class='jsValidate field-validation-error'>This field is required</span>";
            $(selectElement).after(newError);
            $(selectElement).parent().addClass("has-error");
        }

    });

    return formValid;
}

function MappingSelectOnChange(caller) {

    var mappingMsg = $(caller).siblings(".mappingSelectMsg").remove();

    if ($(caller).val() == "-1") {
        $(caller).after("<div class='mappingSelectMsg'><i>This data row will be removed.</i></div>");
    }

}


function ClearDataRow(caller) {

    $(caller).closest(".dataRow").find("input, select").each(function () {

        if ($(this).is("input[type=text]")) {
            $(this).val("");
        }
        else if($(this).is("select")) {
            $(this).val("-1").change();

        }

    });

}