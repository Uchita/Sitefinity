<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="AdvertiserAccountStatusEdit" Title="Default Account Status Edit" Codebehind="AdvertiserAccountStatusEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Default Account Status - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="AdvertiserAccountStatusId" runat="server" DataSourceID="AdvertiserAccountStatusDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdvertiserAccountStatusFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdvertiserAccountStatusFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AdvertiserAccountStatus not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="jxtadminbutton" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="jxtadminbutton" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="jxtadminbutton" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AdvertiserAccountStatusDataSource ID="AdvertiserAccountStatusDataSource" runat="server"
			SelectMethod="GetByAdvertiserAccountStatusId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="AdvertiserAccountStatusId" QueryStringField="AdvertiserAccountStatusId" Type="String" />

			</Parameters>
		</data:AdvertiserAccountStatusDataSource>
	

</asp:Content>

