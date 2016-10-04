<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="FilesEdit" Title="File Management - Files Edit"
    CodeBehind="FilesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Files - Add/Edit (only Javascript / CSS) </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
            
        <ul class="form-section">
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Select Folder:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:ListBox ID="lstBoxFolders" runat="server" Rows="10" Width="250px" SelectionMode="Single"
                        AutoPostBack="true" />
                </div>
            </li>
        </ul>
        
        <asp:MultiView ID="MultiViewFileEdit" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewUploadFiles" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="reg-password-field">
                        <label class="form-label-left">
                            Files:
                        </label>
                        <div class="form-input">
                            
                            <asp:RequiredFieldValidator ID="ReqVal_lstBoxFolders" runat="server" Display="Dynamic"
                                ControlToValidate="lstBoxFolders" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:GridView ID="gridViewFiles" runat="server" AutoGenerateColumns="false" AllowMultiColumnSorting="false"
                                DefaultSortColumnName="" DefaultSortDirection="Ascending" GridLines="None" CssClass="grid"
                                AlternatingRowStyle-CssClass="grid-alt-row" OnRowDeleting="gridViewFiles_RowDeleting">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href='FilesEdit.aspx?FileId=<%# Eval("FileID") %>'>Edit</a></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDeleteFile" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                                CommandName="Delete" CommandArgument='<%# Eval("FileID") %>' CausesValidation="false">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" HeaderText="File ID" DataField="FileID" SortExpression="FileID" />
                                    <asp:BoundField ReadOnly="true" HeaderText="File Info" DataField="FileName" SortExpression="FileName" />
                                    <asp:BoundField ReadOnly="true" HeaderText="File Path" DataField="FileSystemName" SortExpression="FileSystemName" />
                                    <asp:BoundField HeaderText="Last Modified" DataField="LastModified" SortExpression="LastModified" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </li>
                    
                </ul>
                Select Folder below and <input type="submit" value="Add New File" onclick="javascript:location.href='FilesEdit.aspx?add=true'; return false;">
                
            </asp:View>
            <asp:View ID="ViewEditFile" runat="server">
                <ul class="form-section">
                    <li class="form-line">
                        <label class="form-label-left">
                            File Info:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtFileName" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqVal_FileName" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtFileName" />
                        </div>
                    </li>                    
                    <li class="form-line">
                        <label class="form-label-left">
                            Folder Name:
                        </label>
                        <div class="form-input">
                            <asp:Literal ID="ltlFolderName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            File Full Path:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtSystemName" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqVal_SystemName" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtSystemName" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            File Type:
                        </label>
                        <div class="form-input">
                            <asp:Literal ID="ltlFileType" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Last Modified:
                        </label>
                        <div class="form-input">
                            <asp:Literal ID="ltlLastModified" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Last Modified By:
                        </label>
                        <div class="form-input">
                            <asp:Literal ID="ltlLastModifiedBy" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                    <li class="form-line" id="dr-displayimage-field">
                        <label class="form-label-left">
                            &nbsp;</label>
                        <div class="form-input">
                            <asp:Image ID="imgDisplay" runat="server" Visible="false" />
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
