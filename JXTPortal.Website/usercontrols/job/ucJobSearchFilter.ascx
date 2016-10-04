<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobSearchFilter.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucJobSearchFilter" %>
<asp:Literal ID="ltlSearchedFor" runat="server" />
<div class="search-query map-address">
    <div class="mapFilter">
        <label for="mapSearchAddress">
            Street Address/Postcode</label>
        <input type="text" id="mapSearchAddress" class="" placeholder="Enter City, State or postcode" />
    </div>
    <div class="mapFilter">
        <label for="mapSearchRadius">
            Radius</label>
        <select name="mapSearchRadius" id="mapSearchRadius" class="">
            <option value="5">5 km</option>
            <option value="10">10 km</option>
            <option value="20">20 km</option>
            <option value="30">30 km</option>
            <option value="40">40 km</option>
            <option value="50">50 km</option>
            <option value="100">100 km</option>
        </select>
    </div>
    <div class="mapFilter">
        <button id="mapRadiusSearchBtn" type="button" class="mini-new-buttons" disabled="disabled"
            onclick="MapSearch();">
            Update Map</button>
        <button id="mapRadiusSearchClearBtn" type="button" class="mini-new-buttons" disabled="disabled"
            onclick="RadiusSearchClear();">
            Clear</button>
    </div>
</div>
<asp:Repeater ID="rptSearchFor" runat="server" OnItemDataBound="rptSearchFor_ItemDataBound"
    OnItemCommand="rptSearchFor_ItemCommand">
    <HeaderTemplate>
        <div class='search-query'>
    </HeaderTemplate>
    <ItemTemplate>
        <h3>
            <asp:Literal ID="ltlTitle" runat="server" /></h3>
        <p>
            <span class='search-query-filter'>
                <asp:Literal ID="ltlText" runat="server" /></span> <span class='red-remove'>(<asp:LinkButton
                    ID="lbtnSearchFor" runat="server" />)</span></p>
    </ItemTemplate>
    <FooterTemplate>
        </div></FooterTemplate>
</asp:Repeater>
<asp:HiddenField ID="hfSearchFor" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfCurrency" runat="server" ClientIDMode="Static" />
<ul id="side-drop-menu">
    <li id="AdvancedSearchFilter_PnlClassification">
        <asp:Literal ID="ltlClassification" runat="server" />
        <asp:Repeater ID="rptClassification" runat="server" OnItemDataBound="rptJobResultFilter_ItemDataBound"
            OnItemCommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </li>
    <li id="AdvancedSearchFilter_PnlSubClassification">
        <asp:Literal ID="ltlSubClassification" runat="server" />
        <asp:Repeater ID="rptSubClassification" runat="server" OnItemDataBound="rptJobResultFilter_ItemDataBound"
            OnItemCommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </li>
    <li id="AdvancedSearchFilter_PnlLocation">
        <asp:Literal ID="ltlLocation" runat="server" />
        <asp:Repeater ID="rptLocation" runat="server" OnItemDataBound="rptJobResultFilter_ItemDataBound"
            OnItemCommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </li>
    <li id="AdvancedSearchFilter_PnlArea">
        <asp:Literal ID="ltlArea" runat="server" />
        <asp:Repeater ID="rptArea" runat="server" OnItemDataBound="rptJobResultFilter_ItemDataBound"
            OnItemCommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </li>
    <li id="AdvancedSearchFilter_PnlWorkType">
        <asp:Literal ID="ltlWorkType" runat="server" />
        <asp:Repeater ID="rptWorkType" runat="server" OnItemDataBound="rptJobResultFilter_ItemDataBound"
            OnItemCommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </li>
    <li id="AdvancedSearchFilter_PnlCompany">
        <asp:Literal ID="ltlCompany" runat="server" />
        <asp:Repeater ID="rptCompany" runat="server" OnItemDataBound="rptJobResultFilter_ItemDataBound"
            OnItemCommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </li>
    <li id="AdvancedSearchFilter_PnlSalary">
        <%--<asp:Repeater ID="rptSalary" runat="server" 
            onitemdatabound="rptJobResultFilter_ItemDataBound" 
            onitemcommand="rptJobResultFilter_ItemCommand">
            <HeaderTemplate><ul></HeaderTemplate>
            <ItemTemplate>        
                <li><asp:LinkButton ID="lbLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>--%>
        <asp:PlaceHolder ID="plHolderSalary" runat="server">
            <asp:Literal ID="ltlSalary" runat="server" />



             <div class="jxt-salary-type">
                <asp:DropDownList runat="server" ID="ddlSalary" DataTextField="SalaryTypeName" DataValueField="SalaryTypeID" ClientIDMode="Static" />    	        
            </div>
    
            <div class="jxt-salary-bands">
                <asp:HiddenField ID="hiddenSalaryTypeID" ClientIDMode="Static" runat="server" />
                <div class="jxt-salary-min">
                    <label for="txtSalaryLowerBand">Minimum Salary</label>
                    <div class="jxt-salary-input">
	                    <span class="jxt-salary-currency"><asp:Literal ID="ltlLowerCurrency" runat="server" /></span>
                            <asp:TextBox runat="server" ID="txtSalaryLowerBand" CssClass="numbersOnly" ClientIDMode="Static" />
                    </div>
                </div>
                <div class="jxt-salary-to">
                    <%= JXTPortal.Website.CommonFunction.GetResourceValue("LabelTo")%>
                </div>
                <div class="jxt-salary-max">
                    <label for="txtSalaryUpperBand">Maximum Salary</label>
                    <div class="jxt-salary-input">
            	        <span class="jxt-salary-currency"><asp:Literal ID="ltlUpperCurrency" runat="server" /></span>
                            <asp:TextBox runat="server" ID="txtSalaryUpperBand" CssClass="numbersOnly" ClientIDMode="Static" />
                    </div>
                </div>
            </div>

            <div class="jxt-salary-submit">
    	        <asp:Button ID="btnSalaryRefine" runat="server" OnClick="btnSalaryRefine_Click" CssClass="mini-new-buttons" />
            </div>
            
        </asp:PlaceHolder>
    </li>
</ul>
