<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="EmailFormatsEdit" Title="EmailFormats Edit" Codebehind="EmailFormatsEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Email Formats - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="EmailFormatId" runat="server" DataSourceID="EmailFormatsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmailFormatsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmailFormatsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>EmailFormats not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EmailFormatsDataSource ID="EmailFormatsDataSource" runat="server"
			SelectMethod="GetByEmailFormatId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EmailFormatId" QueryStringField="EmailFormatId" Type="String" />

			</Parameters>
		</data:EmailFormatsDataSource>
		
		

</asp:Content>

