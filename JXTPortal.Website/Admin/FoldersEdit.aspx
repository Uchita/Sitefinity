<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="FoldersEdit" Title="Folders Edit" Codebehind="FoldersEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Folders - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="FolderId" runat="server" DataSourceID="FoldersDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FoldersFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FoldersFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Folders not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:FoldersDataSource ID="FoldersDataSource" runat="server"
			SelectMethod="GetByFolderId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="FolderId" QueryStringField="FolderId" Type="String" />

			</Parameters>
		</data:FoldersDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewFiles1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewFiles1_SelectedIndexChanged"			 			 
			DataSourceID="FilesDataSource1"
			DataKeyNames="FileId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Files.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Site Id" DataNavigateUrlFormatString="SitesEdit.aspx?SiteId={0}" DataNavigateUrlFields="SiteId" DataContainer="SiteIdSource" DataTextField="SiteName" />
				<data:HyperLinkField HeaderText="Folder Id" DataNavigateUrlFormatString="FoldersEdit.aspx?FolderId={0}" DataNavigateUrlFields="FolderId" DataContainer="FolderIdSource" DataTextField="ParentFolderId" />
				<asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="[FileName]" />				
				<asp:BoundField DataField="FileSystemName" HeaderText="File System Name" SortExpression="[FileSystemName]" />				
				<data:HyperLinkField HeaderText="File Type Id" DataNavigateUrlFormatString="FileTypesEdit.aspx?FileTypeId={0}" DataNavigateUrlFields="FileTypeId" DataContainer="FileTypeIdSource" DataTextField="FileTypeName" />
				<asp:BoundField DataField="LastModified" HeaderText="Last Modified" SortExpression="[LastModified]" />				
				<data:HyperLinkField HeaderText="Last Modified By" DataNavigateUrlFormatString="AdminUsersEdit.aspx?AdminUserId={0}" DataNavigateUrlFields="AdminUserId" DataContainer="LastModifiedBySource" DataTextField="UserName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Files Found! </b>
				<asp:HyperLink runat="server" ID="hypFiles" NavigateUrl="~/admin/FilesEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:FilesDataSource ID="FilesDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:FilesFilter  Column="FolderId" QueryStringField="FolderId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:FilesDataSource>		
		
		<br />
		

</asp:Content>

