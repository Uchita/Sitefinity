<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="subAccount.aspx.cs" Inherits="JXTPortal.Website.advertiser.subAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--<JXTControl:MemberAdvertiserNavigation ID="MemberAdvertiserNavigation1" runat="server" />--%>
<div id="content">
    <div class="content-holder">
        <div class="search-sequence">
            <div class="seq-box">
                <label>
                    Enter keywords</label>
                <p>
                    <input name="" type="text" class="seq-textbox" />
            </div>
            <div class="seq-arrow">
                >
            </div>
            <div class="seq-box">
                <label>
                    Classifications</label>
                <br />
                <select name="" size="4" class="seq-dropdown" multiple>
                    <option selected="selected" value="Recruiter">Recruiter </option>
                    <option value="Corporate">Corporate </option>
                    <option value="Charity">Charity </option>
                    <option value="NFP">NFP </option>
                    <option value="Government">Government </option>
                </select></p></div>
            <div class="seq-arrow">
                >
            </div>
            <div class="seq-box">
                <label>
                    Location</label>
                <br />
                <select name="" size="4" class="seq-dropdown" multiple>
                    <option selected="selected" value="Recruiter">Recruiter </option>
                    <option value="Corporate">Corporate </option>
                    <option value="Charity">Charity </option>
                    <option value="NFP">NFP </option>
                    <option value="Government">Government </option>
                </select></div>
            <div class="seq-arrow">
                >
            </div>
            <div class="seq-box">
                <label>
                    Salary</label>
                <br />
                <select name="" size="4" class="seq-dropdown" multiple>
                    <option selected="selected" value="Recruiter">Recruiter </option>
                    <option value="Corporate">Corporate </option>
                    <option value="Charity">Charity </option>
                    <option value="NFP">NFP </option>
                    <option value="Government">Government </option>
                </select></div>
            <div class="seq-arrow">
                >
            </div>
            <div class="seq-arrow">
                <input name="" type="submit" class="seq-submit" /></div>
        </div>
        <p>
            <table id="box-table">
                <thead>
                    <tr>
                        <th scope="col">
                            Employee
                        </th>
                        <th scope="col">
                            Salary
                        </th>
                        <th scope="col">
                            Bonus
                        </th>
                        <th scope="col">
                            Supervisor
                        </th>
                        <th scope="col">
                            title 4
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            Stephen C. Cox
                        </td>
                        <td>
                            $300
                        </td>
                        <td>
                            <label>
                                <input type="checkbox" name="checkbox" id="checkbox" />
                            </label>
                        </td>
                        <td>
                            Bob
                        </td>
                        <td>
                            test
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Josephin Tan
                        </td>
                        <td>
                            $150
                        </td>
                        <td>
                            <label>
                                <input type="radio" name="radio" id="radio" value="radio" />
                            </label>
                        </td>
                        <td>
                            Annie
                        </td>
                        <td>
                            <label>
                                <select name="select" id="select">
                                    <option value="test 1">test 1</option>
                                    <option value="test2">test 2</option>
                                    <option value="test 3">test 3</option>
                                </select>
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Joyce Ming
                        </td>
                        <td>
                            $200
                        </td>
                        <td>
                            $35
                        </td>
                        <td>
                            Andy
                        </td>
                        <td>
                            <label>
                                <input type="text" name="textfield" id="textfield" />
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            James A. Pentel
                        </td>
                        <td>
                            $175
                        </td>
                        <td>
                            $25
                        </td>
                        <td>
                            Annie
                        </td>
                        <td>
                            <a href="#">test</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </p>
    </div>
    <!--end of content holder-->
        <data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"
				DataKeyNames="AdvertiserUserId"
				AllowMultiColumnSorting="False"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdvertiserUsers.xls"
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]"  />
				<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[FirstName]"  />
				<asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="[Surname]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:TemplateField HeaderText="Newsletter" SortExpression="[Newsletter]">
				    <ItemTemplate>
				        <asp:Label ID="lbNewsletter" runat="server" Text='<%# Eval("Newsletter") %>'></asp:Label>
				    </ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Validated" SortExpression="[Validated]">
				    <ItemTemplate>
				        <asp:Label ID="lbValidated" runat="server" Text='<%# Eval("Validated") %>'></asp:Label>
				    </ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="LastModified" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdvertiserUsers Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdvertiserUsers" OnClientClick="javascript:location.href='/advertiser/register.aspx?action=add'; return false;" Text="Add New" CssClass="mini-new-buttons"></asp:Button>
		<data:AdvertiserUsersDataSource ID="AdvertiserUsersDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AdvertiserUsersProperty Name="Advertisers"/> 
					<data:AdvertiserUsersProperty Name="EmailFormats"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AdvertiserUsersDataSource>
</asp:Content>
