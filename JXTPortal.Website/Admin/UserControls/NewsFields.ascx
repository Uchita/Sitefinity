<%@ Control Language="C#" ClassName="NewsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewsCategoryId" runat="server" Text="News Category Id:" AssociatedControlID="dataNewsCategoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataNewsCategoryId" DataSourceID="NewsCategoryIdNewsCategoriesDataSource" DataTextField="NewsCategoryName" DataValueField="NewsCategoryId" SelectedValue='<%# Bind("NewsCategoryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:NewsCategoriesDataSource ID="NewsCategoryIdNewsCategoriesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSubject" runat="server" Text="Subject:" AssociatedControlID="dataSubject" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSubject" Text='<%# Bind("Subject") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSubject" runat="server" Display="Dynamic" ControlToValidate="dataSubject" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataContent" runat="server" Text="Content:" AssociatedControlID="dataContent" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataContent" Text='<%# Bind("Content") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostDate" runat="server" Text="Post Date:" AssociatedControlID="dataPostDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostDate" Text='<%# Bind("PostDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPostDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataPostDate" runat="server" Display="Dynamic" ControlToValidate="dataPostDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSequence" runat="server" Text="Sequence:" AssociatedControlID="dataSequence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSequence" Text='<%# Bind("Sequence") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSearchField" runat="server" Text="Search Field:" AssociatedControlID="dataSearchField" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataSearchField" Value='<%# Bind("SearchField") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTags" runat="server" Text="Tags:" AssociatedControlID="dataTags" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTags" Text='<%# Bind("Tags") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaTitle" runat="server" Text="Meta Title:" AssociatedControlID="dataMetaTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaTitle" Text='<%# Bind("MetaTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaKeywords" runat="server" Text="Meta Keywords:" AssociatedControlID="dataMetaKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaKeywords" Text='<%# Bind("MetaKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaDescription" runat="server" Text="Meta Description:" AssociatedControlID="dataMetaDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaDescription" Text='<%# Bind("MetaDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


