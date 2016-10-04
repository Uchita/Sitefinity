
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteRoles" Title="SiteRoles List" Codebehind="SiteRoles.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Roles List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SiteRolesDataSource"
				DataKeyNames="SiteRoleId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SiteRoles.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				

				<data:HyperLinkField HeaderText="Role Id" DataNavigateUrlFormatString="RolesEdit.aspx?RoleId={0}" DataNavigateUrlFields="RoleId" DataContainer="RoleIdSource" DataTextField="RoleName" />
				<asp:BoundField DataField="SiteRoleName" HeaderText="Site Role Name" SortExpression="[SiteRoleName]"  />
				<asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]"  />
				<asp:BoundField DataField="MetaTitle" HeaderText="Meta Title" SortExpression="[MetaTitle]"  />
				<asp:BoundField DataField="MetaKeywords" HeaderText="Meta Keywords" SortExpression="[MetaKeywords]"  />
				<asp:BoundField DataField="MetaDescription" HeaderText="Meta Description" SortExpression="[MetaDescription]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SiteRoles Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSiteRoles" OnClientClick="javascript:location.href='SiteRolesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SiteRolesDataSource ID="SiteRolesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SiteRolesProperty Name="Roles"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SiteRolesDataSource>
	    		
</asp:Content>



