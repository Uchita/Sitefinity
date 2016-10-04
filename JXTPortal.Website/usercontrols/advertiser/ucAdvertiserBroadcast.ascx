<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserBroadcast.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucAdvertiserBroadcast" %>
<%@ Register Src="~/usercontrols/advertiser/ucJobsCurrent.ascx" TagName="ucJobsCurrent" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/advertiser/ucJobsPending.ascx" TagName="ucJobsPending" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/advertiser/ucStatistics.ascx" TagName="ucStatistics" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/advertiser/ucJobsDeclined.ascx" TagName="ucJobsDeclined" TagPrefix="uc3" %>
    <uc1:ucJobsCurrent ID="ucJobsCurrent1" runat="server" />
    <br />
    <uc1:ucJobsPending ID="ucJobsPending1" runat="server" />
    <br />
    <uc3:ucJobsDeclined ID="ucJobsDeclined1" runat="server" />
    <br />
    <uc2:ucStatistics ID="ucStatistics1" runat="server" />