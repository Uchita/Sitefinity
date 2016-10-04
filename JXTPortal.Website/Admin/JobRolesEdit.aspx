<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobRolesEdit" Title="JobRoles Edit" Codebehind="JobRolesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Roles - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="JobRoleId" runat="server" DataSourceID="JobRolesDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobRolesFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobRolesFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>JobRoles not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="jxtadminbutton" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="jxtadminbutton" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="jxtadminbutton" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:JobRolesDataSource ID="JobRolesDataSource" runat="server"
			SelectMethod="GetByJobRoleId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="JobRoleId" QueryStringField="JobRoleId" Type="String" />

			</Parameters>
		</data:JobRolesDataSource>
		
		<br />

		

</asp:Content>

