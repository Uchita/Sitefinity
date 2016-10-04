<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="LocationEdit" Title="Global - Default Locations Edit"
    CodeBehind="LocationEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Location - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewLocation" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewLocation" runat="server">
                <ul class="form-section">
                    
                    <li class="form-line" id="loc-locationname-field">
                        <label class="form-label-left">
                            Location Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataLocationName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="loc-valid-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataValid" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <%--<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                    Text="Insert" CssClass="jxtadminbutton" OnClick="InsertButton_Click" />--%>
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" CssClass="jxtadminbutton" OnClick="UpdateButton_Click" />
                                <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel" CssClass="jxtadminbutton" OnClick="CancelButton_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
