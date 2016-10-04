<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberFiles.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberFiles" %>
<div class="form-header-group">
    <h1 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltucMemberfiles" runat="server" SetLanguageCode="LabelMemberFiles" />
    </h1>
</div>
<p>
    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelMemberFileWelcome" />
</p>
<hr />
    <ul class="form-section">
        <li class="form-line" id="MemberFiles-DocumentTitle">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltMemberFilesDocumentTitle" runat="server" SetLanguageCode="LabelDocumentTitle" />
                :<span class="form-required">*</span>
            </label>
            <div class="form-input">
                <asp:TextBox ID="txtDocumentTitle" runat="server" CssClass="form-textbox2" />
                <asp:RequiredFieldValidator ID="rfvDocumentTitle" runat="server" ControlToValidate="txtDocumentTitle"
                    ValidationGroup="GroupMemberFilesValidation" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cfDocumentTitle" runat="server"  ControlToValidate="txtDocumentTitle"
                    ValidationGroup="GroupMemberFilesValidation" SetFocusOnError="true" 
                    Display="Dynamic" onservervalidate="cfDocumentTitle_ServerValidate"></asp:CustomValidator>
            </div>
        </li>
        <li class="form-line" id="MemberFiles-FileType">
            <label class="form-label-left" runat="server">
                <JXTControl:ucLanguageLiteral ID="ltMemberFilesFileType" runat="server" SetLanguageCode="LabelFileType" />
                :</label>
            <div class="form-input">
                <asp:DropDownList ID="ddlMemberFileType" runat="server" class="form-dropdown">
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="MemberFiles-SelectDocument">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltMemberFilesSelectDocument" runat="server" SetLanguageCode="LabelSelectDocument" />
                :<span class="form-required">*</span>
            </label>
            <div class="form-input">
                <asp:FileUpload ID="docInput" runat="server" CssClass="form-textbox2" />
                <asp:CustomValidator ID="cvalDocument" runat="server" CssClass="fieldstar" ErrorMessage="CustomValidator"
                    SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvalDocument_ServerValidate"
                    ValidationGroup="GroupMemberFilesValidation"></asp:CustomValidator>
            </div>
        </li>
        <li class="form-line" id="reg-bottom-button">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper">
                    <asp:Button ID="btnSubmit" runat="server" autopostback="true" Text="Save" OnClick="btnSubmit_Click"
                        CssClass="mini-new-buttons" ValidationGroup="GroupMemberFilesValidation" />
                </div>
            </div>
        </li>
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
                        <a href='/Download.aspx?type=mf&id=<%# Eval("MemberFileID") %>'>
                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDownload" runat="server" SetLanguageCode="LinkButtonDownload" />
                        </a>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkDeleteFile" runat="server" ValidationGroup="SubAccounts" CommandArgument='<%# Eval("MemberFileID") %>'
                            OnClick="lnkDeleteFile_Click" CausesValidation="false">          
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
            <asp:Literal ID="ltMemberFileNoResume" runat="server" Visible="false" />
        </li>
        <li id="memberFiles-HeaderResume">
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
                        <a href='/Download.aspx?type=mf&id=<%# Eval("MemberFileID") %>'>
                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDownload" runat="server" SetLanguageCode="LinkButtonDownload" />
                        </a>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkCoverLetterDeleteFile" runat="server" ValidationGroup="SubAccounts"
                            CommandArgument='<%# Eval("MemberFileID") %>' OnClick="lnkDeleteFile_Click" CausesValidation="false">     
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
            <asp:Literal ID="ltMemberFileNoCoverLetter" runat="server" Visible="false" />
        </li>
        <li id="Li1">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ucMemberFilesAdditionalDocuments" runat="server"
                        SetLanguageCode="LabelAdditionalDocuments" />
                </h2>
            </div>
        </li>
        <asp:Repeater ID="rptAdditionalDocuments" runat="server" OnItemDataBound="rptAdditionalDocuments_ItemDataBound"
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
                                <asp:Literal ID="ltHeaderAdditionalName" runat="server" />
                            </th>
                            <th scope="col">
                                <asp:Literal ID="ltHeaderAdditionalDateEntered" runat="server" />
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/Download.aspx?type=mf&id=<%# Eval("MemberFileID") %>'>
                            <JXTControl:ucLanguageLiteral ID="ucLinkButtonDownload" runat="server" SetLanguageCode="LinkButtonDownload" />
                        </a>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkAdditionalFilesDeleteFile" runat="server" ValidationGroup="SubAccounts"
                            CommandArgument='<%# Eval("MemberFileID") %>' OnClick="lnkDeleteFile_Click" CausesValidation="false">     
                        </asp:LinkButton>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdditionalName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdditionalDateEntered" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <li class="form-line" id="MemberFiles-NoAdditionalDocuments">
            <asp:Literal ID="ltMemberFileNoAdditionalDocuments" runat="server" Visible="false" />
        </li>
    </ul>
