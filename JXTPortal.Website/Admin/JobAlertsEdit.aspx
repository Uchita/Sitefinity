<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobAlertsEdit" Title="JobAlerts Edit" Codebehind="JobAlertsEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Alerts - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="JobAlertId" runat="server" DataSourceID="JobAlertsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobAlertsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobAlertsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>JobAlerts not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:JobAlertsDataSource ID="JobAlertsDataSource" runat="server"
			SelectMethod="GetByJobAlertId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="JobAlertId" QueryStringField="JobAlertId" Type="String" />

			</Parameters>
		</data:JobAlertsDataSource>
		
		<br />

		

</asp:Content>

