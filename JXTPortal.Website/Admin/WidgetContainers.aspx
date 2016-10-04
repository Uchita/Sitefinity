<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="WidgetContainers" Title="Sites - Advanced Search Widgets" Codebehind="WidgetContainers.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Widget Containers List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="WidgetContainersDataSource"
				DataKeyNames="WidgetId"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_WidgetContainers.xls" ondatabound="GridView1_DataBound"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="false" ShowDeleteButton="false" />				
				<asp:CommandField ShowSelectButton="false" ShowEditButton="false" ShowDeleteButton="true" />				
                <asp:BoundField DataField="WidgetID" HeaderText="Widget ID" SortExpression="[WidgetID]"  />
				<asp:BoundField DataField="WidgetName" HeaderText="Widget Name" SortExpression="[WidgetName]"  />
				<asp:BoundField DataField="WidgetDomain" HeaderText="Widget Domain" SortExpression="[WidgetDomain]"  />
				<asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]"  />
				<%--<asp:CheckBoxField DataField="ShowJobs" HeaderText="Show Jobs" SortExpression="[ShowJobs]"  />
				<asp:CheckBoxField DataField="ShowCompanies" HeaderText="Show Companies" SortExpression="[ShowCompanies]"  />
				<asp:CheckBoxField DataField="ShowSite" HeaderText="Show Site" SortExpression="[ShowSite]"  />
				<asp:CheckBoxField DataField="ShowPeople" HeaderText="Show People" SortExpression="[ShowPeople]"  />--%>
				<asp:CheckBoxField DataField="OnAdvancedSearch" HeaderText="On Advanced Search" SortExpression="[OnAdvancedSearch]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No WidgetContainers Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnWidgetContainers" OnClientClick="javascript:location.href='WidgetContainersEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:WidgetContainersDataSource ID="WidgetContainersDataSource" runat="server"
			SelectMethod="GetBySiteId"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="false"
			>
			
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:WidgetContainersDataSource>
<br />
<h3>iFrame HTML</h3>	    		
&lt;iframe width="###px" height="###px" frameborder="0" src="#########" class="widgetIframeSearch" allowtransparency="true" scrolling="no" >&lt;p>Your browser does not support iframes.&lt;/p>&lt;/iframe>

<h3>Job Search iFrame HTML</h3>	    
Example - /job/widgetsearch.aspx?widgetid=6

<h3>Site Search iFrame HTML</h3>	    
Example - /widgets/widgetsitesearch.aspx?widgetid=55


<h3>Dynamic Widgets</h3>
Include <b>//images.jxt.net.au/COMMON/js/JXTWidget.js</b> file in the header if you want to include Dynamic Widgets.<br />

Example - {widget-<b>123</b>} <br />
where 123 is the widget ID. <br />
<br />
In the Widget the search function the submit button should be <b>WidgetJobSearch();</b><br />

For example - &lt;a href="#" id="search-link" onclick="WidgetJobSearch();">Job Search&lt;/a>

</asp:Content>



