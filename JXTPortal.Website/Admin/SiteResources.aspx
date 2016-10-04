<%@ Page Title="Sites - Site Resources List" Theme="Default" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteResources.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteResources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Site Resources List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnRowCommand="GridView1_OnRowCommand"
				DataSourceID="DefaultResourcesDataSource"
				DataKeyNames="DefaultResourceId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DefaultResources.xls"  		
			>
			<Columns>
                <asp:BoundField DataField="ResourceCode" HeaderText="Code" SortExpression="[ResourceCode]"  />
                <asp:BoundField DataField="ResourceFileID" HeaderText="File ID" SortExpression="[ResourceFileID]"  />
                <asp:BoundField DataField="ResourceText" HeaderText="Text" SortExpression="[ResourceText]"  />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbOverwrite" runat="server" Text="Overwrite" CommandName="Overwrite" CommandArgument='<%# Bind("DefaultResourceId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				<b>No Files Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<data:DefaultResourcesDataSource ID="DefaultResourcesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DefaultResourcesDataSource>
</asp:Content>
