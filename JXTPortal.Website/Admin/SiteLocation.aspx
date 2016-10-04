
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteLocation" Title="SiteLocation List" Codebehind="SiteLocation.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Location List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SiteLocationDataSource"
				DataKeyNames="SiteLocationId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SiteLocation.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Location Id" DataNavigateUrlFormatString="LocationEdit.aspx?LocationId={0}" DataNavigateUrlFields="LocationId" DataContainer="LocationIdSource" DataTextField="LocationName" />

				<asp:BoundField DataField="SiteLocationName" HeaderText="Site Location Name" SortExpression="[SiteLocationName]"  />
				<data:BoundRadioButtonField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SiteLocation Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSiteLocation" OnClientClick="javascript:location.href='SiteLocationEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SiteLocationDataSource ID="SiteLocationDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SiteLocationProperty Name="Location"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SiteLocationDataSource>
	    		
</asp:Content>



