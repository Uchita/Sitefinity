var strUrl = "http://www.dev.jobx.com.au/";

function GetClassifications(controlid) {
 $.ajax({
    type: 'POST',
    cache: false,
    url: strUrl + "job/ajaxcalls/ajaxmobilemethods.asmx/GetProfessions",
    contentType: "application/json; charset=utf-8",
    dataType: "html",
    success: function(msg) {
        alert(msg);
    },
    fail: function() {
        // Replace the div's content with the page method's return.
        $("#" + controlid).html("It didn't work");
    }
});
}