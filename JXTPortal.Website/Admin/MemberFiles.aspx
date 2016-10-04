
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="MemberFiles" Title="Members - Member Files" Codebehind="MemberFiles.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Member Files List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="MemberFilesDataSource"
				DataKeyNames="MemberFileId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_MemberFiles.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				
				<%--<data:HyperLinkField HeaderText="Member Id" DataNavigateUrlFormatString="MembersEdit.aspx?MemberId={0}" DataNavigateUrlFields="MemberId" DataContainer="MemberIdSource" DataTextField="Username" />--%>
				<%--<data:HyperLinkField HeaderText="Member File Type Id" DataNavigateUrlFormatString="MemberFileTypesEdit.aspx?MemberFileTypeId={0}" DataNavigateUrlFields="MemberFileTypeId" DataContainer="MemberFileTypeIdSource" DataTextField="MemberFileTypeName" />--%>
				<asp:BoundField DataField="MemberFileName" HeaderText="Member File Name" SortExpression="[MemberFileName]"  />
				<asp:BoundField DataField="MemberFileTitle" HeaderText="Member File Title" SortExpression="[MemberFileTitle]"  />
				<asp:BoundField DataField="LastModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified Date" SortExpression="[LastModifiedDate]"  />
				
			</Columns>
			<EmptyDataTemplate>
				<b>No MemberFiles Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<%--<asp:Button runat="server" ID="btnMemberFiles" OnClientClick="javascript:location.href='MemberFilesEdit.aspx'; return false;" Text="Add New"></asp:Button>--%>
		<data:MemberFilesDataSource ID="MemberFilesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True">
			<%--<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:MemberFilesProperty Name="Members"/> 
					<data:MemberFilesProperty Name="MemberFileTypes"/> 
				</Types>
			</DeepLoadProperties>--%>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:MemberFilesDataSource>
	    		
</asp:Content>



