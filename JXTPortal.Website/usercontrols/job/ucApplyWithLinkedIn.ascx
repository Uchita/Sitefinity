<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucApplyWithLinkedIn.ascx.cs" Inherits="JXTPortal.Website.usercontrols.job.ucApplyWithLinkedIn" %>
<script type="text/javascript" src="http://platform.linkedin.com/in.js">
    api_key: <%=LinkedInAPI %>
</script>

<script type="IN/Apply" data-companyid="<%=LinkedInCompanyID %>" data-jobid="<%=ProductID %>" data-jobtitle="<%=ProductName %>" data-logo="<%=LinkedInLogo %>"
   data-email="<%=LinkedInEmail %>" data-url="<%=LinkedInApplicationLink %>" data-urlformat="xml">
</script>