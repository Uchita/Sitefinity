
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobsArchive" Title="JobsArchive List" Codebehind="JobsArchive.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Jobs Archive List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="JobsArchiveDataSource"
				DataKeyNames="JobId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_JobsArchive.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				


                <asp:BoundField DataField="RefNo" HeaderText="Ref No" SortExpression="[RefNo]"  />
				<asp:BoundField DataField="JobName" HeaderText="Job Name" SortExpression="[JobName]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="ApplicationEmailAddress" HeaderText="Application Email Address" SortExpression="[ApplicationEmailAddress]"  />
				<asp:BoundField DataField="Expired" HeaderText="Expired" SortExpression="[Expired]"  />
				<asp:BoundField DataField="Billed" HeaderText="Billed" SortExpression="[Billed]"  />
				<asp:BoundField DataField="DatePosted" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Posted" SortExpression="[DatePosted]"  />
				<asp:BoundField DataField="ExpiryDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Expiry Date" SortExpression="[ExpiryDate]"  />
				<asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No JobsArchive Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnJobsArchive" OnClientClick="javascript:location.href='JobsArchiveEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:JobsArchiveDataSource ID="JobsArchiveDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobsArchiveProperty Name="JobItemsType"/> 
					<data:JobsArchiveProperty Name="JobTemplates"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:JobsArchiveDataSource>
	    		
</asp:Content>



