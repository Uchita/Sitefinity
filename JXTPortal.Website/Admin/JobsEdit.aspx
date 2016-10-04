<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="JobsEdit" Title="Jobs Edit" CodeBehind="JobsEdit.aspx.cs"
    ValidateRequest="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
<link rel="stylesheet" href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css">

<link href='//fonts.googleapis.com/css?family=Oswald:400,300,700' rel='stylesheet' type='text/css'>

<link rel="stylesheet" href="//images.jxt.net.au/common/css/style.css" />
<script src='/admin/js/bootstrap.min.js'></script>
<style>
.form-line label {
    float: left;
    width: 210px;
}
.form-section .form-line{
	/*width: auto;*/
}
.form-section > li > div {
    display: inline-block;
}
input[type="text"], textarea {
    padding: 8px 5px;
    margin-bottom: 1em;
}
#content h3 {
    color: #0085cc;
}
.form-buttons-wrapper {
    margin-left: 0 !important;
    margin-top: 1em;
}
.tab-content{
    max-width: 800px;
}
#ctl00_ContentPlaceHolder1_ucJobFields_updatePanel1 .row {
    display: block;
    clear: both;
}
#ctl00_ContentPlaceHolder1_ucJobFields_updatePanel1 .col-md-6.halfBlock {
    width: 50%;
    float: left;
}
</style>

<style>
	.form-line.checkbox-holder {
		margin-bottom: 20px;
	}
	.form-all .help-block {
		padding-bottom: 15px;
		padding-top: 0px;
		margin-top: 0px;
	}
	.form-line {
	    width: 50%;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Jobs - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <JXTControl:JobFieldsEdit ID="ucJobFields" runat="server" IsAdmin="true" />
</asp:Content>


