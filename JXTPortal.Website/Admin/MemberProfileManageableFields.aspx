<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="MemberProfileManageableFields.aspx.cs" Inherits="JXTPortal.Website.Admin.MemberProfileManageableFields" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">Member Profile - Manageable Fields
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="/fonts/font-awesome/font-awesome.min.css" />
<asp:ScriptManager ID="scriptManager" runat="server" />
            <asp:UpdatePanel ID="upMultiLingual" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
    <h1>
        License Types (<asp:Literal runat="server" ID="ltLicenseCount" Text="0"></asp:Literal>)</h1>
    <div>
        <div>
            <div class="form-group">
                <h4>
                    Enter the default license type:</h4>
                <asp:TextBox runat="server" ID="tbLicenseType" Width="500px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" class="btn btn-info" OnClick="UpdateLicenseButton_Click"
                    Text="Add" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="ltLicenseMessage" Visible="false" CssClass="msg warning"></asp:Label><br />
            </div>
        </div>
        <div class="form-group clearfix">
            <asp:Repeater ID="rptLicenseType" runat="server" OnItemCommand="rptLicenseType_ItemCommand"
                OnItemDataBound="rptLicenseType_ItemDataBound">
                <ItemTemplate>
                    <div class="alert alert-info" style="display: inline-block;">
                        <asp:Label runat="server" ID="lblLicense"></asp:Label>
                        <asp:LinkButton CssClass="fa fa-times" runat="server" ID="lbLicenseRemove" Text="" CommandName="Remove"></asp:LinkButton>
                    </div>
                    &nbsp;
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix">
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
    <h1>
        Skills Type (<asp:Literal runat="server" ID="ltSkillsCount" Text="0"></asp:Literal>)</h1>
    <div>
        <div class="clearfix">
        </div>
        <div>
            <div class="form-group">
                <h4>
                    Enter the default skills:</h4>
                <asp:TextBox runat="server" ID="tbSkills" Width="500px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" class="btn btn-info" OnClick="UpdateSkillsButton_Click"
                    Text="Add" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="ltSkillsMessage" Visible="false" CssClass="msg warning"></asp:Label><br />
            </div>
        </div>
        <div class="form-group">
            <asp:Repeater ID="rptSkills" runat="server" OnItemCommand="rptSkills_ItemCommand"
                OnItemDataBound="rptSkills_ItemDataBound">
                <ItemTemplate>
                    <div class="alert alert-info" style="display: inline-block;">
                        <asp:Label runat="server" ID="lblSkills"></asp:Label>
                        <asp:LinkButton CssClass="fa fa-times" runat="server" ID="lbSkillsRemove"  CommandName="Remove"></asp:LinkButton>
                    </div>
                    &nbsp;
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix">
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
    <h1>
        Qualification Names (<asp:Literal runat="server" ID="ltQNCount" Text="0"></asp:Literal>)</h1>
    <div>
        <div class="clearfix">
        </div>
        <div>
            <div class="form-group">
                <h4>
                    Enter the default qualification names:</h4>
                <asp:TextBox runat="server" ID="tbQualificationName" Width="500px"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" class="btn btn-info" OnClick="UpdateQualificationNameButton_Click"
                    Text="Add" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="ltQNsMessage" Visible="false" CssClass="msg warning"></asp:Label><br />
            </div>
        </div>
        <div class="form-group">
            <asp:Repeater ID="rptQualificationName" runat="server" OnItemCommand="rptQualificationName_ItemCommand"
                OnItemDataBound="rptQualificationName_ItemDataBound">
                <ItemTemplate>
                    <div class="alert alert-info" style="display: inline-block;">
                        <asp:Label runat="server" ID="lblQualificationNames"></asp:Label>
                        <asp:LinkButton CssClass="fa fa-times" runat="server" ID="lbQualificationNamesRemove"  CommandName="Remove"></asp:LinkButton>
                    </div>
                    &nbsp;
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix">
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link rel="Stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <style>
        #displayTargetWrapper > div, #displayTargetWrapper2 > div
        {
            float: left;
        }
        
        #predictiveWrapper
        {
            border: 1px solid #ddd;
        }
    </style>
    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.3.min.js"
        integrity="sha256-aaODHAgvwQW1bFOGXMeX+pC4PZIPsvn2h1sArYOhgXQ=" crossorigin="anonymous"></script>--%>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript">

        function DrawItems(arrayList, webMethodDeleteName, targetWrapperID, anchorClass, messageDispID, removeOnclickMethodName) {

            $(targetWrapperID).empty();

            $(arrayList).each(function (idx, doubleEncodedVal) {

                /*note the jquery text() will not HTML encode anything so it will display the data as is
                if encoding needed, change text() to html()*/
                var displayVal = $('<div/>').html(unescape(doubleEncodedVal)).text();

                var div = $("<div></div>").addClass(anchorClass).text(displayVal);
                var anchor = $("<a href=\"javascript:void(0)\" data-value=\"" + doubleEncodedVal + "\" onclick=\"" + removeOnclickMethodName + "(this, '" + webMethodDeleteName + "', '" + targetWrapperID + "', '" + anchorClass + "', '" + messageDispID + "')\">x</a>");

                div.append(anchor);

                $(targetWrapperID).append(div);

            });
        }


        function AddAdminAnchorDisplay(webMethodAddName, webMethodDeleteName, inputObjID, targetWrapperID, anchorClass, messageDispID) {

            $("#messageDispID").empty();

            var displayName = $(inputObjID).val();

            //alert(escape($('<div/>').text(displayName).html()) + "||" + encodeURI($('<div/>').text(displayName).html()));


            $.ajax({
                type: "POST",
                url: "/admin/memberprofilemanageablefields.aspx/" + webMethodAddName,
                data: "{ targetValue: '" + encodeURI($('<div/>').text(displayName).html()) + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {

                    if (msg.d.Success) {
                        DrawItems(msg.d.data, webMethodDeleteName, targetWrapperID, anchorClass, messageDispID, "RemoveAdminAnchorDisplay");
                        $(inputObjID).val("");
                    }
                    else {

                        if (msg.d.SessionFailed == true) {
                            $(messageDispID).html("Invalid session");
                        }
                        else {
                            $(messageDispID).text(msg.d.Message);
                        }
                    }
                },
                failure: function (response) {
                    $(messageDispID).html(response);
                }
            });
        }

        function RemoveAdminAnchorDisplay(caller, webMethodDeleteName, targetWrapperID, anchorClass, messageDispID) {

            $.ajax({
                type: "POST",
                url: "/admin/memberprofilemanageablefields.aspx/" + webMethodDeleteName,
                data: "{ targetValue: '" + $(caller).data("value") + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {

                    if (msg.d.Success) {
                        DrawItems(msg.d.data, webMethodDeleteName, targetWrapperID, anchorClass, messageDispID, "RemoveAdminAnchorDisplay");
                    }
                    else {

                        if (msg.d.SessionFailed == true) {
                            $(messageDispID).html("Invalid session");
                        }
                        else {
                            $(messageDispID).html(msg.d.Message);
                        }
                    }
                },
                failure: function (response) {
                    $(messageDispID).html(response);
                }
            });

        }


    </script>
</asp:Content>
