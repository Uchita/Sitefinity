<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteWebPartTypesEdit" Title="SiteWebPartTypes Edit" Codebehind="SiteWebPartTypesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Web Part Types - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SiteWebPartTypeId" runat="server" DataSourceID="SiteWebPartTypesDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SiteWebPartTypesFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SiteWebPartTypesFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SiteWebPartTypes not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="jxtadminbutton" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="jxtadminbutton" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="jxtadminbutton" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SiteWebPartTypesDataSource ID="SiteWebPartTypesDataSource" runat="server"
			SelectMethod="GetBySiteWebPartTypeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SiteWebPartTypeId" QueryStringField="SiteWebPartTypeId" Type="String" />

			</Parameters>
		</data:SiteWebPartTypesDataSource>
		
		<br />
		

</asp:Content>

