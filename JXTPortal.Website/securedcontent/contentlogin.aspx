<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.Master" AutoEventWireup="true"
    CodeBehind="contentlogin.aspx.cs" Inherits="JXTPortal.Website.securedcontent.contentlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

        
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="/admin/css/login/login.css" type="text/css" media="screen" title="default" />
        
    <asp:Literal ID="ltJquery" runat="server" />
    <script src="/admin/js/login/custom_jquery.js" type="text/javascript"></script>
    <script src="/admin/js/login/jquery.pngFix.pack.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function(){
        $(document).pngFix( );
        });
    </script>
    
    <div id="content">
    <div id="login-holder-secure">
        
            <%--<div id="logo-login-secure">
                <asp:HyperLink ID="hypAdminLogo" runat="server" />
            </div>--%>
            
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_SecuredMemberLogin" />
            
            <div id="login-secure-content"></div>

            <%--<div id="login-secure-error" ><asp:Literal ID="ltErrorMessage" runat="server" /></div>--%>
            <asp:Literal ID="ltErrorMessage" runat="server" />
            
            <div id="loginbox-secure">
                
                <div id="login-inner-secure">
                    
                    <table border="0" cellpadding="0" cellspacing="0" class="secure-login">
                        
                        <h2 id="loginSecureTitle" class="secure-login-title">Secure Page Login</h2>
                        
                        <%--<tr>
                            <td id="advertiserLogin-errorMessage">
                                <asp:Literal ID="ltErrorMessage" runat="server" />
                            </td>
                        </tr>--%>
                        
                        <tr>
                            <th>
                                    <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />: 
                            </th>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="login-inp" />
                            </td>
                        </tr>
                        
                        <tr>
                            <th>
                                
                                    <JXTControl:ucLanguageLiteral ID="ltPassword" runat="server" SetLanguageCode="LabelPassword" />: 
                            
                            </th>
                            
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="login-inp" />                 
                            </td>                        
                        </tr>
                        
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="submit-login" />
                            </td>
                        </tr>
                    
                    </table>
                </div>              
                
            </div>
            
            
            <%--<div class="login-main-holder">
                <div class="form-all">
                    <ul class="form-section">
                        <li class="form-required" id="advertiserLogin-errorMessage">
                            <asp:Literal ID="ltErrorMessage" runat="server" />
                        </li>
                        <li class="form-line" id="search-keywords">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />
                                : <span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-textbox" />
                            </div>
                        </li>
                        <li class="form-line" id="search-keywords">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltPassword" runat="server" SetLanguageCode="LabelPassword" />
                                : <span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-textbox" />
                            </div>
                        </li>
                    </ul>
                </div>
                <div class="member-submitbottom">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="mini-new-buttons" />
                </div>
            </div>--%>
            
            
        </div>
     </div>
        </div>

</asp:Content>
