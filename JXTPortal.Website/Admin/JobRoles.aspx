
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobRoles" Title="JobRoles List" Codebehind="JobRoles.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Roles List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="JobRolesDataSource"
				DataKeyNames="JobRoleId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_JobRoles.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Job Id" DataNavigateUrlFormatString="JobsEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobIdSource" DataTextField="JobName" />
				<data:HyperLinkField HeaderText="Job Archive Id" DataNavigateUrlFormatString="JobsArchiveEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobArchiveIdSource" DataTextField="JobName" />

			</Columns>
			<EmptyDataTemplate>
				<b>No JobRoles Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnJobRoles" OnClientClick="javascript:location.href='JobRolesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:JobRolesDataSource ID="JobRolesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobRolesProperty Name="JobsArchive"/> 
					<data:JobRolesProperty Name="Jobs"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:JobRolesDataSource>
	    		
</asp:Content>



