$(document).ready(function () {

    var dateformat = $("#ctl00_ContentPlaceHolder1_ucJobFields_txtJobExpiryDate").attr('placeholder');

    $("#ctl00_ContentPlaceHolder1_ucJobFields_txtJobExpiryDate").datepicker(
        {
            minDate: 0,
            dateFormat: dateformat,
            maxDate: "+30D"
        });
});
