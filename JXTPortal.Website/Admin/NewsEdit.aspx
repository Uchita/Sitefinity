<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    ValidateRequest="false" AutoEventWireup="true" Inherits="NewsEdit" Title="News Edit"
    CodeBehind="NewsEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News - Add/Edit <a href='http://support.jxt.com.au/solution/articles/116441-news'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.2/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.2/js/select2.min.js"></script>

    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="FormView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="NewsView" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="news-newscategoryid-field">
                        <label class="form-label-left">
                            News Category Id:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <data:EntityDropDownList runat="server" ID="dataNewsCategoryId" Required="true" ErrorText="Required"
                                NullItemText=" Please Choose ..." CssClass="form-multiple-column" DataValueField="NewsCategoryId"
                                DataTextField="NewsCategoryName" Width="250px" />
                            <data:NewsCategoriesDataSource ID="NewsCategoryIdNewsCategoriesDataSource" runat="server"
                                SelectMethod="GetBySiteId">
                            </data:NewsCategoriesDataSource>
                        </div>
                    </li>
                    <li class="form-line" id="news-subject-field">
                        <label class="form-label-left">
                            Subject:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataSubject" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="ReqVal_dataSubject" runat="server" Display="Dynamic" ControlToValidate="dataSubject"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="Li6">
                        <label class="form-label-left">
                            Friendly Name:<span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtPageFriendlyName" runat="server" Width="250px" />&nbsp;<a href="javascript:void(0);"
                                onclick="checkFriendlyUrlChanged()">Generate</a>
                            <asp:RequiredFieldValidator ID="rvPageFriendlyName" runat="server" Display="Dynamic"
                                ControlToValidate="txtPageFriendlyName" ErrorMessage="Required" />
                        </div>
                    </li>
                    <li class="form-line" id="Li7">
                        <label class="form-label-left">
                            Thumbnail URL:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="tbImageURL" runat="server" Width="250px" />
                            <div class="form-notation">To make an image appear on the results page, upload an image via <a href="/admin/filemanager.aspx" target="_blank">file manager</a>. 
                            Then paste the URL path here. Recommended size: 200px x 100px</div>
                        </div>
                    </li>
                    <li class="form-line" id="news-content-field">
                        <label class="form-label-left">
                            Content:</label>
                        <div class="form-input">
                            <FredCK:CKEditorControl ID="txtPageContent" runat="server" Width="650px" Height="400px"
                                CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                            </FredCK:CKEditorControl>
                        </div>
                    </li>
                    <li class="form-line" id="Li8">
                        <label class="form-label-left">
                            Author:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="tbAuthor" runat="server" Width="250px" />
                        </div>
                    </li>
                    <li class="form-line" id="news-postdate-field">
                        <label class="form-label-left">
                            Post Date:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataPostDate" MaxLength="10" Width="250px"></asp:TextBox>
                            <asp:ImageButton ID="ibDataPostDate" runat="server" SkinID="CalendarImageButton"
                                CausesValidation="False" />
                            <ajaxToolkit:CalendarExtender ID="cal_dataPostDate" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="dataPostDate" PopupButtonID="ibDataPostDate">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RequiredFieldValidator ID="ReqVal_dataPostDate" runat="server" ControlToValidate="dataPostDate"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvPostDate" runat="server" ControlToValidate="dataPostDate" OnServerValidate="cvPostDate_ServerValidate" />

                        </div>
                    </li>
                    <li class="form-line" id="news-valid-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <div class="form-single-column">
                                <span class="form-checkbox-item" style="clear: left;">
                                    <input type="checkbox" class="form-checkbox" value="Valid" runat="server" id="chkValid" /></span>
                                <span class="clearfix"></span>
                            </div>
                        </div>
                    </li>
                    <li class="form-line" id="news-sequence-field" style="display: none">
                        <label class="form-label-left">
                            Sequence:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataSequence" Width="250px"></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSequence"
                                runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Invalid value"
                                MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                        </div>
                    </li>
                    <li class="form-line" id="news-tags-field">
                        <label class="form-label-left">
                            Tags:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataTags" MaxLength="250" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <asp:Panel ID="pnlIndustries" runat="server" Visible="false">
                    <li class="form-line" id="Li4">
                        <label class="form-label-left">
                            Industries:
                        </label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlIndustries" runat="server" Width="500px">
                            </asp:DropDownList>
                        </div>
                    </li>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlNewsType" runat="server" Visible="false">
                    <li class="form-line" id="Li5">
                        <label class="form-label-left">
                            News Type:
                        </label>
                        <div class="form-input">
                            <asp:ListBox ID="lstNewsType" runat="server" SelectionMode="Multiple" Width="500px"></asp:ListBox>
                            
                        </div>
                    </li>
                    </asp:Panel>

                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            Meta Title:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtMetaTitle" runat="server" TextMode="MultiLine" Rows="6" Columns="40" Width="250px" />&nbsp;<span id="spTitleCount"></span>
                        </div>
                    </li>
                    <li class="form-line" id="Li2">
                        <label class="form-label-left">
                            Meta Keywords:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtMetaKeywords" runat="server" TextMode="MultiLine" Rows="6" Columns="40" Width="250px" />&nbsp;<span id="spKeywordsCount"></span>
                        </div>
                    </li>
                    <li class="form-line" id="Li3">
                        <label class="form-label-left">
                            Meta Description:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtMetaDescription" runat="server" TextMode="MultiLine" Rows="6" Columns="40" Width="250px" />&nbsp;<span id="spDescriptionCount"></span>
                        </div>
                    </li>
                    <li class="form-line" id="news-lastmodified-field">
                        <label class="form-label-left">
                            Last Modified:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataLastModified" MaxLength="10"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="news-lastmodifiedby-field">
                        <label class="form-label-left">
                            Last Modified By:</label>
                        <div class="form-input">
                            <asp:Label ID="dataLastModifiedBy" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                Text="Insert" OnClick="InsertButton_Click" CssClass="jxtadminbutton" />
                            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" OnClick="UpdateButton_Click" CssClass="jxtadminbutton" />
                            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" OnClick="CancelButton_Click" CssClass="jxtadminbutton" />
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
    <br />
    <script type='text/javascript'>

        var FriendlyUrlValue = $('#<%= txtPageFriendlyName.ClientID %>').val().toLowerCase();

        function checkFriendlyUrlChanged() {

            var currentValue = $('#<%= txtPageFriendlyName.ClientID %>').val().toLowerCase();

            FriendlyUrlValue = currentValue;
            FriendlyUrlValue = $('#<%= dataSubject.ClientID %>').val().toLowerCase();

            FriendlyUrlValue = FriendlyUrlValue.replace("+", "plus").replace("?", "").replace("&", "and").replace("'", "-").replace(/  +/g, "-").replace(/[\W]/gi, "-").replace(/[-]+/gi, "-");

            if (FriendlyUrlValue.substring(FriendlyUrlValue.length - 1, FriendlyUrlValue.length) == '-')
                FriendlyUrlValue = FriendlyUrlValue.substring(0, FriendlyUrlValue.length - 1);

            $("#<%= txtPageFriendlyName.ClientID %>").val(FriendlyUrlValue);

        }

        function CharaterCount(textboxid, spanid, max) {
            var len = $("#" + textboxid).val().length;
            $("#" + spanid).text("Character Count: " + len);
            if (len > max) {
                $("#" + spanid).css("color", "red");
            }
            else {
                $("#" + spanid).css("color", "black");
            }
        }

        $('select').select2();
    </script>

</asp:Content>
