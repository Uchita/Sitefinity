<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    ValidateRequest="false" AutoEventWireup="true" Inherits="WidgetContainersEdit"
    Title="Sites - Advanced Search Widget Edit" CodeBehind="WidgetContainersEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Widget Containers - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="sp-defaultprofessionname-field">
                <label class="form-label-left">
                    Language:</label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlLanguage" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="ddlLanguage" ErrorMessage="Required" />
                </div>
            </li>
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    Widget Name:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtWidgetName" runat="server" /><asp:RequiredFieldValidator ID="ReqVal_txtWidgetName"
                        runat="server" Display="Dynamic" ControlToValidate="txtWidgetName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Widget Domain:
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtWidgetDomain" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li7">
                <label class="form-label-left">
                    Valid:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkValid" runat="server" />
                </div>
            </li>
            <!--<li class="form-line" id="Li8">
                <label class="form-label-left">
                    Show Jobs:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkShowJobs" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Show Companies:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkShowCompanies" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Show Site:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkShowSite" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Show People:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkShowPeople" runat="server" />
                </div>
            </li>-->
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Job Html:
                </label>
                <div class="form-input">
                    <table id="table_jobHTML">
                        <tbody>
                            <tr>
                                <td>
                                    Keyword
                                </td>
                                <td>
                                    {Keywords}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Classification
                                </td>
                                <td>
                                    {Professions}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sub Classification
                                </td>
                                <td>
                                    {Roles}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Location
                                </td>
                                <td>
                                    {Location}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Location Area
                                </td>
                                <td>
                                    {LocationArea}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Location Area Drop Down
                                </td>
                                <td>
                                    {LocationAreaDropDown}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Work Types
                                </td>
                                <td>
                                    {WorkTypes}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Advertisers
                                </td>
                                <td>
                                    {Advertisers}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Salary
                                </td>
                                <td>
                                    {Salary}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Submit
                                </td>
                                <td>
                                    &lt;input type="submit" value="Submit" onclick="JobSearch(); return false;"&gt;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <FredCK:CKEditorControl ID="txtJobHtml" runat="server" Width="650px" Height="400px" CustomConfig="custom_config.js"
                        Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                </div>
            </li>
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Company Html:
                </label>
                <div class="form-input">
                    <table id="table1">
                        <tbody>
                            <tr>
                                <td>
                                    Keyword
                                </td>
                                <td>
                                    &lt;input type="text" class="textbox" id="s" name="s"/&gt;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Advanced Search
                                </td>
                                <td>
                                    &lt;a href="http://www.jobx.com.au/AdvancedSearch.aspx?widgetSearch=True"&gt;Advanced
                                    Search &lt;/a&gt;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Submit
                                </td>
                                <td>
                                    &lt;a href="javascript:CompanySearch();"&gt;&lt;img src="http://www.jobx.com.au/images/widgets/WidgetSearchButton.jpg"
                                    name="Image17" border="0"&gt;&lt;/a/&gt;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <FredCK:CKEditorControl ID="txtCompanyHtml" runat="server" Width="650px" Height="400px"
                        CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                </div>
            </li>
            <li class="form-line" id="Li9">
                <label class="form-label-left">
                    Site Html:
                </label>
                <div class="form-input">
                    <table id="table2">
                        <tbody>
                            <tr>
                                <td>
                                    Keywords
                                </td>
                                <td>
                                    {Keywords}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Language (Dropdown)
                                </td>
                                <td>
                                    {Languages}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Submit
                                </td>
                                <td>
                                    &lt;input type="submit" value="Submit" onclick="SiteSearch(); return false;" /&gt;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <FredCK:CKEditorControl ID="txtSiteHtml" runat="server" Width="650px" Height="400px" CustomConfig="custom_config.js"
                        Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                </div>
            </li>
            <li class="form-line" id="Li10">
                <label class="form-label-left">
                    People Html:
                </label>
                <div class="form-input">
                    <table id="table_PeopleHTML">
                        <tbody>
                            <tr>
                                <td>
                                    Search Term
                                </td>
                                <td>
                                    &lt;input type="text" class="textbox" id="s" name="s"/&gt;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Industry
                                </td>
                                <td>
                                    {Industries}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Classification
                                </td>
                                <td>
                                    {Professions}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sub Classification
                                </td>
                                <td>
                                    {Roles}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Salary
                                </td>
                                <td>
                                    {Salary}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Availability
                                </td>
                                <td>
                                    {Availability}
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Search Tips
                                </td>
                                <td>
                                    &lt;a href="javascript:showSearchTips();" class="tip-link"&gt;Get Search Tips&lt;/a&gt;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Advanced Search
                                </td>
                                <td>
                                    &lt;a href="http://www.jobx.com.au/AdvancedSearch.aspx?widgetSearch=True"&gt;Advanced
                                    Search &lt;/a&gt;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Submit
                                </td>
                                <td>
                                    &lt;a href="javascript:PeopleSearch();"&gt;&lt;img src="http://www.jobx.com.au/images/widgets/WidgetSearchButton.jpg"
                                    name="Image17" border="0"&gt;&lt;/a/&gt;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <FredCK:CKEditorControl ID="txtPeopleHtml" runat="server" Width="650px" Height="400px" CustomConfig="custom_config.js"
                        Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                </div>
            </li>
            <li class="form-line" id="Li11">
                <label class="form-label-left">
                    Javascript: <br />
                    (Add script tags)
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtJavascript" runat="server" TextMode="MultiLine" Rows="20" Columns="75" />
                </div>
            </li>
            <li class="form-line" id="Li11">
                <label class="form-label-left">
                    Css:<br />
                    (Add style tags)
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtSearchCss" runat="server" TextMode="MultiLine" Rows="20" Columns="75" />
                </div>
            </li>
            <li class="form-line" id="Li12">
                <label class="form-label-left">
                    Default ProfessionId:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlDefaultProfessionId" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li14">
                <label class="form-label-left">
                    Default CountryId:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlDefaultCountryId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDefaultCountryId_SelectedIndexChanged" />
                </div>
            </li>
            <li class="form-line" id="Li15">
                <label class="form-label-left">
                    Default LocationId:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlLocationId" runat="server" />
                </div>
            </li>
            <!--<li class="form-line" id="Li13">
                <label class="form-label-left">
                    Width:
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtWidth" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li16">
                <label class="form-label-left">
                    Height:
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtHeight" runat="server" />
                </div>
            </li>-->
            <li class="form-line" id="Li17">
                <label class="form-label-left">
                    On Advanced Search:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkOnAdvancedSearch" runat="server" />
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnEditSave_Click"
                            CssClass="jxtadminbutton" />
                        <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                            CssClass="jxtadminbutton" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
