<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="memberFile.aspx.cs" Inherits="JXTPortal.Website.members.memberFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" />
    <div id="content">
        <div class="content-holder">
            <div class="form-all">
                <ul class="form-section">
                    <h1>
                        <JXTControl:ucLanguageLiteral ID="ltucMemberfiles" runat="server" SetLanguageCode="LabelMemberFiles" />
                    </h1>
                    <p>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelMemberFileWelcome" />
                    </p>
                    <hr />
                    <li class="form-line" id="reg-first-name">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="litMemberFileDocTitle" runat="server" SetLanguageCode="LabelDocumentTitle" />
                            :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="txtDocumentTitle" runat="server" CssClass="form-textbox2" />
                            <asp:RequiredFieldValidator ID="rfvDocumentTitle" runat="server" ControlToValidate="txtDocumentTitle"
                                ErrorMessage="Document Title is required" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="MemberFiles-FileType">
                        <label id="Label1" class="form-label-left" runat="server">
                            <JXTControl:ucLanguageLiteral ID="ltMemberFilesFileType" runat="server" SetLanguageCode="LabelFileType" />
                            :</label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlMemberFileType" runat="server" class="form-dropdown">
                            </asp:DropDownList>
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="litMemberFileSelectDoc" runat="server" SetLanguageCode="LabelSelectDocument" />
                            :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:FileUpload ID="docInput" runat="server" CssClass="form-textbox2" />
                            <asp:CustomValidator ID="cvalDocument" runat="server" CssClass="fieldstar" ErrorMessage="CustomValidator"
                                SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvalDocument_ServerValidate"></asp:CustomValidator>
                        </div>
                    </li>
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnSubmit" runat="server" autopostback="true" Text="Save" OnClick="btnSubmit_Click"
                                     CssClass="mini-new-buttons" />
                            </div>
                        </div>
                        <br />
                        <li id="memberFiles-HeaderResume">
                            <div class="form-header-group">
                                <h2 class="form-header">
                                    <JXTControl:ucLanguageLiteral ID="ucMemberFileHeaderResume" runat="server" SetLanguageCode="LabelResume" />
                                </h2>
                            </div>
                        </li>
                        <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound"
                            Visible="false">
                            <HeaderTemplate>
                                <table id="box-table">
                                    <tbody>
                                        <tr>
                                            <th scope="col">
                                                &nbsp;
                                            </th>
                                            <th scope="col">
                                                &nbsp;
                                            </th>
                                            <th scope="col">
                                                    <asp:Literal ID="ltHeaderResumeName" runat="server" />
                                            </th>
                                            <th scope="col">
                                                    <asp:Literal ID="ltHeaderResumeDateEntered" runat="server" />
                                            </th>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href='/download.aspx?type=mf&id=<%# Eval("MemberFileID") %>'>
                                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDownload" runat="server" SetLanguageCode="LinkButtonDownload" />
                                        </a>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkDeleteFile" runat="server" ValidationGroup="SubAccounts" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                            CommandArgument='<%# Eval("MemberFileID") %>' OnClick="lnkDeleteFile_Click" CausesValidation="false">
                                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDelete" runat="server" SetLanguageCode="LinkButtonDelete" />
                                        </asp:LinkButton>
                                    </td>
                                    <td scope="col">
                                            <asp:Literal ID="ltResumeName" runat="server" />
                                    </td>
                                    <td scope="col">
                                            <asp:Literal ID="ltResumeDateEntered" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody></table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <li class="form-line" id="MemberFiles-NoResume">
                            <label>
                                <asp:Literal ID="ltMemberFileNoResume" runat="server" Text="You currently do not have Resume"
                                    Visible="false" />
                            </label>
                        </li>
                        <li id="Li2">
                            <div class="form-header-group">
                                <h2 class="form-header">
                                    <JXTControl:ucLanguageLiteral ID="ucMemberFilesCoverLetter" runat="server" SetLanguageCode="LabelCoverLetter" />
                                </h2>
                            </div>
                        </li>
                        <asp:Repeater ID="rptCoverLetter" runat="server" OnItemDataBound="rptCoverLetter_ItemDataBound"
                            Visible="false">
                            <HeaderTemplate>
                                <table id="box-table">
                                    <tbody>
                                        <tr>
                                            <th scope="col">
                                                &nbsp;
                                            </th>
                                            <th scope="col">
                                                &nbsp;
                                            </th>
                                            <th scope="col">
                                                    <asp:Literal ID="ltHeaderCoverName" runat="server" />
                                            </th>
                                            <th scope="col">
                                                    <asp:Literal ID="ltHeaderCoverDateEntered" runat="server" />
                                            </th>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href='/download.aspx?type=mf&id=<%# Eval("MemberFileID") %>'>
                                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDownload" runat="server" SetLanguageCode="LinkButtonDownload" />
                                        </a>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkCoverLetterDeleteFile" runat="server" ValidationGroup="SubAccounts"
                                            OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                            CommandArgument='<%# Eval("MemberFileID") %>' OnClick="lnkDeleteFile_Click" CausesValidation="false">
                                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDelete" runat="server" SetLanguageCode="LinkButtonDelete" />
                                        </asp:LinkButton>
                                    </td>
                                    <td scope="col">
                                            <asp:Literal ID="ltCoverName" runat="server" />
                                    </td>
                                    <td scope="col">
                                            <asp:Literal ID="ltCoverDateEntered" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody></table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <li class="form-line" id="MemberFiles-NoCoverLetter">
                                <asp:Literal ID="ltMemberFileNoCoverLetter" runat="server" Text="You currently do not have Cover Letter"
                                    Visible="false" />
                        </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
