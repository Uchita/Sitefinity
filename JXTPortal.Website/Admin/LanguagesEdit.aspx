<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="LanguagesEdit" Title="Languages Edit" Codebehind="LanguagesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Languages - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="LanguageId" runat="server" DataSourceID="LanguagesDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LanguagesFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LanguagesFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Languages not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LanguagesDataSource ID="LanguagesDataSource" runat="server"
			SelectMethod="GetByLanguageId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="LanguageId" QueryStringField="LanguageId" Type="String" />

			</Parameters>
		</data:LanguagesDataSource>
		
		<br />

		

</asp:Content>

