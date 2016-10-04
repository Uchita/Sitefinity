var strUrl = "http://staging.jsonp.jxt.net.au/service1.svc/getcustomer?method=SetProfessions";

function SetProfessions(data) {
    alert(data[0]);
}

function GetProfessions(controlid) {
//    $.jsonp({
//    url: "http://api.stackoverflow.com/1.1/stats",
//        complete: function(xOptions, textStatus) {
//        alert(textStatus);
//        },
//        success: function (xOptions, textStatus) {
//            alert(textStatus);
//        },
//        error: function(xOptions, textStatus) {
//        alert(textStatus);
//        }
//    });
var jqxhr = $.getJSON("http://staging.jsonp.jxt.net.au/service1.svc/getcustomer?method=?", function(data) {
  
})
.success(function() { alert("second success"); })
.error(function() { alert("error"); })
.complete(function() { alert("complete"); });

// perform other work here ...

// Set another completion function for the request above
jqxhr.complete(function(){ alert("second complete"); });

//$.getJSON(, SetProfessions);
    // $.ajax({
        // type: 'GET',
        // url: strUrl,
        // dataType: "jsonp",
        // success: function() { alert("Success");},
        // error: function() { alert("Error"); },
        // jsonp: 'jsonp'
    // });  
}

