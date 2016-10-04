<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="Integrations.aspx.cs" Inherits="JXTPortal.Website.Admin.Integrations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Integrations
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltlMessage" runat="server" />
    <form method="post" action="/admin/integrations.aspx">
    <asp:PlaceHolder ID="DynamicForm" runat="server"></asp:PlaceHolder>

    <ul>
        <li class="form-line">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper">
                    <input type="submit" class="form-submit-button" value="Submit" />
                </div>
            </div>
        </li>
    </ul>
    </form>

    <script type="text/javascript">

        $("input").on("change", function () {

            $(".alert").remove();

        });

        function BullhornTokenReset(target) {
            $.ajax({
                type: "POST",
                url: "/admin/integrations.aspx/BullhornTokenResetURLGet",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {

                    console.log(msg);

                    if (msg.d.Success) {
                        window.location = msg.d.BHURL;
                    }
                    else {
                        $(target).before("<span class='bhtokenError' style='display:block'>" + msg.d.Message + "</span>");
                    }
                }
            });
        }

    </script>
</asp:Content>
