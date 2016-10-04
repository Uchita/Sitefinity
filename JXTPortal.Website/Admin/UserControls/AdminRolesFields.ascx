<%@ Control Language="C#" ClassName="AdminRolesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>


		<li class="form-line" id="reg-username-field">
            <label class="form-label-left">Role Name:<span class="form-required">*</span>
            </label>

            <div class="form-input">
            <asp:TextBox runat="server" ID="dataRoleName" Text='<%# Bind("RoleName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRoleName" runat="server" Display="Dynamic" ControlToValidate="dataRoleName" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>

        </li><!--end of reg username field-->


	</ItemTemplate>
</asp:FormView>


