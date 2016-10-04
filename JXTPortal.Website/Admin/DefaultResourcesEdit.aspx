<%@ Page Title="Global - Default Resource Edit" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="DefaultResourcesEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.DefaultResourcesEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Default Resources - Add/Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewDefaultResource" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewDefaultResource" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="dr-resourcecode-field">
                        <label class="form-label-left">
                            Resource Code:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataResourceCode" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_ResourceCode" runat="server" ControlToValidate="dataResourceCode"
                                ErrorMessage="Required" />
                        </div>
                    </li>
                    <li class="form-line" id="dr-resourcedescription-field">
                        <label class="form-label-left">
                            Resource Description:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataResourceDescription" runat="server" TextMode="MultiLine" Rows="5"
                                Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_ResourceDescription" runat="server" ControlToValidate="dataResourceDescription"
                                ErrorMessage="Required" />
                        </div>
                    </li>
                    <li class="form-line" id="dr-selectfolder-field">
                        <label class="form-label-left">
                            Select File:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:Repeater ID="rptFolders" runat="server" OnItemDataBound="rptFolders_ItemDataBound">
                                <HeaderTemplate>
                                    <ul id="browser" class="filetree">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li><span class="folder">
                                        <%# DataBinder.Eval(Container.DataItem, "FolderName") %></span>
                                        <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
                                            <HeaderTemplate>
                                                <ul>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li><span class="file">
                                                    <%# Eval("FileID") %>. <a href='/getfile.aspx?id=<%# Eval("FileID") %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "FileName") %></a> -
                                                    <asp:LinkButton CssClass="red" ID="lnkSelectFile" runat="server" CommandName="Select"
                                                        CommandArgument='<%# Eval("FileID") %>' CausesValidation="false">Select File</asp:LinkButton>
                                                </span></li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:TextBox ID="txtFileID" runat="server" Enabled="false" />
                            <asp:RequiredFieldValidator ID="ReqVal_hiddenFileID" runat="server" ControlToValidate="txtFileID"
                                ErrorMessage="Select File" />
                        </div>
                    </li>
                    <li class="form-line" id="dr-selectedfile-field">
                        <label class="form-label-left">
                            Selected File:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:Label ID="dataSelectedFile" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="dr-displayimage-field">
                        <label class="form-label-left">
                            &nbsp;</label>
                        <div class="form-input">
                            <asp:Image ID="imgDispaly" runat="server" Visible="false" />
                        </div>
                    </li>
                    <li class="form-line" id="dr-lastmodified-field">
                        <label class="form-label-left">
                            Last Modified:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataLastModified"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="dr-modifiedby-field">
                        <label class="form-label-left">
                            Modified By:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataModifiedBy"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
