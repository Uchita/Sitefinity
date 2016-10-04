
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="AdvertiserAccountType" Title="Advertisers - Advertiser Account Type" Codebehind="AdvertiserAccountType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Advertiser Account Type List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdvertiserAccountTypeDataSource"
				DataKeyNames="AdvertiserAccountTypeId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdvertiserAccountType.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="AdvertiserAccountTypeName" HeaderText="Advertiser Account Type Name" SortExpression="[AdvertiserAccountTypeName]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdvertiserAccountType Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdvertiserAccountType" OnClientClick="javascript:location.href='AdvertiserAccountTypeEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdvertiserAccountTypeDataSource ID="AdvertiserAccountTypeDataSource" runat="server"
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
		</data:AdvertiserAccountTypeDataSource>
	    		
</asp:Content>



