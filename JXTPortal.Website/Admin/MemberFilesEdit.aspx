<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="MemberFilesEdit" Title="Members - Member Files Edit"
    CodeBehind="MemberFilesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Member Files - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line" id="admin-memberFiles-memberID">
                <label class="form-label-left">
                    Member ID:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="lblMemberID" />
                </div>
            </li>
            <li class="form-line" id="admin-memberFiles-memberName">
                <label class="form-label-left">
                    Member Name:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="lblmemberName" />
                </div>
            </li>
            <li class="form-line" id="admin-memberFiles-memberFileTypeName">
                <label class="form-label-left">
                    Member File Type Name:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="lblMemberFileTypeName" />
                </div>
            </li>
            <li class="form-line" id="admin-memberFiles-memberFileName">
                <label class="form-label-left">
                    Member File Name:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtMemberFileName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataMemberFileName" runat="server" Display="Dynamic"
                        ControlToValidate="txtMemberFileName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="admin-memberFiles-memberFileTitle">
                <label class="form-label-left">
                    Member File Title:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtMemberFileTitle"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataMemberFileTitle" runat="server" Display="Dynamic"
                        ControlToValidate="txtMemberFileTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="admin-memberFiles-lastModifiedDate">
                <label class="form-label-left">
                    Last Modified Date:</label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblModifiedDate" />
                    </div>
                </div>
            </li>
            <br />
            <br />
            <li class="form-line" id="admin-memberFiles-dowloadFile">
                <div class="form-input">
                    <label>
                        &nbsp;Click <a href='/download.aspx?type=mf&id=<%=Request.QueryString["MemberFileId"] %>'>
                            here</a> to download the file</label>
                </div>
            </li>
            <li class="form-line" id="admin-memberFiles-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Update" OnClick="btnSubmit_Click"
                            CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
