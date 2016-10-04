<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="NewsCategories" Title="News Categories" CodeBehind="NewsCategories.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News Categories List
    <a href='http://support.jxt.com.au/solution/articles/116440-news-categories-' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="NewsCategoriesDataSource" DataKeyNames="NewsCategoryId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_NewsCategories.xls">
        <Columns>
            <data:HyperLinkField DataNavigateUrlFormatString="/admin/NewsCategoriesEdit.aspx?NewsCategoryId={0}" DataNavigateUrlFields="NewsCategoryId" 
                      DataTextField="NewsCategoryId" DataTextFormatString="Select"/>
            <asp:BoundField DataField="NewsCategoryName" HeaderText="News Category Name" SortExpression="[NewsCategoryName]" />
            <asp:BoundField DataField="PageFriendlyName" HeaderText="Friendly Name" SortExpression="[PageFriendlyName]" />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
            <asp:BoundField DataField="Sequence" HeaderText="Sequence" SortExpression="[Sequence]" />
            <asp:BoundField DataField="LastModified" HtmlEncode="False" HeaderText="Last Modified"
                SortExpression="[LastModified]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No NewsCategories Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnNewsCategories" OnClientClick="javascript:location.href='NewsCategoriesEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <data:NewsCategoriesDataSource ID="NewsCategoriesDataSource" runat="server" SelectMethod="GetBySiteId"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex"
                Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize"
                Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:NewsCategoriesDataSource>
</asp:Content>
