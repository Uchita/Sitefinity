// Login Form
// Initialize login panel on load and assign ajax login calling on sign in click
// Redirect to Member Home on success and display error message on invalid login

$(function () {
    var button = $('#mini-loginButton');
    var box = $('#mini-loginBox');
    var form = $('#mini-loginForm');
    var signinbutton = $('#btnSignIn');
    var mousedowntarget;
    signinbutton.click(
        function () {
            $.ajax({
                url: '/LoginModal.asmx/MemberLogin',
                type: "POST",
                dataType: "xml",
                data: "username=" + $("#tbLoginUsername").val() + "&password=" + $("#tbLoginPassword").val(),
                beforeSend: function () {
                    box.show();
                },
                success: function (data, textStatus, jqXHR) {
                    var xmlDoc = jqXHR.responseXML;
                    var result = xmlDoc.getElementsByTagName("string")[0].childNodes[0].nodeValue;
                    if (result == "success") {
                        location.href = "/member/default.aspx";
                    }
                    else {
                        $("#ltLoginError").text(result);
                    }

                },
                fail: function () {

                }
            });
        }
    );
    button.removeAttr('href');
    button.mouseup(function (login) {
        box.toggle();
        $("#tbLoginUsername").focus();
        button.toggleClass('active');

    });

    $("#tbLoginUsername").keyup(function (event) {
        if (event.keyCode == 13) {
            $("#btnSignIn").click();
        }
    });

    $("#tbLoginPassword").keyup(function (event) {
        if (event.keyCode == 13) {
            $("#btnSignIn").click();
        }
    });

    form.mouseup(function () {
        return false;
    });

    $(this).mousedown(function (login) {
        if (!($(login.target).parents('#mini-loginBox').length > 0)) {
            button.removeClass('active');
            box.hide();
        }
    });
});
