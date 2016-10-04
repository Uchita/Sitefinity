<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserJobTemplateLogo.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.AdvertiserJobTemplateLogo" %>

<asp:MultiView ID="MultiViewAdvertiserJobTemplateLogo" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewAdvertiserJobTemplateLogo" runat="server">
        <span class="form-message"><asp:Literal ID="ltlMessage" runat="server" /></span>
        
        <%--<div class="form-header-group">
            <h2 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltAdvJobTemplateLogoHeader" runat="server" SetLanguageCode="LinkButtonViewChangeTemplateLogo" />
            </h2>
        </div>--%>
        
        <div class="form-all">
            
                <div class="form-line" id="advJobTemplateLogo-LogoName">
                    <label class="form-label-left" for="ctl00_ContentPlaceHolder1_ucAdvertiserJobTemplateLogo_txtAdvJobTemplateLogoName">
                        <JXTControl:ucLanguageLiteral ID="ltAdvJobTemplateLogoName" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoName" />
                        :<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="txtAdvJobTemplateLogoName" runat="server" CssClass="form-textbox2" />
                        <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoName" runat="server" ControlToValidate="txtAdvJobTemplateLogoName"
                            ValidationGroup="GroupMemberFilesValidation" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-line" id="advJobTemplateLogo-SelectLogo">
                    <label class="form-label-left" for="ctl00_ContentPlaceHolder1_ucAdvertiserJobTemplateLogo_docInput">
                        <JXTControl:ucLanguageLiteral ID="ltAdvJobTemplateLogoSelectDoc" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoSelectDoc" />
                        :<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:FileUpload ID="docInput" runat="server" CssClass="form-textbox2" />&nbsp;
                        <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoImage" runat="server" ControlToValidate="docInput"
                            ValidationGroup="GroupMemberFilesValidation" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-line" id="AdvJobTemplateLogoEditPreview">
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Label ID="lblAdvJobTemplateLogoEdit" runat="server">
                                <asp:Image ID="imgAdvJobTemplateLogoEdit" runat="server" Visible="false"></asp:Image>
                            </asp:Label>
                        </div>
                    </div>
                </div>
                <div>
                    <asp:CustomValidator ID="cvalFileName" runat="server" ValidationGroup="GroupMemberFilesValidation"
                        OnServerValidate="cvalFileName_ServerValidate" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                
                    <asp:CustomValidator ID="cvalFile" runat="server" ValidationGroup="GroupMemberFilesValidation"
                        OnServerValidate="cvalFile_ServerValidate" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                </div>
                <div class="form-line" id="advJobTemplateLogo-Button">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="mini-new-buttons"
                            ValidationGroup="GroupMemberFilesValidation" CausesValidation="True" CommandName="Submit" />
                    </div>                    
                </div> 
                <asp:Repeater ID="rptAdvJobTemplateLogo" runat="server" OnItemDataBound="rptAdvJobTemplateLogo_ItemDataBound"
                    OnItemCommand="rptAdvJobTemplateLogo_ItemCommand" Visible="false">
                    <HeaderTemplate>
                        <div class="form-line" id="advJobTemplateLogo-table">
                        <table id="box-table" class="box-table">
                            <tbody>
                                <tr>
                                    <th scope="col">
                                        &nbsp;
                                    </th>
                                    <th scope="col">
                                        <asp:Literal ID="ltHeaderAdvJobTemplateLogoID" runat="server" />
                                    </th>
                                    <th scope="col">
                                        <asp:Literal ID="ltHeaderAdvJobTemplateLogoName" runat="server" />
                                    </th>
                                    <th scope="col">
                                        <asp:Literal ID="ltHeaderAdvJobTemplateLogoThumbnail" runat="server" />
                                    </th>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td scope="col" valign="top">
                                <asp:LinkButton ID="lbAdvertiserJobTemplateEdit" runat="server" CommandName="Edit"
                                    CommandArgument='<%# Eval("AdvertiserJobTemplateLogoID") %>'>
                                    <JXTControl:ucLanguageLiteral ID="ucLinkButtonEdit" runat="server" SetLanguageCode="LinkButtonEdit" />
                                </asp:LinkButton>
                            </td>
                            <td scope="col" valign="top">
                                <asp:Literal ID="ltAdvJobTemplateLogoID" runat="server" />
                            </td>
                            <td scope="col" valign="top">
                                <asp:Literal ID="ltAdvJobTemplateLogoName" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Image ID="imgAdvJobTemplateLogo" runat="server" CssClass="advJobTemplateLogo-logolist"></asp:Image>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table></div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                    <HeaderTemplate>
                        <div id="tnt_pagination">
                            <JXTControl:ucLanguageLiteral ID="ltPage" runat="server" SetLanguageCode="LabelPage" />
                        :
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            
        </div>
    </asp:View>
</asp:MultiView>
