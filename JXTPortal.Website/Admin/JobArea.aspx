
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobArea" Title="JobArea List" Codebehind="JobArea.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Area List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="JobAreaDataSource"
				DataKeyNames="JobAreaId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_JobArea.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Job Id" DataNavigateUrlFormatString="JobsEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobIdSource" DataTextField="JobName" />
				<data:HyperLinkField HeaderText="Job Archive Id" DataNavigateUrlFormatString="JobsArchiveEdit.aspx?JobId={0}" DataNavigateUrlFields="JobId" DataContainer="JobArchiveIdSource" DataTextField="JobName" />

			</Columns>
			<EmptyDataTemplate>
				<b>No JobArea Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnJobArea" OnClientClick="javascript:location.href='JobAreaEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:JobAreaDataSource ID="JobAreaDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobAreaProperty Name="JobsArchive"/> 
					<data:JobAreaProperty Name="Jobs"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:JobAreaDataSource>
	    		
</asp:Content>



