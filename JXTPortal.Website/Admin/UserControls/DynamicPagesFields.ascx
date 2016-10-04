<%@ Control Language="C#" ClassName="DynamicPagesFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataParentDynamicPageId" runat="server" Text="Parent Dynamic Page:"
                        AssociatedControlID="dataParentDynamicPageId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataParentDynamicPageId" Text='<%# Bind("ParentDynamicPageId") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataParentDynamicPageId" runat="server" Display="Dynamic" ControlToValidate="dataParentDynamicPageId"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataParentDynamicPageId"
                            runat="server" Display="Dynamic" ControlToValidate="dataParentDynamicPageId"
                            ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                            Type="Integer"></asp:RangeValidator>
                    <asp:DropDownList ID="ddlParentDynamicPage" runat="server" />
                    <data:DynamicPageWebPartTemplatesDataSource ID="DynamicPageWebPartTemplatesDataSource1"
                        runat="server" SelectMethod="GetAll" />
                    <data:DynamicPagesDataSource ID="dynamicPageParentDataSource" runat="server" SelectMethod="GetHierarchy" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPageName" runat="server" Text="Page Name:" AssociatedControlID="dataPageName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPageName" Text='<%# Bind("PageName") %>' Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataPageName" runat="server" Display="Dynamic" ControlToValidate="dataPageName"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPageTitle" runat="server" Text="Page Title:" AssociatedControlID="dataPageTitle" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPageTitle" Text='<%# Bind("PageTitle") %>' Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataPageTitle" runat="server" Display="Dynamic" ControlToValidate="dataPageTitle"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLanguage" runat="server" Text="Language:" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataLanguage" DataSourceID="dataLanguagesDataSource"
                        DataTextField="LanguageName" DataValueField="LanguageID" SelectedValues='<%# Bind("LanguageID") %>' AppendNullItem="true"
                        Required="true" NullItemText="< Please Choose ...>" />
                    <data:LanguagesDataSource ID="dataLanguagesDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPageContent" runat="server" Text="Page Content:" AssociatedControlID="dataPageContent" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPageContent" Text='<%# Bind("PageContent") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                    <JXTControl:TinyMCETextBoxExtender ID="TinyMCETextBoxExtender1" runat="server" TargetControlID="dataPageContent"
                        Theme="advanced">
                        <InitList>
                            <JXTControl:TinyMCETextBoxInit Var="Plugins" Value="inlinepopups,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons1" Value="bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons2" Value="cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons3" Value="tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons4" Value="insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,|,visualchars,nonbreaking" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Toolbar_Location" Value="top" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Toolbar_Align" Value="left" />
                            <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Statusbar_Location" Value="bottom" />
                            <JXTControl:TinyMCETextBoxInit Var="Extended_Valid_Elements" Value="a[name|href|target|title|onclick],img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name],hr[class|width|size|noshade],font[face|size|color|style],span[class|align|style]" />
                        </InitList>
                    </JXTControl:TinyMCETextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDynamicPageWebPartTemplateId" runat="server" Text="Dynamic Page Web Part Template:"
                        AssociatedControlID="dataDynamicPageWebPartTemplateId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataDynamicPageWebPartTemplateId" DataSourceID="DynamicPageWebPartTemplateIdDynamicPageWebPartTemplatesDataSource"
                        DataTextField="DynamicPageWebPartName" DataValueField="DynamicPageWebPartTemplateId"
                        SelectedValue='<%# Bind("DynamicPageWebPartTemplateId") %>' AppendNullItem="true"
                        Required="false" NullItemText="< Please Choose ...>" />
                    <data:DynamicPageWebPartTemplatesDataSource ID="DynamicPageWebPartTemplateIdDynamicPageWebPartTemplatesDataSource"
                        runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataHyperLink" runat="server" Text="Hyperlink:" AssociatedControlID="dataHyperLink" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataHyperLink" Text='<%# Bind("HyperLink") %>' Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataOpenInNewWindow" runat="server" Text="Open In New Window:"
                        AssociatedControlID="dataOpenInNewWindow" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataOpenInNewWindow" SelectedValue='<%# Bind("OpenInNewWindow") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSequence" runat="server" Text="Sequence:" AssociatedControlID="dataSequence" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSequence" Text='<%# Bind("Sequence") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="dataSequence"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSequence"
                            runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Invalid value"
                            MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFullScreen" runat="server" Text="Full Screen:" AssociatedControlID="dataFullScreen" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataFullScreen" SelectedValue='<%# Bind("FullScreen") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataOnTopNav" runat="server" Text="On Top Nav:" AssociatedControlID="dataOnTopNav" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataOnTopNav" SelectedValue='<%# Bind("OnTopNav") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataOnLeftNav" runat="server" Text="On Left Nav:" AssociatedControlID="dataOnLeftNav" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataOnLeftNav" SelectedValue='<%# Bind("OnLeftNav") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataOnBottomNav" runat="server" Text="On Bottom Nav:" AssociatedControlID="dataOnBottomNav" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataOnBottomNav" SelectedValue='<%# Bind("OnBottomNav") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataOnSiteMap" runat="server" Text="On Site Map:" AssociatedControlID="dataOnSiteMap" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataOnSiteMap" SelectedValue='<%# Bind("OnSiteMap") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSearchable" runat="server" Text="Searchable:" AssociatedControlID="dataSearchable" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataSearchable" SelectedValue='<%# Bind("Searchable") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSearchField" runat="server" Text="Search Field:" AssociatedControlID="dataSearchField" />
                </td>
                <td>
                    <asp:HiddenField runat="server" ID="dataSearchField" Value='<%# Bind("SearchField") %>'>
                    </asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMetaKeywords" runat="server" Text="Meta Keywords:" AssociatedControlID="dataMetaKeywords" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataMetaKeywords" Text='<%# Bind("MetaKeywords") %>'
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaKeywords"
                            runat="server" Display="Dynamic" ControlToValidate="dataMetaKeywords" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMetaDescription" runat="server" Text="Meta Description:" AssociatedControlID="dataMetaDescription" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataMetaDescription" Text='<%# Bind("MetaDescription") %>'
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaDescription"
                            runat="server" Display="Dynamic" ControlToValidate="dataMetaDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPageFriendlyName" runat="server" Text="Page Friendly Name:"
                        AssociatedControlID="dataPageFriendlyName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPageFriendlyName" Text='<%# Bind("PageFriendlyName") %>'
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPageFriendlyName"
                            runat="server" Display="Dynamic" ControlToValidate="dataPageFriendlyName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" />
                </td>
                <td>
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>'
                        MaxLength="10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModifiedBy" runat="server" Text="Last Modified By:" AssociatedControlID="dataLastModifiedBy" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataLastModifiedBy" DataSourceID="LastModifiedByAdminUsersDataSource"
                        DataTextField="UserName" DataValueField="AdminUserId" SelectedValue='<%# Bind("LastModifiedBy") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:AdminUsersDataSource ID="LastModifiedByAdminUsersDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
