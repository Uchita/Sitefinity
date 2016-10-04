<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Enquiries" Title="Sites - Enquiries List" CodeBehind="Enquiries.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Enquiries List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="EnquiriesDataSource" DataKeyNames="EnquiryId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_Enquiries.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />
            <asp:BoundField DataField="ContactPhone" HeaderText="Contact Phone" SortExpression="[ContactPhone]" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="[Date]" />
            <asp:BoundField DataField="IpAddress" HeaderText="IpAddress" SortExpression="[IpAddress]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Enquiries Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <%--<asp:Button runat="server" ID="btnEnquiries" OnClientClick="javascript:location.href='EnquiriesEdit.aspx'; return false;"
        Text="Add New"></asp:Button>--%>
    <data:EnquiriesDataSource ID="EnquiriesDataSource" runat="server" SelectMethod="GetBySiteId"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:EnquiriesProperty Name="Sites" />
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
    </data:EnquiriesDataSource>
</asp:Content>
