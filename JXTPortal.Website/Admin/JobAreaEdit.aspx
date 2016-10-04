<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobAreaEdit" Title="JobArea Edit" Codebehind="JobAreaEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Area - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="JobAreaId" runat="server" DataSourceID="JobAreaDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobAreaFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobAreaFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>JobArea not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="jxtadminbutton" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="jxtadminbutton" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="jxtadminbutton" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:JobAreaDataSource ID="JobAreaDataSource" runat="server"
			SelectMethod="GetByJobAreaId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="JobAreaId" QueryStringField="JobAreaId" Type="String" />

			</Parameters>
		</data:JobAreaDataSource>
		
		<br />

		

</asp:Content>

