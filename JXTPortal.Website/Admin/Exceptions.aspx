<%@ Page Title="Exception Lists" Theme="Default" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="Exceptions.aspx.cs" Inherits="JXTPortal.Website.Admin.Exceptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Exceptions
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<br />
		
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				DataSourceID="ExceptionTableDataSource"
				DataKeyNames="ExceptionId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="DateEntered" 
				DefaultSortDirection="Descending"	
				ExcelExportFileName="Export_Exception.xls"  
				AlternatingRowStyle-CssClass="grid-alt-row"				 		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="False" ShowEditButton="False" />				
				<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HyperLink ID="actionlink" Text="View" runat="server" NavigateUrl='<%# "ExceptionView.aspx?ExceptionId=" + DataBinder.Eval(Container.DataItem, "ExceptionId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:BoundField DataField="DateEntered" HeaderText="Date Entered" SortExpression="[DateEntered]"  />
				<asp:BoundField DataField="ExceptionApplicationSource" HeaderText="Source" SortExpression="[ExceptionApplicationSource]"  />
				<asp:BoundField DataField="HostIPAddress" HeaderText="Host IP" SortExpression="[HostIPAddress]"  />
				<asp:BoundField DataField="ExceptionUrl" HeaderText="Exception Url" SortExpression="[ExceptionUrl]"  />
				<asp:BoundField DataField="ExceptionMessage" HeaderText="Exception Message" SortExpression="[ExceptionMessage]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Exceptions Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>

		
		<data:ExceptionTableDataSource ID="ExceptionTableDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ExceptionTableDataSource>
		
</asp:Content>
