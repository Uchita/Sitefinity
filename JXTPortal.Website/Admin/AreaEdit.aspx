<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AreaEdit" Title="Global - Default Area Edit"
    CodeBehind="AreaEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Area - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewLocation" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewLocation" runat="server">
                <ul class="form-section">
                    
                    <li class="form-line" id="area-location-field">
                        <label class="form-label-left">
                            Location:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataLocation" DataTextField="LocationName" DataValueField="LocationID"
                                CssClass="form-multiple-column" NullItemText=" Please Choose ..." />
                            <asp:RequiredFieldValidator ID="ReqVal_Location" runat="server" ErrorMessage="Required"
                                InitialValue="0" ControlToValidate="dataLocation" />
                        </div>
                    </li>
                    <li class="form-line" id="area-areaname-field">
                        <label class="form-label-left">
                            Area Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataAreaName" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqVal_AreaName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataAreaName" />
                        </div>
                    </li>
                    <li class="form-line" id="area-valid-field">
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
