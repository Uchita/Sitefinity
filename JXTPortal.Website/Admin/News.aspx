<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="News" Title="News Category - News List" CodeBehind="News.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News List
    <a href='http://support.jxt.com.au/solution/articles/116441-news' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="NewsDataSource" DataKeyNames="NewsId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_News.xls">
        <Columns>
            <data:HyperLinkField DataNavigateUrlFormatString="/admin/NewsEdit.aspx?NewsId={0}" DataNavigateUrlFields="NewsId" 
                      DataTextField="NewsId" DataTextFormatString="Select"/>

            <asp:CommandField ShowSelectButton="false" ShowEditButton="false" ShowDeleteButton="true" />
            <data:HyperLinkField HeaderText="Preview" DataNavigateUrlFormatString="/news/{1}/{0}/" DataNavigateUrlFields="NewsId, PageFriendlyName" 
                      DataTextField="NewsId" DataTextFormatString="Preview"/>
            <data:HyperLinkField HeaderText="News Category" DataNavigateUrlFormatString="NewsCategoriesEdit.aspx?NewsCategoryId={0}"
                DataNavigateUrlFields="NewsCategoryId" DataContainer="NewsCategoryIdSource" DataTextField="NewsCategoryName" />
            <asp:BoundField DataField="Subject" HeaderText="Subject"  HtmlEncode="False" />
            <asp:BoundField DataField="PageFriendlyName" HeaderText="Friendly Name"  />
            <asp:BoundField DataField="PostDate" DataFormatString="{0:d}" HtmlEncode="False"
                HeaderText="Post Date"  />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid"  />
<%--            <asp:BoundField DataField="Sequence" HeaderText="Sequence" SortExpression="[Sequence]" />
--%>            <asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False"
                HeaderText="Last Modified"  />
        </Columns>
        <EmptyDataTemplate>
            <b>No News Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnNews" OnClientClick="javascript:location.href='NewsEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <data:NewsDataSource ID="NewsDataSource" runat="server" SelectMethod="GetBySiteId"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:NewsProperty Name="NewsCategories" />
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
    </data:NewsDataSource>
</asp:Content>
