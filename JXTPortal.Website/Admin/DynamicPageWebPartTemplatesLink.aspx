<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="DynamicPageWebPartTemplatesLink" Title="DynamicPageWebPartTemplatesLink List" Codebehind="DynamicPageWebPartTemplatesLink.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dynamic Page Web Part Templates Link List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DynamicPageWebPartTemplatesLinkDataSource"
				DataKeyNames="DynamicPageWebPartTemplatesLinkId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DynamicPageWebPartTemplatesLink.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" ShowDeleteButton="false" />	
				<asp:CommandField ShowSelectButton="false" ShowEditButton="False" ShowDeleteButton="true" />	
                <data:HyperLinkField HeaderText="Dynamic Page Web Part Template Id" DataNavigateUrlFormatString="DynamicPageWebPartTemplatesEdit.aspx?DynamicPageWebPartTemplateId={0}" DataNavigateUrlFields="DynamicPageWebPartTemplateId" DataContainer="DynamicPageWebPartTemplateIdSource" DataTextField="DynamicPageWebPartName" />
				<asp:BoundField DataField="SiteWebPartID" HeaderText="Site Web Part ID" SortExpression="[SiteWebPartID]"  />
				<asp:BoundField DataField="Sequence" HeaderText="Sequence" SortExpression="[Sequence]"  />
				<%--<data:HyperLinkField HeaderText="Site Web Part Id" DataNavigateUrlFormatString="SiteWebPartsEdit.aspx?SiteWebPartId={0}" DataNavigateUrlFields="SiteWebPartId" DataContainer="SiteWebPartIdSource" DataTextField="SiteWebPartHtml" />--%>

			</Columns>
			<EmptyDataTemplate>
				<b>No DynamicPageWebPartTemplatesLink Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDynamicPageWebPartTemplatesLink" OnClientClick="javascript:location.href='DynamicPageWebPartTemplatesLinkEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DynamicPageWebPartTemplatesLinkDataSource ID="DynamicPageWebPartTemplatesLinkDataSource" runat="server"
			SelectMethod="GetBySiteId"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
	            
                    <data:DynamicPageWebPartTemplatesLinkProperty Name="DynamicPageWebPartTemplates"/> 
					<%--<data:DynamicPageWebPartTemplatesLinkProperty Name="SiteWebParts"/> --%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DynamicPageWebPartTemplatesLinkDataSource>
	    		
</asp:Content>



