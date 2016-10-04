<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteProfession" Title="Site Locations - Site Professions"
    CodeBehind="SiteProfession.aspx.cs" %>

<%@ Register TagPrefix="uc" Namespace="JXTPortal.Website.Admin.UserControls" Assembly="JXTPortal.Website" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Profession List <a href='http://support.jxt.com.au/solution/articles/116445-site-professions-roles'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function client_OnTreeNodeChecked(e) {
            var ev;
            if (window.event)
            { ev = window.event; }
            else { ev = e; }
            var obj = (ev.srcElement || ev.target);
            var treeNodeFound = false;
            var checkedState;
            if (obj.tagName == "INPUT" && obj.type == "checkbox") {
                var treeNode = obj;
                checkedState = treeNode.checked;
                do {
                    obj = (obj.parentElement || obj.parentNode);
                } while (obj.tagName != "TABLE")

                if ((obj.parentElement || obj.parentNode).previousSibling.innerHTML.indexOf("tbody>") > 0 || (obj.parentElement || obj.parentNode).previousSibling.innerHTML.indexOf("TBODY>") > 0) {
                    var prevObj;
                    prevObj = (obj.parentElement || obj.parentNode).previousSibling;
                    prevObj.getElementsByTagName("input")[0].checked = true;
                }

                var parentTreeLevel = obj.rows[0].cells.length;
                var parentTreeNode = obj.rows[0].cells[0];
                var tables = (obj.parentElement || obj.parentNode).getElementsByTagName("TABLE");
                var numTables = tables.length
                if (numTables >= 1) {
                    for (i = 0; i < numTables; i++) {
                        if (tables[i] == obj) {
                            treeNodeFound = true;
                            i++;
                            if (i == numTables) {
                                return;
                            }
                        }
                        if (treeNodeFound == true) {
                            var childTreeLevel = tables[i].rows[0].cells.length;
                            if (childTreeLevel > parentTreeLevel) {
                                var cell = tables[i].rows[0].cells[childTreeLevel - 1];
                                var inputs = cell.getElementsByTagName("INPUT");
                                inputs[0].checked = checkedState;
                            }
                            else {
                                return;
                            }
                        }
                    }
                }
            }
        }

        function SelectAllCB() {
            var cbAll = document.getElementById("cbSelectAll");

            var cbs = document.getElementById("ctl00_ContentPlaceHolder1_TreeView2");
            if (!document.getElementById("ctl00_ContentPlaceHolder1_TreeView2")) {
                cbs = document.getElementById("ContentPlaceHolder1_TreeView2");
            }
            cbs = cbs.getElementsByTagName("input")
            for (var i = 0; i < cbs.length; i++) {
                if (cbs[i].type == "checkbox") {

                    cbs[i].checked = cbAll.checked;
                }
            }

        }
    </script>

     
        <div class="form-all">
            <asp:Button ID="btnImport" runat="server" Text="Import Custom Profession/Roles" CssClass="jxtadminbutton"
                                OnClick="btnImport_Click" /> 
            <span class="form-message">
                <asp:Literal ID="ltlMessage" runat="server" /></span>
            <asp:MultiView ID="MultiViewSiteProfession" runat="server" ActiveViewIndex="0">
                <asp:View ID="ViewSiteProfession" runat="server">
                    <ul class="form-section">
                       
                        <li class="form-line" id="sfr-selectall-field">
                            <label class="form-label-left">
                                <input id="cbSelectAll" type="checkbox" onclick="SelectAllCB();" />
                                <strong>Select All Profession / Roles</strong>
                            </label>
                        </li>
                        <li class="form-line">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper-left">
                                    <asp:Button ID="btnEditSaveTop" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                        CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                    <asp:HiddenField ID="hfErrorText" runat="server" />
                    <div id="tree-section-container">
                        <div class="tree-section-1">
                            <label>
                                <strong>Default</strong></label><br />
                            <asp:TreeView ID="TreeView1" runat="server" />
                        </div>
                        <div class="tree-section-2">
                            <label>
                                <strong>Site</strong></label><br />
                            <uc:ProfessionRoleTreeView ID="TreeView2" runat="server" onclick="client_OnTreeNodeChecked(event);" />
                        </div>
                    </div>
                    <ul>
                        <li class="form-line">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper-left">
                                    <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                        CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </asp:View>

                <asp:View ID="ViewSiteCustomProfession" runat="server">
                                  
                    

                </asp:View>
            </asp:MultiView>
        </div>
</asp:Content>
