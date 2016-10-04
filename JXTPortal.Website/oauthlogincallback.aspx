<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oauthlogincallback.aspx.cs" Inherits="JXTPortal.Website.oauthlogincallback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfGoogleAccessToken" runat="server" />
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
    </script>
</body>
</html>
