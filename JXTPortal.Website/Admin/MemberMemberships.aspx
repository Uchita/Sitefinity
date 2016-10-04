
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="True" Inherits="MemberMemberships" Title="MemberMemberships List" Codebehind="MemberMemberships.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Membership List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<%--<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />--%>
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="MemberMembershipsDataSource"
				DataKeyNames="MemberMembershipsId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_MemberMemberships.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				
				<asp:BoundField DataField="MemberMembershipsName" HeaderText="Membership Name" SortExpression="[MemberMembershipsName]"  />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
				<asp:BoundField DataField="LastModified" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
				<asp:BoundField DataField="Sequence" HeaderText="Sequence" SortExpression="[Sequence]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No MemberMemberships Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnMemberMemberships" OnClientClick="javascript:location.href='MemberMembershipsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:MemberMembershipsDataSource ID="MemberMembershipsDataSource" runat="server"
			SelectMethod="GetBySiteId"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="False"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:MemberMembershipsProperty Name="AdminUsers"/> 
					<data:MemberMembershipsProperty Name="Sites"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:MemberMembershipsDataSource>
	    		
</asp:Content>



