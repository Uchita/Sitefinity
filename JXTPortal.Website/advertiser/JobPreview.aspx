<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Job.Master" AutoEventWireup="true"
    CodeBehind="JobPreview.aspx.cs" Inherits="JXTPortal.Website.advertiser.JobPreview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="jobdetail-left-bg">
            <h1><JXTControl:ucLanguageLiteral ID="ltJobPreview" runat="server" SetLanguageCode="LabelJobPreview" /></h1>
            <JXTControl:JobPreview ID="ucJobPreview" runat="server" isAdvertiserPreview="true" />
        </div>
        <div class="form-all">
            <ul class="form-section">
                <li class="form-line" id="reg-bottom-button">
                    <hr />
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnBack" runat="server" CssClass="mini-new-buttons" 
                                onclick="btnBack_Click" />
                            <asp:Button ID="btnNext" runat="server" CssClass="mini-new-buttons" 
                                onclick="btnNext_Click" />
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
