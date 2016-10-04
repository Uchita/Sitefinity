<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="SiteSummaryEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteSummaryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- External JS files -->
    <!-- script type="text/javascript" src="http://www.psc.nsw.gov.au/include/js/jquery-1.7.min.js"></script -->
    <script type="text/javascript" src="/admin/js/myjs.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <!-- External CSS files -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link href="/admin/css/select2.css" rel="stylesheet" />
    <link href="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/build/css/bootstrap-datetimepicker.css"
        rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Site Summary Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteProfession" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteProfession" runat="server">
                <ul class="form-section">
                    <asp:PlaceHolder ID="phSite" runat="server" Visible="false">
                        <li class="form-line" id="ss-site-field">
                            <label class="form-label-left">
                                Site:</label>
                            <div class="form-input">
                                <asp:Literal ID="ltSite" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="ss-title-field">
                        <label class="form-label-left">
                            Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbTitle" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_Title" runat="server" ErrorMessage="Required"
                                ControlToValidate="tbTitle" />
                        </div>
                    </li>
                    <li class="form-line" id="ss-description-field">
                        <label class="form-label-left">
                            Description:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbDescription" runat="server" Width="250" TextMode="MultiLine" Rows="4" />
                            <asp:RequiredFieldValidator ID="ReqVal_Description" runat="server" ErrorMessage="Required"
                                ControlToValidate="tbDescription" />
                        </div>
                    </li>
                    <li class="form-line" id="ss-timestamp-field">
                        <label class="form-label-left">
                            Time Stamp:</label>
                        <div class="form-input">
                            <div class='input-group date' id='datetimepicker1' style="width: 250px;">
                                <asp:TextBox ID="txtPublishDate" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="ReqVal_PublishDate" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtPublishDate" />
                            <asp:CustomValidator ID="CusVal_PublishDate" runat="server" ErrorMessage="Invalid Date"
                                ControlToValidate="txtPublishDate" 
                                onservervalidate="CusVal_PublishDate_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="ss-url-field">
                        <label class="form-label-left">
                            URL:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbURL" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_URL" runat="server" ErrorMessage="Required"
                                ControlToValidate="tbURL" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="ss-currency-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlValid" runat="server">
                                <asp:ListItem Value="1">Live</asp:ListItem>
                                <asp:ListItem Value="2">Prelive</asp:ListItem>
                                <asp:ListItem Value="3">Hide</asp:ListItem>
                                <asp:ListItem Value="4">Custom (Only for this site)</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            Last Modified Date:</label>
                        <div class="form-input">
                            <asp:Literal ID="ltLastModifiedDate" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="Li2">
                        <label class="form-label-left">
                            Last Modified By:</label>
                        <div class="form-input">
                            <asp:Literal ID="ltLastModifiedBy" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="jxtadminbutton" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="jxtadminbutton"
                                    OnClick="btnDelete_Click" Visible="False" OnClientClick="return confirm('Are you sure?')" />
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" CssClass="jxtadminbutton"
                                    OnClick="btnEditSave_Click" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="jxtadminbutton"
                                    CausesValidation="false" OnClick="btnReturn_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
                <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
                <script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>
                <script type="text/javascript">
                    $(function () {
                        $('#txtPublishDate').datetimepicker({
                            showClear: true,
                            format: '<%=DateFormat%> hh:mm:ss a'
                        });
                    });
                </script>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
