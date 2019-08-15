<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" %>

<h2>
    <asp:Literal runat="server" ID="lGeneralSettings" Text="Salary Survey Settings" />
</h2>

<sitefinity:TextField
    Title="Currency Symbol"
    ID="currencySymbol"
    DataFieldName="CurrencySymbol"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Superannuation Rate"
    ID="superannuationRate"
    DataFieldName="SuperannuationRate"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Medicare Rate"
    ID="medicareRate"
    DataFieldName="MedicareRate"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Work Hours Per Week"
    ID="weeklyHours"
    DataFieldName="WeeklyHours"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Tax Brackets"
    ID="taxBrackets"
    Description="Data in [upper-amount,rate] format separated by '|'"
    DataFieldName="TaxBrackets"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<h2>Taxonomies</h2>

<sitefinity:HierarchicalTaxonField
    Title="Country"
    ID="countryTaxonomyId"
    DataFieldName="CountryTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Industry"
    ID="industryTaxonomyId"
    DataFieldName="IndustryTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Job Type"
    ID="jobTypeTaxonomyId"
    DataFieldName="JobTypeTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Annual Salary Job Types"
    ID="annualSalaryJobTypeTaxonomyIds"
    DataFieldName="AnnualSalaryJobTypeTaxonomyIds"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="true"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Years of Experience"
    ID="yearsOfExperienceTaxonomyId"
    DataFieldName="YearsOfExperienceTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Sector"
    ID="sectorTaxonomyId"
    DataFieldName="SectorTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Employer Size"
    ID="employerSizeTaxonomyId"
    DataFieldName="EmployerSizeTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="People Managed"
    ID="peopleManagedTaxonomyId"
    DataFieldName="PeopleManagedTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Education"
    ID="educationTaxonomyId"
    DataFieldName="EducationTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Benefits"
    ID="benefitTaxonomyId"
    DataFieldName="BenefitTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Gender"
    ID="genderTaxonomyId"
    DataFieldName="GenderTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Motivators"
    ID="motivatorTaxonomyId"
    DataFieldName="MotivatorTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Career Moves"
    ID="careerMoveTaxonomyId"
    DataFieldName="CareerMoveTaxonomyId"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    AllowMultipleSelection="false"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Annual Salaries"
    ID="annualSalariesTaxonomyId"
    DataFieldName="AnnualSalariesTaxonomyId"
    Description="Leave unselected to use free text."
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Hourly Rates"
    ID="hourlyRatesTaxonomyId"
    DataFieldName="HourlyRatesTaxonomyId"
    Description="Leave unselected to use free text."
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<sitefinity:HierarchicalTaxonField
    Title="Bonus Amounts"
    ID="bonusAmountsTaxonomyId"
    DataFieldName="BonusAmountsTaxonomyId"
    Description="Leave unselected to use free text."
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write"
    WebServiceUrl="~/Sitefinity/Services/Taxonomies/HierarchicalTaxon.svc"
    TaxonomyId="E5CD6D69-1543-427b-AD62-688A99F5E7D4"
    ShowDoneSelectingButton="true"
    TaxonomyMetafieldName="Category" />

<h2>Salary Alert</h2>

<sitefinity:TextField
    Title="Salary Count"
    ID="salaryAlertCount"
    DataFieldName="SalaryAlertCount"
    Description="Number of salaries to match to send an alert. Default is 10."
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Email Template GUID"
    ID="salaryAlertEmailTemplateId"
    DataFieldName="SalaryAlertEmailTemplateId"
    Description="Must be set for salary alert to work."
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Email From Name"
    ID="salaryAlertEmailFromName"
    DataFieldName="SalaryAlertEmailFromName"
    Description=""
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />
	
<sitefinity:TextField
    Title="Email From Address"
    ID="salaryAlertEmailFromAddress"
    DataFieldName="SalaryAlertEmailFromAddress"
    Description=""
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Salary Item Template"
    ID="salaryAlertSalaryItemTemplate"
    DataFieldName="SalaryAlertSalaryItemTemplate"
    Description="Must be set for salary alert to work."
    Rows="5"
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />

<sitefinity:TextField
    Title="Task Server IP"
    ID="salaryAlertTaskServerIp"
    DataFieldName="SalaryAlertTaskServerIp"
    Description="Must be set for salary alert to work."
    CssClass="sfSettingsSection"
    runat="server"
    DisplayMode="Write" />
