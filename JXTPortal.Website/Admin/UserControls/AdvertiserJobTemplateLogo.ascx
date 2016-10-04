<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserJobTemplateLogo.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.AdvertiserJobTemplateLogo" %>

<div class="content-holder">
    <div class="form-all">
        <asp:MultiView ID="MultiViewAdvertiserJobTemplateLogo" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewAdvertiserJobTemplateLogo" runat="server">
                <span class="form-message">
                    <asp:Literal ID="ltlMessage" runat="server" /></span>
                <ul class="form-section">
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                                Advertiser Job Template Logo</h2>
                        </div>
                    </li>
                    <li>
                        <asp:CustomValidator ID="cvalFileName" runat="server" ErrorMessage="* Invalid file type. GIF, JPG and JPEG are the only valid images types allowed for upload."
                            Display="None"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvalFile" runat="server" ErrorMessage="CustomValidator" ValidationGroup="GroupMemberFilesValidation"
                            Display="None"></asp:CustomValidator>
                    </li>
                    <li class="form-line" id="advJobTemplateLogo-LogoName">
                        <label class="form-label-left">
                            <asp:Literal ID="ltAdvJobTemplateLogoName" runat="server" />: <span class="form-required">
                                *</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtAdvJobTemplateLogoName" runat="server" CssClass="form-textbox2" />
                            <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoName" runat="server" ControlToValidate="txtAdvJobTemplateLogoName"
                                ErrorMessage="Document Title is required" ValidationGroup="GroupMemberFilesValidation"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="advJobTemplateLogo-SelectLogo">
                        <label class="form-label-left">
                            <asp:Literal ID="ltAdvJobTemplateLogoSelectDoc" runat="server" />: <span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:FileUpload ID="docInput" runat="server" CssClass="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="advJobTemplateLogo-Button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" class="form-submit-button"
                                    ValidationGroup="GroupMemberFilesValidation" CausesValidation="True" CommandName="Submit" />
                            </div>
                        </div>
                    </li>
                    <br />
                    <hr>
                    <li class="form-line" id="advJobTemplateLogo-LogoList">
                        <div class="form-input">
                            <table id="box-table">
                                <thead>
                                    <tr>
                                        <%--<th scope="col">
                                            &nbsp;
                                        </th>
                                        <th scope="col">
                                            &nbsp;
                                        </th>--%>
                                        <th scope="col">
                                            <asp:Label>
                                                <asp:Literal ID="ltHeaderAdvJobTemplateLogoID" runat="server" />
                                            </asp:Label>
                                        </th>
                                        <th scope="col">
                                            <asp:Label>
                                                <asp:Literal ID="ltHeaderAdvJobTemplateLogoName" runat="server" />
                                            </asp:Label>
                                        </th>
                                        <th scope="col">
                                            &nbsp;
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptAdvJobTemplateLogo" runat="server" OnItemDataBound="rptAdvJobTemplateLogo_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td scope="col">
                                                    <asp:Label>
                                                        <asp:Literal ID="ltAdvJobTemplateLogoID" runat="server" />
                                                    </asp:Label>
                                                </td>
                                                <td scope="col">
                                                    <asp:Label>
                                                        <asp:Literal ID="ltAdvJobTemplateLogoName" runat="server" />
                                                    </asp:Label>
                                                </td>
                                                <td scope="col">
                                                    <asp:Label>
                                                        <asp:Image ID="imgAdvJobTemplateLogo" runat="server"></asp:Image>
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</div>
