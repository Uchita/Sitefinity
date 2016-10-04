
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="FileTypes" Title="File Management - File Types" Codebehind="FileTypes.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">File Types List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid-search"> 
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
    </div>
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="FileTypesDataSource"
				DataKeyNames="FileTypeId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_FileTypes.xls"  
				AlternatingRowStyle-CssClass="grid-alt-row"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" ShowDeleteButton="false" />	
				<asp:CommandField ShowSelectButton="false" ShowEditButton="False" ShowDeleteButton="true" />	
				<asp:BoundField DataField="FileTypeID" HeaderText="File Type ID" SortExpression="[FileTypeID]"  />			
				<asp:BoundField DataField="FileTypeName" HeaderText="File Type Name" SortExpression="[FileTypeName]"  />
				<asp:BoundField DataField="FileTypeExtension" HeaderText="File Type Extension" SortExpression="[FileTypeExtension]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No FileTypes Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnFileTypes" OnClientClick="javascript:location.href='FileTypesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:FileTypesDataSource ID="FileTypesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:FileTypesDataSource>
	    		
</asp:Content>



