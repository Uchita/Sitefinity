<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="JobCreate.aspx.cs" Inherits="JXTPortal.Website.advertiser.JobCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    
<style>
	.form-line.checkbox-holder {
		margin-bottom: 20px;
	}
	.form-all .help-block {
		padding-bottom: 15px;
		padding-top: 0px;
		margin-top: 0px;
	}
	#cke_ctl00_ContentPlaceHolder1_ucJobFields_rptLanguagesPanel_ctl01_ucJobFieldsMultiLingual_txtFullDescription{
		max-width: 100%;
	}
	/*
	 .form-all ul li a.mini-new-buttons {
	 padding:10px;
	 font-size: 15px;
	 font-weight: bold;
	 }
	 */
	.form-all ul li a.addVersion {
		margin-bottom: 20px;
	}

	.form-all .input-group {
		margin-bottom: 1em;
	}
	/*
	 .form-all .input-group button {
	 height:49px;
	 }
	 */
	.form-all ul.new-lang-tabs {
		margin: 20px 0 0;
		padding: 0px;
		list-style: none;
	}
	.form-all ul.new-lang-tabs li {
		background: none;
		color: #222;
		display: inline-block;
		padding: 10px 15px;
		cursor: pointer;
	}

	.form-all ul.new-lang-tabs li.current {
		background: #ededed !important;
		color: #222;
	}

	.form-all .tab-content {
		display: none;
		background: #ededed;
		padding: 15px;
	}

	.form-all .tab-content .addQuestionBtn {
		padding: 15px;
		margin-top: 17%;
	}
	.form-all .tab-content.current {
		display: inherit;
	}
	#jobs-location-area select{
		margin-bottom: 15px;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="./styles/ScreeningQuestions/theme-style.css" />
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release" />
    <%--<asp:ScriptManager ID="scriptManager" runat="server" />--%>
    <%--<div id="content">--%>
        <div class="content-holder" class="container">
            <div id="jxt-wrapper-bootstrap">
            <%--<asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>--%>
                    <JXTControl:JobFieldsEdit ID="ucJobFields" runat="server" IsAdmin="false" />
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            </div>
        </div>
    </<%--div--%>>

    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("jxt-wrapper-bootstrap.min.css")))
       { %>
    <link rel="stylesheet" href="//images.jxt.net.au/jxt/jxt-forms-wrapper/jxt-wrapper-bootstrap.min.css" />
    <% } %>

 <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/jxt/jxt-forms-wrapper/bootstrap.min.js'></script>
    <% } %>

    
<script type="text/javascript">
//Doesnt allow double click of submit button
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);

    function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
</script>


</asp:Content>
