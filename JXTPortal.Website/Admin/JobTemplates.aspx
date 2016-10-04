<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="JobTemplates" Title="Sites - Site Job Templates"
    CodeBehind="JobTemplates.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Job Templates List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="JobTemplatesDataSource" DataKeyNames="JobTemplateId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_JobTemplates.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="false" />
            <asp:BoundField DataField="JobTemplateID" HeaderText="Job Template ID"
                SortExpression="[JobTemplateID]" />
            <asp:BoundField DataField="JobTemplateDescription" HeaderText="Job Template Description"
                SortExpression="[JobTemplateDescription]" />
            <asp:BoundField DataField="GlobalTemplate" HeaderText="Global Template" SortExpression="[GlobalTemplate]" />
            <asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False"
                HeaderText="Last Modified" SortExpression="[LastModified]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No JobTemplates Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnJobTemplates" OnClientClick="javascript:location.href='JobTemplatesEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <data:JobTemplatesDataSource ID="JobTemplatesDataSource" runat="server" SelectMethod="GetBySiteId"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="False">
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
    </data:JobTemplatesDataSource>
</asp:Content>
