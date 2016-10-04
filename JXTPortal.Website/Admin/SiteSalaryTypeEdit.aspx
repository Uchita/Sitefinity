<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteSalaryTypeEdit" Title="SiteSalaryType Edit" Codebehind="SiteSalaryTypeEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Salary Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SiteSalaryTypeId" runat="server" DataSourceID="SiteSalaryTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SiteSalaryTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SiteSalaryTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SiteSalaryType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SiteSalaryTypeDataSource ID="SiteSalaryTypeDataSource" runat="server"
			SelectMethod="GetBySiteSalaryTypeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SiteSalaryTypeId" QueryStringField="SiteSalaryTypeId" Type="String" />

			</Parameters>
		</data:SiteSalaryTypeDataSource>
		
		<br />

		

</asp:Content>

