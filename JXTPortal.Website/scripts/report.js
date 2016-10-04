$('.input-daterange').datepicker({
    format: dateformat,
    keyboardNavigation: false,
    startDate: '-6m',
    autoclose: true,
    todayHighlight: true
});

$(document).ready(function(){
    $('#mytable input').click(function() {
        var checked = $('#mytable').find('input[type="checkbox"]:checked').length;
        if(checked >= 2){
            $('#downloadSelectedInvoice').attr('disabled', 'disabled');
        } else {
            $('#downloadSelectedInvoice').removeAttr('disabled', 'disabled');
        }
        if(checked < 2){
            $('#createInvoiceFrom').attr('disabled', 'disabled');
        } else {
            $('#createInvoiceFrom').removeAttr('disabled', 'disabled');
        }
    });

    $('.selectpicker').selectpicker();
});