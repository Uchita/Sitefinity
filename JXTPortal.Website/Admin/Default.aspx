<%@ Page Language="C#" Theme="default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Admin_Default" Title="Admin - Global" CodeBehind="Default.aspx.cs" %>

<%@ Register Src="~/usercontrols/advertiser/ucJobsPending.ascx" TagName="ucJobsPending"
    TagPrefix="uc1" %>

    <%@ Register Src="~/admin/usercontrols/DynamicPagesStatusListing.ascx" TagName="ucDynamicPageStatusListing"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Dashboard <a href='//images.jxt.net.au/jxt/docs/Content_Management_System_Overview.pdf'
        class='jxt-help-page' title='click here for CMS Documentation' target='_blank'>Documentation</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="scriptManager" runat="server" />

<style type="text/css">
.dashboard-table {
    background: #555;
    color: #fff;
    height: auto;
    width: 50%;
    border-radius: .4em;
    font:1em/1.5 "arial", sans-serif;
}
    
.dashboard-table table {
    height: auto;
    width: 100%;
    border-radius: .4em;
}
    
.dashboard-table tbody {
    color: #fff;
    padding-left: -15px;
    padding-right: -15px;
}
    
.dashboard-table td a {
       
    background: #0085cc;
    color: #FFF;
    font-family: helvetica;
    font-size: 18px;
    padding-top: 5px;
    height: 30px;
    display: block;
    text-decoration: none;
    text-align: center;
    line-height: 1.4em;
    border-radius: .4em;
    width: 100%;
}
    
.dashboard-table td.description {
    padding-left: 30px;
    width: 50%;
    font-size:18px;
}


.dashboard-table td.dashboard-download {
    padding-left: 30px;
    width: 50%;
}
</style>


    <%--<blockquote>
        Welcome to JXT Admin Page
    </blockquote>--%>
    <div class="form-all">
        <h3>
            Download CMS Documentation</h3>
        <a href='//images.jxt.net.au/jxt/docs/Content_Management_System_Overview.pdf'
            class='jxt-help-page-left' title='click here for CMS Documentation' target='_blank'>
            Download</a>
        <br />
        
        <div class="dashboard-table">
            <table>
                <tbody>
                    <tr>
                        <td class="description">Latest platform update.</td>
                        <td class="dashboard-download">
                            <a href="/admin/sitesummary.aspx" title="click here for CMS Documentation">click here to see them</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


        <br />
        <uc1:ucJobsPending ID="ucJobsPending1" runat="server" IsAdmin="true" Visible="true" />
    </div>
    <br /><br /> 
    <div>
        <uc2:ucDynamicPageStatusListing ID="ucDynamicPageStatusListing1" runat="server" Visible="false" />
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".TablePaginationFooter").css("display", "none"); //hide sort footable for admin page

        });
    </script>

</asp:Content>
 