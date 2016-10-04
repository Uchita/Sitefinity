<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="GlobalSettingsSEO.aspx.cs" Inherits="JXTPortal.Website.Admin.GlobalSettingsSEO" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Global Settings - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript">
        function CharaterCount(textboxid, spanid, max) {
            var len = $("#ctl00_ContentPlaceHolder1_" + textboxid).val().length;
            $("#" + spanid).text("Character Count: " + len);
            if (len > max) {
                $("#" + spanid).css("color", "red");
            }
            else {
                $("#" + spanid).css("color", "black");
            }
        }
    </script>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteResource" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteResource" runat="server">
                <ul class="form-section">
                 <li class="form-line" id="Li8">
                        <h3>
                            Google Settings</h3>
                    </li>
                    <li class="form-line" id="Li10">
                        <label class="form-label-left">
                            Google Analytics Code:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbGoogleAnalytics" runat="server" width="400" PlaceHolder="Example: UA-33568220-1"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li9">
                        <label class="form-label-left">
                            Google Tag Manager Code:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbGoogleTagManager" runat="server" width="400" PlaceHolder="Example: GTM-K5KLMN"></asp:TextBox>
                        </div>
                    </li>
                    
                    <li class="form-line" id="Li11">
                        <label class="form-label-left">
                            Google Webmaster Code:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbGoogleWebMaster" runat="server" width="400" PlaceHolder="Example: 0fQayhSKZtytDm8_TbDY6dDg4WikxceOMvy-K90bU1s"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li3">
                        <h3>
                            SEO</h3>
                    </li>
                    <li class="form-line" id="gse-pagetitleprefix-field">
                        <label class="form-label-left">
                            Page Title Prefix:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataPageTitlePrefix" runat="server" width="400"></asp:TextBox>
                            <asp:CustomValidator ID="cvPageTitlePrefix" runat="server" ErrorMessage="Page Title Prefix contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataPageTitlePrefix" OnServerValidate="cvPageTitlePrefix_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-pagetitlesuffix-field">
                        <label class="form-label-left">
                            Page Title Suffix:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataPageTitleSuffix" runat="server" width="400"></asp:TextBox>
                            <asp:CustomValidator ID="cvPageTitleSuffix" runat="server" ErrorMessage="Page Title Suffix contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataPageTitleSuffix" OnServerValidate="cvPageTitleSuffix_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-hometitle-field">
                        <label class="form-label-left">
                            Home Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataHomeTitle" runat="server" width="400" onkeyup="CharaterCount('dataHomeTitle', 'spHomeTitleCount', 69);"
                                onmouseup="CharaterCount('dataHomeTitle', 'spHomeTitleCount', 69);"></asp:TextBox>&nbsp;<span
                                    id="spHomeTitleCount"></span>
                            <asp:CustomValidator ID="cvHomeTitle" runat="server" ErrorMessage="Home Title contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataHomeTitle" OnServerValidate="cvHomeTitle_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-homedescription-field">
                        <label class="form-label-left">
                            Home Description:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataHomeDescription" runat="server" TextMode="MultiLine" Rows="6"
                                Columns="40" onkeyup="CharaterCount('dataHomeDescription', 'spHomeDescriptionCount', 160);"
                                onmouseup="CharaterCount('dataHomeDescription', 'spHomeDescriptionCount', 160);"></asp:TextBox>&nbsp;<span
                                    id="spHomeDescriptionCount"></span>
                            <asp:CustomValidator ID="cvHomeDescription" runat="server" ErrorMessage="Home Description contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataHomeDescription" OnServerValidate="cvHomeDescription_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-homekeywords-field">
                        <label class="form-label-left">
                            Home Keywords:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataHomeKeywords" runat="server" TextMode="MultiLine" Rows="6" Columns="40"
                                onkeyup="CharaterCount('dataHomeKeywords', 'spHomeKeywordsCount', 256);" onmouseup="CharaterCount('dataHomeKeywords', 'spHomeKeywordsCount', 256);"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="dataHomeKeywords" ErrorMessage="Home Description can not exceed 256 characters"
                                ValidationExpression="(?:[\r\n]*.[\r\n]*){0,256}" />--%>
                            <span id="spHomeKeywordsCount"></span>
                            <asp:CustomValidator ID="cvHomeKeywords" runat="server" ErrorMessage="Home Keywords contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataHomeKeywords" OnServerValidate="cvHomeKeywords_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-defaulttitle-field">
                        <label class="form-label-left">
                            Default Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDefaultTitle" runat="server" width="400" onkeyup="CharaterCount('dataDefaultTitle', 'spTitleCount', 69);"
                                onmouseup="CharaterCount('dataDefaultTitle', 'spTitleCount', 69);"></asp:TextBox>&nbsp;<span
                                    id="spTitleCount"></span>
                            <asp:CustomValidator ID="cvDefaultTitle" runat="server" ErrorMessage="Default Title contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataDefaultTitle" OnServerValidate="cvDefaultTitle_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-defaultdescription-field">
                        <label class="form-label-left">
                            Default Description:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDescription" runat="server" TextMode="MultiLine" Rows="6" Columns="40"
                                onkeyup="CharaterCount('dataDescription', 'spDescriptionCount', 160);" onmouseup="CharaterCount('dataDescription', 'spDescriptionCount', 160);"></asp:TextBox>&nbsp;<span
                                    id="spDescriptionCount"></span>
                            <asp:CustomValidator ID="cvDescription" runat="server" ErrorMessage="Default Description contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataDescription" OnServerValidate="cvDescription_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-defaultkeywords-field">
                        <label class="form-label-left">
                            Default Keywords:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDefaultKeywords" runat="server" TextMode="MultiLine" Rows="6"
                                Columns="40" onkeyup="CharaterCount('dataDefaultKeywords', 'spKeywordsCount', 256);"
                                onmouseup="CharaterCount('dataDefaultKeywords', 'spKeywordsCount', 256);"></asp:TextBox>&nbsp;<span
                                    id="spKeywordsCount"></span>
                            <asp:CustomValidator ID="cvDefaultKeywords" runat="server" ErrorMessage="Default Keywords contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataDefaultKeywords" OnServerValidate="cvDefaultKeywords_ServerValidate" />
                        </div>
                    </li>
                    <asp:Panel ID="pnlMeta" runat="server">
                        <ul class="form-section">
                            <li class="form-line" id="gse-metatags1-field">
                                <label class="form-label-left">
                                    Meta Tags 1 (Global):<br />
                                </label>
                                <div class="form-input">
                                    <b>(can contain javascript tags, css tags, favicon, meta tags etc - will be applied
                                        to the whole site)</b><br />
                                    <asp:TextBox ID="txtMetaTags" runat="server" TextMode="MultiLine" Width="600px" Height="400px"></asp:TextBox>
                                    <br />
                                </div>
                            </li>
                            <li class="form-line" id="gse-metatags2-field">
                                <label class="form-label-left">
                                    Meta Tags 2 (System Pages only):<br />
                                    Excludes Homepage & Dynamic Pages
                                </label>
                                <div class="form-input">
                                    <b>(can contain javascript tags, css tags, favicon, meta tags etc - will be applied
                                        to the System pages)</b><br />
                                    <b>Max 2000 characters</b><br />
                                    <asp:TextBox ID="txtSystemPages" runat="server" TextMode="MultiLine" Width="600px"
                                        Height="200px"></asp:TextBox><br />
                                    <asp:CustomValidator ID="cvMetaTags2" runat="server" ErrorMessage="Meta Tags 2 contains more than 2000 characters"
                                        SetFocusOnError="true" ControlToValidate="txtSystemPages" OnServerValidate="cvMetaTags2_ServerValidate" />
                                </div>
                            </li>
                        </ul>
                    </asp:Panel>
                    <ul class="form-section">
                        <li class="form-line" id="gse-ftpfolder-field">
                            <label class="form-label-left">
                                FTP Folder:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataFTPFolder" runat="server"></asp:TextBox>
                            </div>
                        </li>
                    </ul>
                    <ul class="form-section">
                        <li class="form-line" id="gse-modifiedsettings-field">
                            <h3>
                                Modified Settings</h3>
                        </li>
                        <li class="form-line" id="gse-lastmodified-field">
                            <label class="form-label-left">
                                Last Modified:</label>
                            <div class="form-input">
                                <asp:Label runat="server" ID="lblLastModified" MaxLength="10"></asp:Label>
                            </div>
                        </li>
                        <li class="form-line" id="gse-lastmodifiedby-field">
                            <label class="form-label-left">
                                Last Modified By:</label>
                            <div class="form-input">
                                <asp:Label ID="lblLastModifiedBy" runat="server" />
                            </div>
                        </li>
                        <li class="form-line">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <%--<asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnEditSave_Click"
                                        CssClass="jxtadminbutton" />--%>
                                    <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                        CssClass="jxtadminbutton" />
                                    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                        CssClass="jxtadminbutton" CausesValidation="false" />
                                </div>
                            </div>
                        </li>
                    </ul>
                    <script type="text/javascript">
                        CharaterCount("dataDefaultTitle", "spTitleCount", 69);
                        CharaterCount("dataDescription", "spDescriptionCount", 160);
                        CharaterCount("dataDefaultKeywords", "spKeywordsCount", 256);
                        CharaterCount("dataHomeTitle", "spHomeTitleCount", 69);
                        CharaterCount("dataHomeDescription", "spHomeDescriptionCount", 160);
                        CharaterCount("dataHomeKeywords", "spHomeKeywordsCount", 256);
                    </script>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
