<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="DynamicPageFiles" Title="DynamicPageFiles List" Codebehind="DynamicPageFiles.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dynamic Page Files List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DynamicPageFilesDataSource"
				DataKeyNames="DynamicPageFileId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DynamicPageFiles.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Site Id" DataNavigateUrlFormatString="SitesEdit.aspx?SiteId={0}" DataNavigateUrlFields="SiteId" DataContainer="SiteIdSource" DataTextField="SiteName" />
				<asp:BoundField DataField="PageName" HeaderText="Page Name" SortExpression="[PageName]"  />
				<data:HyperLinkField HeaderText="File Id" DataNavigateUrlFormatString="FilesEdit.aspx?FileId={0}" DataNavigateUrlFields="FileId" DataContainer="FileIdSource" DataTextField="FileName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No DynamicPageFiles Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDynamicPageFiles" OnClientClick="javascript:location.href='DynamicPageFilesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DynamicPageFilesDataSource ID="DynamicPageFilesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DynamicPageFilesProperty Name="Files"/> 
					<data:DynamicPageFilesProperty Name="Sites"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DynamicPageFilesDataSource>
	    		
</asp:Content>



