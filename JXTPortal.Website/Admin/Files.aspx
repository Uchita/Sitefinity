
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="Files" Title="File Management - Files List" Codebehind="Files.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Files List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="FilesDataSource"
				DataKeyNames="FileId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Files.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Folder Id" DataNavigateUrlFormatString="FoldersEdit.aspx?FolderId={0}" DataNavigateUrlFields="FolderId" DataContainer="FolderIdSource" DataTextField="FolderId" />
				<asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="[FileName]"  />
				<asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
				<data:HyperLinkField HeaderText="Last Modified By" DataNavigateUrlFormatString="AdminUsersEdit.aspx?AdminUserId={0}" DataNavigateUrlFields="AdminUserId" DataContainer="LastModifiedBySource" DataTextField="UserName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Files Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnFiles" OnClientClick="javascript:location.href='FilesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:FilesDataSource ID="FilesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:FilesProperty Name="AdminUsers"/> 
					<data:FilesProperty Name="FileTypes"/> 
					<data:FilesProperty Name="Folders"/> 
					<data:FilesProperty Name="Sites"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:FilesDataSource>
	    		
</asp:Content>



