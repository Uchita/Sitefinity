
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="MemberStatus" Title="MemberStatus List" Codebehind="MemberStatus.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Member Status List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<%--<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />--%>
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="MemberStatusDataSource"
				DataKeyNames="MemberStatusId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_MemberStatus.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				
				<asp:BoundField DataField="MemberStatusName" HeaderText="Member Status Name" SortExpression="[MemberStatusName]"  />				
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
                <asp:BoundField DataField="LastModified" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
				<asp:BoundField DataField="Sequence" HeaderText="Sequence" SortExpression="[Sequence]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No MemberStatus Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnMemberStatus" OnClientClick="javascript:location.href='MemberStatusEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:MemberStatusDataSource ID="MemberStatusDataSource" runat="server"
			SelectMethod="GetBySiteId"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:MemberStatusProperty Name="AdminUsers"/> 
					<data:MemberStatusProperty Name="Sites"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:MemberStatusDataSource>
	    		
</asp:Content>



