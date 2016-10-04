<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="JobItemsType" Title="JobItemsType List" CodeBehind="JobItemsType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Job Items Type List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="JobItemsTypeDataSource" DataKeyNames="JobItemTypeId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_JobItemsType.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="JobItemTypeParentId" HeaderText="Job Item Type Parent Id"
                SortExpression="[JobItemTypeParentID]" />
            <asp:BoundField DataField="JobItemTypeDescription" HeaderText="Job Item Type Description"
                SortExpression="[JobItemTypeDescription]" />
            <data:BoundRadioButtonField DataField="GlobalTemplate" HeaderText="Global Template"
                SortExpression="[GlobalTemplate]" />
            <asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False"
                HeaderText="Last Modified" SortExpression="[LastModified]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No JobItemsType Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnJobItemsType" OnClientClick="javascript:location.href='JobItemsTypeEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <data:JobItemsTypeDataSource ID="JobItemsTypeDataSource" runat="server" SelectMethod="GetPaged"
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
    </data:JobItemsTypeDataSource>
</asp:Content>
