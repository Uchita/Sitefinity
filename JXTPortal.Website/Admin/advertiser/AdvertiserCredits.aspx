<%@ Page Title="Advertiser Credits" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="AdvertiserCredits.aspx.cs" Inherits="JXTPortal.Website.Admin.advertiser.AdvertiserCreditsSystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Advertiser Credits
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <li class="form-line" id="Li2">
                        <label class="form-label-left">
                            Advertiser:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:Literal ID="lblAdvertiserName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            Job Type:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlJobItemType" runat="server" CssClass="form-multiple-column"
                                AutoPostBack="true" DataValueField="JobItemTypeParentID" DataTextField="JobItemTypeDescription">
                            </asp:DropDownList>
                        </div>
                    </li>
                    <li class="form-line" id="gse-sitedoctype-field">
                        <label class="form-label-left">
                            Total Amount:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="tbTotalAmount" runat="server" />
                        </div>
                    </li>
                </ContentTemplate>
            </asp:UpdatePanel>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnEditSave" runat="server" Text="Create" 
                            CssClass="jxtadminbutton" />
                        <asp:Button ID="btnEditCancel" runat="server" Text="Cancel" 
                            CssClass="jxtadminbutton" Visible="false" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" 
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
<%--    <table cellpadding="3" border="0" class="grid">
        <asp:Repeater ID="rptAdminAdvertiserJobPricing" runat="server" OnItemCommand="rptAdminAdvertiserJobPricing_ItemCommand"
            OnItemDataBound="rptAdminAdvertiserJobPricing_ItemDataBound">
            <HeaderTemplate>
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                      
                        <th scope="col">
                            Job Type
                        </th>
                        <th scope="col">
                            Start
                        </th>
                        <th scope="col">
                            Expiry
                        </th>
                        <th scope="col">
                            Total Amount ($)
                        </th>
                        <th scope="col">
                            Last Modified
                        </th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/admin/advertiser/advertiserjobpricing.aspx?AdvertiserID=<%# Eval("AdvertiserID") %>&JobItemsTypeID=<%# Eval("JobItemsTypeID") %>'>
                            Edit</a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvertiserJobPricingType" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvertiserJobPricingStartDate" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvertiserJobPricingExpirtyDate" runat="server" />
                    </td>
                    <td scope="col">
                        $<asp:Literal ID="ltAdminAdvertiserJobPricingTotal" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvertiserJobPricingLastModified" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
    </table>
--%></asp:Content>

