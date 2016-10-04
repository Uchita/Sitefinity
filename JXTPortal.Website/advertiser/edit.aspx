<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="JXTPortal.Website.advertiser.edit" %>

<%@ Register Src="~/usercontrols/advertiser/ucAdvertiserEdit.ascx" TagName="ucAdvertiserEdit"
    TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/advertiser/ucAdvertiserChangePassword.ascx" TagName="ucAdvertiserChangePassword"
    TagPrefix="uc3" %>
<%@ Register Src="~/usercontrols/advertiser/ucAdvertiserSubAccounts.ascx" TagName="ucAdvertiserSubAccounts"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tbNewPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>

    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserEdit" />
            <div class="tabs-holder">
                <ul id="ulTabs" class="tabs">
                    <li><a href="#tab1">
                        <JXTControl:ucLanguageLiteral ID="litAdvEditMyDetails" runat="server" SetLanguageCode="LabelMyDetails" />
                    </a></li>
                    
                    
                        <li><asp:PlaceHolder ID="phSubAccountsTab" runat="server"><a href="#tab2">
                            <JXTControl:ucLanguageLiteral ID="litAdvEditSubAccounts" runat="server" SetLanguageCode="LabelSubAccounts" />
                        </a></asp:PlaceHolder></li>
                    
                    
                    <li><a href="#tab3">
                        <JXTControl:ucLanguageLiteral ID="litAdvEditMyPassword" runat="server" SetLanguageCode="LabelMyPassword" />
                    </a></li>
                </ul>
                <div id="tabcontainer" runat="server" class="tab_container">
                    <div id="tab1" class="tab_content">
                        <uc2:ucAdvertiserEdit ID="ucAdvertiserEdit1" runat="server" />
                    </div>
                    
                    <div id="tab2" class="tab_content">
                    <asp:PlaceHolder ID="phSubAccountsPanel" runat="server">
                        
                            <asp:UpdatePanel ID="updatePanel" runat="server">
                                <ContentTemplate>
                                    <uc4:ucAdvertiserSubAccounts ID="ucAdvertiserSubAccounts1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        
                    </asp:PlaceHolder>
                    </div>

                    <div id="tab3" class="tab_content">
                        <uc3:ucAdvertiserChangePassword ID="ucAdvertiserChangePassword1" runat="server" />
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                $(document).ready(function() {

                    //When page loads...
                    $(".tab_content").hide(); //Hide all content
                    $("ul.tabs li").removeClass("active");
                    $("ul.tabs li:eq(<%=SelectedTabIndex %>)").addClass("active").show(); //Activate first tab
                    $(".tab_content:eq(<%=SelectedTabIndex %>)").show(); //Show first tab content

                    //On Click Event
                    $("ul.tabs li").click(function() {

                        $("ul.tabs li").removeClass("active"); //Remove any "active" class
                        $(this).addClass("active"); //Add "active" class to selected tab
                        $(".tab_content").hide(); //Hide all tab content

                        var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
                        $(activeTab).fadeIn(); //Fade in the active ID content
                        return false;
                    });

                });

            </script>

        </div>
    </div>
</asp:Content>
