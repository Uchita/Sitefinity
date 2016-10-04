<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oauthcallback.aspx.cs" Inherits="JXTPortal.Website.oauthcallback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfGoogleAccessToken" runat="server" />
    <asp:HiddenField ID="hfGoogleAccessDenied" runat="server" />
    </form>
     <script type="text/javascript">
         var params = {}, queryString = location.hash.substring(1), regex = /([^&=]+)=([^&]*)/g, m;
         while (m = regex.exec(queryString)) {
             params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
         }

         if (params["access_token"]) {
             document.getElementById("hfGoogleAccessToken").value = params["access_token"];
             document.getElementById("form1").submit();
         }
         if (params["error"]) {
             document.getElementById("hfGoogleAccessDenied").value = params["error"];
             document.getElementById("form1").submit();
         }

    </script>
</body>
</html>
