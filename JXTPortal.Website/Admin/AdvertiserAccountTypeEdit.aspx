<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="AdvertiserAccountTypeEdit" Title="Advertisers - Advertiser Account Type Edit" Codebehind="AdvertiserAccountTypeEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Advertiser Account Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="AdvertiserAccountTypeId" runat="server" DataSourceID="AdvertiserAccountTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdvertiserAccountTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdvertiserAccountTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AdvertiserAccountType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="jxtadminbutton" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="jxtadminbutton" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="jxtadminbutton" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AdvertiserAccountTypeDataSource ID="AdvertiserAccountTypeDataSource" runat="server"
			SelectMethod="GetByAdvertiserAccountTypeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="AdvertiserAccountTypeId" QueryStringField="AdvertiserAccountTypeId" Type="String" />

			</Parameters>
		</data:AdvertiserAccountTypeDataSource>

</asp:Content>

