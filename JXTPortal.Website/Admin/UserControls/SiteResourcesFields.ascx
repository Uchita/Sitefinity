﻿<%@ Control Language="C#" ClassName="SiteResourcesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataResourceCode" runat="server" Text="Resource Code:" AssociatedControlID="dataResourceCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataResourceCode" DataSourceID="ResourceCodeDefaultResourcesDataSource" DataTextField="ResourceCode" DataValueField="ResourceCode" SelectedValue='<%# Bind("ResourceCode") %>' AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
					<data:DefaultResourcesDataSource ID="ResourceCodeDefaultResourcesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataResourceText" runat="server" Text="Resource Text:" AssociatedControlID="dataResourceText" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataResourceText" Text='<%# Bind("ResourceText") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


