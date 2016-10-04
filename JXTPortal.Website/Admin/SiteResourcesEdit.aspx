<%@ Page Title="Sites - Site Resource Edit" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="SiteResourcesEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteResourcesEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Site Resources - Add/Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteResource" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteResource" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="sr-default-field">
                        <label class="form-label-left">
                            <strong>Default Resource</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sr-defaultresourcecode-field">
                        <label class="form-label-left">
                            Resource Code:</label>
                        <div class="form-input">
                            <asp:Label ID="dataDefaultResourceCode" runat="server" Enabled="false" />
                        </div>
                    </li>
                    <li class="form-line" id="sr-defaultresourcetext-field">
                        <label class="form-label-left">
                            Resource Text:</label>
                        <div class="form-input">
                            <asp:Label ID="dataDefaultResourceText" runat="server" Enabled="false" />
                        </div>
                    </li>
                    <li class="form-line" id="sr-defaultresourcedescription-field">
                        <label class="form-label-left">
                            Resource Description:</label>
                        <div class="form-input">
                            <asp:Label ID="dataDefaultResourceDescription" runat="server" Enabled="false" />
                        </div>
                    </li>
                    <li class="form-line" id="sr-defaultresourcefile-field">
                        <label class="form-label-left">
                            File:</label>
                        <div class="form-input">
                            <asp:Label ID="dataDefaultFile" runat="server" Enabled="false" />
                        </div>
                    </li>
                    <li class="form-line" id="sr-defaultresourcefiledisplay-field">
                        <label class="form-label-left">
                            &nbsp;</label>
                        <div class="form-input">
                            <asp:Image ID="dataDefaultFileDisplay" runat="server" Visible="false" />
                        </div>
                    </li>
                </ul>
                <asp:Repeater ID="rptSiteResources" runat="server" OnItemDataBound="rptSiteResources_ItemDataBound"
                    OnItemCommand="rptSiteResources_ItemCommand">
                    <HeaderTemplate>
                        <div class="coda-slider-wrapper">
                            <div class="coda-slider preload" id="coda-slider-1">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="panel">
                            <div class="panel-wrapper">
                                <asp:HiddenField ID="hfLanguageId" runat="server" />
                                <h2 class="title">
                                    <asp:Literal ID="litLanguageName" runat="server"></asp:Literal></h2>
                                <ul class="form-section">
                                    <li class="form-line" id="sr-resourcetext-field">
                                        <label class="form-label-left">
                                            Resource Text:</label>
                                        <div class="form-input">
                                            <asp:HiddenField ID="hfSiteResourceId" runat="server" />
                                            <asp:TextBox ID="dataResourceText" runat="server" />
                                        </div>
                                    </li>
                                    <li class="form-line" id="sr-siteresource-field">
                                        <label class="form-label-left">
                                            New File:<span class="form-required">*</span></label>
                                        <div class="form-input">
                                            <asp:Repeater ID="rptFolders" runat="server" OnItemDataBound="rptFolders_ItemDataBound">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="ltlHeader" runat="server" />
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
                                        </div>
                                    </li>
                                    <li class="form-line" id="sr-selectedsiteresource-field">
                                        <label class="form-label-left">
                                            Selected New File:<span class="form-required">*</span></label>
                                        <div class="form-input">
                                            <asp:Label ID="dataSelectedSiteResource" runat="server" />
                                            <asp:RequiredFieldValidator ID="ReqVal_SelectedSiteResource" runat="server" ControlToValidate="txtFileID"
                                                ErrorMessage="Select Site Resource"></asp:RequiredFieldValidator>
                                        </div>
                                    </li>
                                    <li class="form-line" id="sr-sitedisplay-field">
                                        <label class="form-label-left">
                                            &nbsp;</label>
                                        <div class="form-input">
                                            <asp:Image ID="imgSiteDispaly" runat="server" Visible="false" />
                                        </div>
                                    </li>
                                    <li class="form-line" id="sr-lastmodified-field">
                                        <label class="form-label-left">
                                            Last Modified:</label>
                                        <div class="form-input">
                                            <asp:Label runat="server" ID="dataLastModified"></asp:Label>
                                        </div>
                                    </li>
                                    <li class="form-line" id="sr-modifiedby-field">
                                        <label class="form-label-left">
                                            Modified By:</label>
                                        <div class="form-input">
                                            <asp:Label runat="server" ID="dataModifiedBy"></asp:Label>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div> </div>
                        <br />
                        <asp:Button ID="btnEditSave" runat="server" Text="Update" CommandName="Save" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnUseDefault" runat="server" Text="Use Default" CommandName="UseDefault"
                            CssClass="jxtadminbutton" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" CommandName="Return" CssClass="jxtadminbutton"
                            CausesValidation="false" />
                    </FooterTemplate>
                </asp:Repeater>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <link rel="stylesheet" href="/admin/styles/coda-slider/coda-slider-2.0.css" type="text/css"
        media="screen" />
    <link href="/Admin/styles/jquery.treeview.css" rel="stylesheet" type="text/css" />
</asp:Content>
