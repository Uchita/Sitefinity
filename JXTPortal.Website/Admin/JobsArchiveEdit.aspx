<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobsArchiveEdit" Title="JobsArchive Edit" Codebehind="JobsArchiveEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Jobs Archive - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="JobId" runat="server" DataSourceID="JobsArchiveDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobsArchiveFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/JobsArchiveFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>JobsArchive not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="jxtadminbutton" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="jxtadminbutton" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="jxtadminbutton" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:JobsArchiveDataSource ID="JobsArchiveDataSource" runat="server"
			SelectMethod="GetByJobId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="JobId" QueryStringField="JobId" Type="String" />

			</Parameters>
		</data:JobsArchiveDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewJobArea1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewJobArea1_SelectedIndexChanged"			 			 
			DataSourceID="JobAreaDataSource1"
			DataKeyNames="JobAreaId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_JobArea.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Job Id" DataNavigateUrlFormatString="JobsEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobIdSource" DataTextField="JobName" />
				<data:HyperLinkField HeaderText="Job Archive Id" DataNavigateUrlFormatString="JobsArchiveEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobArchiveIdSource" DataTextField="JobName" />

			</Columns>
			<EmptyDataTemplate>
				<b>No Job Area Found! </b>
				<asp:HyperLink runat="server" ID="hypJobArea" NavigateUrl="~/admin/JobAreaEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:JobAreaDataSource ID="JobAreaDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobAreaProperty Name="JobsArchive"/> 
					<data:JobAreaProperty Name="Jobs"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:JobAreaFilter  Column="JobArchiveId" QueryStringField="JobId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:JobAreaDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewJobRoles2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewJobRoles2_SelectedIndexChanged"			 			 
			DataSourceID="JobRolesDataSource2"
			DataKeyNames="JobRoleId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_JobRoles.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Job Id" DataNavigateUrlFormatString="JobsEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobIdSource" DataTextField="JobName" />
				<data:HyperLinkField HeaderText="Job Archive Id" DataNavigateUrlFormatString="JobsArchiveEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobArchiveIdSource" DataTextField="JobName" />

			</Columns>
			<EmptyDataTemplate>
				<b>No Job Roles Found! </b>
				<asp:HyperLink runat="server" ID="hypJobRoles" NavigateUrl="~/admin/JobRolesEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:JobRolesDataSource ID="JobRolesDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobRolesProperty Name="JobsArchive"/> 
					<data:JobRolesProperty Name="Jobs"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:JobRolesFilter  Column="JobArchiveId" QueryStringField="JobId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:JobRolesDataSource>		
		
		<br />
		

</asp:Content>

