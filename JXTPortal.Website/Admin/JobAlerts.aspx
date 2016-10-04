
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="JobAlerts" Title="JobAlerts List" Codebehind="JobAlerts.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Job Alerts List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="JobAlertsDataSource"
				DataKeyNames="JobAlertId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_JobAlerts.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="JobAlertName" HeaderText="Job Alert Name" SortExpression="[JobAlertName]"  />
				<asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
				<asp:BoundField DataField="SearchKeywords" HeaderText="Search Keywords" SortExpression="[SearchKeywords]"  />
				<asp:BoundField DataField="RecurrenceType" HeaderText="Recurrence Type" SortExpression="[RecurrenceType]"  />
				<asp:BoundField DataField="DailyFrequency" HeaderText="Daily Frequency" SortExpression="[DailyFrequency]"  />
				<asp:BoundField DataField="WeeklyFrequency" HeaderText="Weekly Frequency" SortExpression="[WeeklyFrequency]"  />
				<asp:BoundField DataField="WeeklyDayOccurence" HeaderText="Weekly Day Occurence" SortExpression="[WeeklyDayOccurence]"  />
				<asp:BoundField DataField="DateLastRun" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Last Run" SortExpression="[DateLastRun]"  />
				<asp:BoundField DataField="DateNextRun" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Next Run" SortExpression="[DateNextRun]"  />
				<data:HyperLinkField HeaderText="Member Id" DataNavigateUrlFormatString="MembersEdit.aspx?MemberId={0}" DataNavigateUrlFields="MemberId" DataContainer="MemberIdSource" DataTextField="Username" />
				<data:BoundRadioButtonField DataField="AlertActive" HeaderText="Alert Active" SortExpression="[AlertActive]"  />
				<asp:BoundField DataField="EmailFormat" HeaderText="Email Format" SortExpression="[EmailFormat]"  />
				<asp:BoundField DataField="CustomRecurrenceType" HeaderText="Custom Recurrence Type" SortExpression="[CustomRecurrenceType]"  />
				<asp:BoundField DataField="LastResultCount" HeaderText="Last Result Count" SortExpression="[LastResultCount]"  />
				<data:BoundRadioButtonField DataField="PrimaryAlert" HeaderText="Primary Alert" SortExpression="[PrimaryAlert]"  />
				<asp:BoundField DataField="UnsubscribeValidateId" HeaderText="Unsubscribe Validate Id" SortExpression="[UnsubscribeValidateID]"  />
				<asp:BoundField DataField="EditValidateId" HeaderText="Edit Validate Id" SortExpression="[EditValidateID]"  />
				<asp:BoundField DataField="ViewValidateId" HeaderText="View Validate Id" SortExpression="[ViewValidateID]"  />
				<data:HyperLinkField HeaderText="Site Id" DataNavigateUrlFormatString="SitesEdit.aspx?SiteId={0}" DataNavigateUrlFields="SiteId" DataContainer="SiteIdSource" DataTextField="SiteName" />
				<data:HyperLinkField HeaderText="Country Id" DataNavigateUrlFormatString="CountriesEdit.aspx?CountryId={0}" DataNavigateUrlFields="CountryId" DataContainer="CountryIdSource" DataTextField="CountryName" />
				<data:HyperLinkField HeaderText="Location Id" DataNavigateUrlFormatString="LocationEdit.aspx?LocationId={0}" DataNavigateUrlFields="LocationId" DataContainer="LocationIdSource" DataTextField="LocationName" />
				<asp:BoundField DataField="AreaIds" HeaderText="Area Ids" SortExpression="[AreaIDs]"  />
				<data:HyperLinkField HeaderText="Profession Id" DataNavigateUrlFormatString="ProfessionEdit.aspx?ProfessionId={0}" DataNavigateUrlFields="ProfessionId" DataContainer="ProfessionIdSource" DataTextField="ProfessionName" />
				<asp:BoundField DataField="SearchRoleIds" HeaderText="Search Role Ids" SortExpression="[SearchRoleIDs]"  />
				<asp:BoundField DataField="WorkTypeIds" HeaderText="Work Type Ids" SortExpression="[WorkTypeIDs]"  />
				<asp:BoundField DataField="SalaryIds" HeaderText="Salary Ids" SortExpression="[SalaryIDs]"  />
				<asp:BoundField DataField="DaysPosted" HeaderText="Days Posted" SortExpression="[DaysPosted]"  />
				<asp:BoundField DataField="GeneratedSql" HeaderText="Generated Sql" SortExpression="[GeneratedSQL]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No JobAlerts Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnJobAlerts" OnClientClick="javascript:location.href='JobAlertsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:JobAlertsDataSource ID="JobAlertsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobAlertsProperty Name="Countries"/> 
					<data:JobAlertsProperty Name="Location"/> 
					<data:JobAlertsProperty Name="Members"/> 
					<data:JobAlertsProperty Name="Profession"/> 
					<data:JobAlertsProperty Name="Sites"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:JobAlertsDataSource>
	    		
</asp:Content>



