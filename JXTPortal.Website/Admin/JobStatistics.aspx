
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  Title="Job Statistics" Codebehind="JobStatistics.aspx.cs" Inherits="JXTPortal.Website.Admin.JobStatistics"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Views Statistic</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release" ></ajaxToolkit:ToolkitScriptManager>
        <table>
		    <tr>
		        <td>Date From</td>
		        <td>
		            <asp:TextBox ID="txtDateFrom" runat="server" />
		            <ajaxToolkit:CalendarExtender ID="ceDateFrom" runat="server" TargetControlID="txtDateFrom"></ajaxToolkit:CalendarExtender>
		        </td>
		    </tr>
		     <tr>
		        <td>Date To</td>
		        <td>
		            <asp:TextBox ID="txtDateTo" runat="server" />
		            <ajaxToolkit:CalendarExtender ID="ceDateTo" runat="server" TargetControlID="txtDateTo"></ajaxToolkit:CalendarExtender>
		        </td>
		    </tr>
		    <tr>
		        <td colspan="2" align="right"><asp:Button ID="btnGenerate" runat="server" Text="Generate" onclick="btnGenerate_Click" CssClass="jxtadminbutton" /></td>
		    </tr>
		</table>
		<asp:DataGrid ID="dgJobStatistic" runat="server" AutoGenerateColumns="true" />
	    		
</asp:Content>



