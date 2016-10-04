
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteArea" Title="SiteArea List" Codebehind="SiteArea.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Area List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SiteAreaDataSource"
				DataKeyNames="SiteAreaId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SiteArea.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Area Id" DataNavigateUrlFormatString="AreaEdit.aspx?AreaId={0}" DataNavigateUrlFields="AreaId" DataContainer="AreaIdSource" DataTextField="AreaName" />

				<asp:BoundField DataField="SiteAreaName" HeaderText="Site Area Name" SortExpression="[SiteAreaName]"  />
				<data:BoundRadioButtonField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SiteArea Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSiteArea" OnClientClick="javascript:location.href='SiteAreaEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SiteAreaDataSource ID="SiteAreaDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SiteAreaProperty Name="Area"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SiteAreaDataSource>
	    		
</asp:Content>



