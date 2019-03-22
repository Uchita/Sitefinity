//blog filter section

var sortBy;
var keyword;
//var BlogParentCategories = [];
//var BlogChildCategories = [];

//var BlogParentIndustries = [];
//var BlogChildIndustries = [];

//var BlogParentTypes = [];
//var BlogChildTypes = [];
//$(document).ready(function () {

//    var sortvalue = getParameterByName("sortby");
//    var keyword = getParameterByName("keyword");
//    $("#tbKeywords").val(keyword);
//    //$('.news-sort').each(function () {
//    //    if (($(this).find('a').attr('data-item')) == sortvalue) {
//    //        $(this).find('a').addClass('active');
//    //    } else {
//    //        $(this).find('a').removeClass('active');
//    //    }
//    //});
//    //refreshFilterSummary();
//});

$("#txtSearch").on('change', function (e) {
    keyword = $("#txtSearch").val();
    redirectHref();
});


function redirectHref() {

    //$('.parent-blog-category').each(function () {
    //    if ($(this).is(":checked")) {
    //        var index1 = BlogParentCategories.indexOf(this.id);
    //        if (index1 < 0) {
    //            BlogParentCategories.push(this.id);
    //        }
    //    }
    //    else {
    //        var index = BlogParentCategories.indexOf(this.id);
    //        if (index > -1) {
    //            BlogParentCategories.splice(index, 1);
    //        }
    //    }
    //});

    //$('.child-blog-category').each(function () {
    //    if ($(this).is(":checked")) {
    //        var index1 = BlogChildCategories.indexOf(this.id);
    //        if (index1 < 0) {
    //            BlogChildCategories.push(this.id);
    //        }
    //    }
    //    else {
    //        var index = BlogChildCategories.indexOf(this.id);
    //        if (index > -1) {
    //            BlogChildCategories.splice(index, 1);
    //        }
    //    }
    //});

    //$('.parent-blog-industry').each(function () {
    //    if ($(this).is(":checked")) {
    //        var index1 = BlogParentIndustries.indexOf(this.id);
    //        if (index1 < 0) {
    //            BlogParentIndustries.push(this.id);
    //        }
    //    }
    //    else {
    //        var index = BlogParentIndustries.indexOf(this.id);
    //        if (index > -1) {
    //            BlogParentIndustries.splice(index, 1);
    //        }
    //    }
    //});

    //$('.parent-blog-type').each(function () {
    //    if ($(this).is(":checked")) {
    //        var index1 = BlogParentTypes.indexOf(this.id);
    //        if (index1 < 0) {
    //            BlogParentTypes.push(this.id);
    //        }
    //    }
    //    else {
    //        var index = BlogParentTypes.indexOf(this.id);
    //        if (index > -1) {
    //            BlogParentTypes.splice(index, 1);
    //        }
    //    }
    //});

    //window.location.href = "/blogs?BlogParentCategories=" + BlogParentCategories.join() + "&BlogChildCategories=" + BlogChildCategories.join() + "&BlogParentIndustries=" + BlogParentIndustries.join() + "&BlogParentTypes=" + BlogParentTypes.join() + "&sortby=" + sortBy + "&keyword=" + keyword;
    var url = "";
    if (window.location.href.indexOf("?") > -1) {
        url = window.location.href.split("?")[0];
    }
    else {
        url = window.location.href;
    }
    window.location.href = url + "?sortby=" + sortBy + "&keyword=" + keyword;
}

function refreshFilterSummary() {
    redirectHref();
}

$('#sortOrder').on('change', function (e) {
    sortBy = this.value;
    refreshFilterSummary();
});

//$('.parent-blog-category').on('change', function (e) {

//    if ($(this).is(":checked")) {

//        BlogParentCategories.push(this.id);
//    }
//    else {
//        var index = BlogParentCategories.indexOf(this.id);
//        if (index > -1) {
//            BlogParentCategories.splice(index, 1);
//        }
//    }

//    redirectHref();
//});

//$('.parent-blog-industry').on('change', function (e) {

//    if ($(this).is(":checked")) {

//        BlogParentIndustries.push(this.id);
//    }
//    else {
//        var index = BlogParentIndustries.indexOf(this.id);
//        if (index > -1) {
//            BlogParentIndustries.splice(index, 1);
//        }
//    }

//    redirectHref();
//});

//$('.parent-blog-type').on('change', function (e) {

//    if ($(this).is(":checked")) {

//        BlogParentTypes.push(this.id);
//    }
//    else {
//        var index = BlogParentTypes.indexOf(this.id);
//        if (index > -1) {
//            BlogParentTypes.splice(index, 1);
//        }
//    }

//    redirectHref();
//});


//$('.child-blog-category').on('change', function (e) {

//    if ($(this).is(":checked")) {
//        BlogChildCategories.push(this.id);
//    }
//    else {
//        var index = BlogChildCategories.indexOf(this.id);
//        if (index > -1) {
//            BlogChildCategories.splice(index, 1);
//        }
//    }

//    redirectHref();
//});



function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

