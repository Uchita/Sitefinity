<%@ Control Language="C#" ClassName="JobTemplatesFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataJobTemplateParentId" runat="server" Text="Job Template Parent Id:"
                        AssociatedControlID="dataJobTemplateParentId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataJobTemplateParentId" Text='<%# Bind("JobTemplateParentId") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataJobTemplateParentId" runat="server" Display="Dynamic" ControlToValidate="dataJobTemplateParentId"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataJobTemplateParentId"
                            runat="server" Display="Dynamic" ControlToValidate="dataJobTemplateParentId"
                            ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                            Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataJobTemplateDescription" runat="server" Text="Job Template Description:"
                        AssociatedControlID="dataJobTemplateDescription" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataJobTemplateDescription" Text='<%# Bind("JobTemplateDescription") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_dataJobTemplateDescription" runat="server" Display="Dynamic" ControlToValidate="dataJobTemplateDescription"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="Label1" runat="server" Text="Job Token:" AssociatedControlID="dataJobToken" />
                </td>
                <td>
                    <asp:ListBox ID="lstJobToken" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataJobTemplateHtml" runat="server" Text="Job Template Html:" AssociatedControlID="dataJobTemplateHtml" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataJobTemplateHtml" Text='<%# Bind("JobTemplateHtml") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataGlobalTemplate" runat="server" Text="Global Template:" AssociatedControlID="dataGlobalTemplate" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataGlobalTemplate" SelectedValue='<%# Bind("GlobalTemplate") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator
                                ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
