<%@ Control Language="C#" ClassName="JobsArchiveFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobName" runat="server" Text="Job Name:" AssociatedControlID="dataJobName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJobName" Text='<%# Bind("JobName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataJobName" runat="server" Display="Dynamic" ControlToValidate="dataJobName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDescription" runat="server" Display="Dynamic" ControlToValidate="dataDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFullDescription" runat="server" Text="Full Description:" AssociatedControlID="dataFullDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFullDescription" Text='<%# Bind("FullDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFullDescription" runat="server" Display="Dynamic" ControlToValidate="dataFullDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebServiceProcessed" runat="server" Text="Web Service Processed:" AssociatedControlID="dataWebServiceProcessed" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataWebServiceProcessed" SelectedValue='<%# Bind("WebServiceProcessed") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationEmailAddress" runat="server" Text="Application Email Address:" AssociatedControlID="dataApplicationEmailAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataApplicationEmailAddress" Text='<%# Bind("ApplicationEmailAddress") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataApplicationEmailAddress" runat="server" Display="Dynamic" ControlToValidate="dataApplicationEmailAddress" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRefNo" runat="server" Text="Ref No:" AssociatedControlID="dataRefNo" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRefNo" Text='<%# Bind("RefNo") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVisible" runat="server" Text="Visible:" AssociatedControlID="dataVisible" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataVisible" SelectedValue='<%# Bind("Visible") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDatePosted" runat="server" Text="Date Posted:" AssociatedControlID="dataDatePosted" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDatePosted" Text='<%# Bind("DatePosted", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDatePosted" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDatePosted" runat="server" Display="Dynamic" ControlToValidate="dataDatePosted" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpiryDate" runat="server" Text="Expiry Date:" AssociatedControlID="dataExpiryDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExpiryDate" Text='<%# Bind("ExpiryDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataExpiryDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataExpiryDate" runat="server" Display="Dynamic" ControlToValidate="dataExpiryDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpired" runat="server" Text="Expired:" AssociatedControlID="dataExpired" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataExpired" SelectedValue='<%# Bind("Expired") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobItemPrice" runat="server" Text="Job Item Price:" AssociatedControlID="dataJobItemPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJobItemPrice" Text='<%# Bind("JobItemPrice") %>'></asp:TextBox><asp:RegularExpressionValidator ID="RegExVal_dataJobItemPrice"  runat="server" ControlToValidate="dataJobItemPrice" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBilled" runat="server" Text="Billed:" AssociatedControlID="dataBilled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataBilled" SelectedValue='<%# Bind("Billed") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowSalaryDetails" runat="server" Text="Show Salary Details:" AssociatedControlID="dataShowSalaryDetails" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowSalaryDetails" SelectedValue='<%# Bind("ShowSalaryDetails") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryText" runat="server" Text="Salary Text:" AssociatedControlID="dataSalaryText" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalaryText" Text='<%# Bind("SalaryText") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobItemTypeId" runat="server" Text="Job Item Type Id:" AssociatedControlID="dataJobItemTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataJobItemTypeId" DataSourceID="JobItemTypeIdJobItemsTypeDataSource" DataTextField="JobItemTypeParentId" DataValueField="JobItemTypeId" SelectedValue='<%# Bind("JobItemTypeId") %>' AppendNullItem="true" Required="false" NullItemText=" Please Choose ..." />
					<data:JobItemsTypeDataSource ID="JobItemTypeIdJobItemsTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationMethod" runat="server" Text="Application Method:" AssociatedControlID="dataApplicationMethod" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataApplicationMethod" Text='<%# Bind("ApplicationMethod") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataApplicationMethod" runat="server" Display="Dynamic" ControlToValidate="dataApplicationMethod" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationUrl" runat="server" Text="Application Url:" AssociatedControlID="dataApplicationUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataApplicationUrl" Text='<%# Bind("ApplicationUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUploadMethod" runat="server" Text="Upload Method:" AssociatedControlID="dataUploadMethod" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUploadMethod" Text='<%# Bind("UploadMethod") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUploadMethod" runat="server" Display="Dynamic" ControlToValidate="dataUploadMethod" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTags" runat="server" Text="Tags:" AssociatedControlID="dataTags" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTags" Text='<%# Bind("Tags") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSearchField" runat="server" Text="Search Field:" AssociatedControlID="dataSearchField" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataSearchField" Value='<%# Bind("SearchField") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSearchFieldExtension" runat="server" Text="Search Field Extension:" AssociatedControlID="dataSearchFieldExtension" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSearchFieldExtension" Text='<%# Bind("SearchFieldExtension") %>' MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSearchFieldExtension" runat="server" Display="Dynamic" ControlToValidate="dataSearchFieldExtension" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdvertiserJobTemplateLogoId" runat="server" Text="Advertiser Job Template Logo Id:" AssociatedControlID="dataAdvertiserJobTemplateLogoId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAdvertiserJobTemplateLogoId" Text='<%# Bind("AdvertiserJobTemplateLogoId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAdvertiserJobTemplateLogoId" runat="server" Display="Dynamic" ControlToValidate="dataAdvertiserJobTemplateLogoId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyName" runat="server" Text="Company Name:" AssociatedControlID="dataCompanyName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyName" Text='<%# Bind("CompanyName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHashValue" runat="server" Text="Hash Value:" AssociatedControlID="dataHashValue" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataHashValue" Value='<%# Bind("HashValue") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequireLogonForExternalApplications" runat="server" Text="Require Logon For External Applications:" AssociatedControlID="dataRequireLogonForExternalApplications" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataRequireLogonForExternalApplications" SelectedValue='<%# Bind("RequireLogonForExternalApplications") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowLocationDetails" runat="server" Text="Show Location Details:" AssociatedControlID="dataShowLocationDetails" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowLocationDetails" SelectedValue='<%# Bind("ShowLocationDetails") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublicTransport" runat="server" Text="Public Transport:" AssociatedControlID="dataPublicTransport" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPublicTransport" Text='<%# Bind("PublicTransport") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataContactDetails" runat="server" Text="Contact Details:" AssociatedControlID="dataContactDetails" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataContactDetails" Text='<%# Bind("ContactDetails") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataContactDetails" runat="server" Display="Dynamic" ControlToValidate="dataContactDetails" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobContactPhone" runat="server" Text="Job Contact Phone:" AssociatedControlID="dataJobContactPhone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJobContactPhone" Text='<%# Bind("JobContactPhone") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobContactName" runat="server" Text="Job Contact Name:" AssociatedControlID="dataJobContactName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJobContactName" Text='<%# Bind("JobContactName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQualificationsRecognised" runat="server" Text="Qualifications Recognised:" AssociatedControlID="dataQualificationsRecognised" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataQualificationsRecognised" SelectedValue='<%# Bind("QualificationsRecognised") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataResidentOnly" runat="server" Text="Resident Only:" AssociatedControlID="dataResidentOnly" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataResidentOnly" SelectedValue='<%# Bind("ResidentOnly") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDocumentLink" runat="server" Text="Document Link:" AssociatedControlID="dataDocumentLink" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDocumentLink" Text='<%# Bind("DocumentLink") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBulletPoint1" runat="server" Text="Bullet Point1:" AssociatedControlID="dataBulletPoint1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBulletPoint1" Text='<%# Bind("BulletPoint1") %>' MaxLength="160"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBulletPoint2" runat="server" Text="Bullet Point2:" AssociatedControlID="dataBulletPoint2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBulletPoint2" Text='<%# Bind("BulletPoint2") %>' MaxLength="160"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBulletPoint3" runat="server" Text="Bullet Point3:" AssociatedControlID="dataBulletPoint3" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBulletPoint3" Text='<%# Bind("BulletPoint3") %>' MaxLength="160"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHotJob" runat="server" Text="Hot Job:" AssociatedControlID="dataHotJob" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataHotJob" SelectedValue='<%# Bind("HotJob") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


