<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JXTPortal.Website.member.sso.monash.login" %>
<%--<script runat="server">

    protected void Page_Init(object sender, EventArgs e)
    {
        // If already logged in - then redirect to advanced search page.
        if (JXTPortal.Entities.SessionData.Member != null)
            Response.Redirect("~/advancedsearch.aspx?search=1");

        if (!string.IsNullOrWhiteSpace(Request["SAMLResponse"]))
        {
            string rawSamlData = Request["SAMLResponse"];

            //rawSamlData = "PHNhbWxwOlJlc3BvbnNlIElEPSJfNjU2NGU5ZGYtNzlmMS00Nzc4LWFkYjUtMzQ5ZDZjZDg4YzE5IiBWZXJzaW9uPSIyLjAiIElzc3VlSW5zdGFudD0iMjAxNS0xMC0xM1QwMjozMTo1My41NzFaIiBEZXN0aW5hdGlvbj0iaHR0cHM6Ly93d3cuc3RhZmYtam9icy1tb25hc2guanh0Lm5ldC5hdS9tZW1iZXIvc3NvL21vbmFzaC9sb2dpbi5hc3B4IiBDb25zZW50PSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6Y29uc2VudDp1bnNwZWNpZmllZCIgSW5SZXNwb25zZVRvPSJfZTA5MWE0ZTctNDdkMy00M2NjLTgzN2EtNDg4YzI3NmU4NGNiIiB4bWxuczpzYW1scD0idXJuOm9hc2lzOm5hbWVzOnRjOlNBTUw6Mi4wOnByb3RvY29sIj48SXNzdWVyIHhtbG5zPSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6YXNzZXJ0aW9uIj5odHRwOi8vbG9naW4tcWEubW9uYXNoLmVkdS9hZGZzL3NlcnZpY2VzL3RydXN0PC9Jc3N1ZXI%2BPGRzOlNpZ25hdHVyZSB4bWxuczpkcz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyI%2BPGRzOlNpZ25lZEluZm8%2BPGRzOkNhbm9uaWNhbGl6YXRpb25NZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzEwL3htbC1leGMtYzE0biMiIC8%2BPGRzOlNpZ25hdHVyZU1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQveG1sZHNpZy1tb3JlI3JzYS1zaGEyNTYiIC8%2BPGRzOlJlZmVyZW5jZSBVUkk9IiNfNjU2NGU5ZGYtNzlmMS00Nzc4LWFkYjUtMzQ5ZDZjZDg4YzE5Ij48ZHM6VHJhbnNmb3Jtcz48ZHM6VHJhbnNmb3JtIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnI2VudmVsb3BlZC1zaWduYXR1cmUiIC8%2BPGRzOlRyYW5zZm9ybSBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMTAveG1sLWV4Yy1jMTRuIyIgLz48L2RzOlRyYW5zZm9ybXM%2BPGRzOkRpZ2VzdE1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQveG1sZW5jI3NoYTI1NiIgLz48ZHM6RGlnZXN0VmFsdWU%2BQSsxR0hGV0lyMGtHRGVXeWVTUUhBUGVKeVFxUWtablpOY3FaL3MvMmp2RT08L2RzOkRpZ2VzdFZhbHVlPjwvZHM6UmVmZXJlbmNlPjwvZHM6U2lnbmVkSW5mbz48ZHM6U2lnbmF0dXJlVmFsdWU%2BcFJDTnoyQTBVNUpDNGMwVTBKNXFveFprOVNlNk9rUFhrT0t2aUtiM0NkcnZpZHoyZU52bnVocTZ5b1U2TTYwazNqaWc5WlpoOUVYSW9RWmhwT2lMaFVTL2NadjJLU3ZzaUhCWW5URjBhdVlEZ0dmNlprYndIRGJHV1lEYkdFNEVVQ2V6T1BTdmZzRTNtQlhZSUJydzZVaXVHZklrWVJSYm5pQkl0RzcrVncyZ0NzZFFESmJDVThlQUo5RHRmaHBNM01CY0pGbWd3bGRKK3ZQV1BmQXdJZlBqMk9IRWVUU2ZZVTNkR1AzY25FUTBrLzV6Sjc2RVdjRVVaUnB1MHJXa2NYS0MwVTB2SUVqNUVUcXUydkJtQnpNY2t5eUxCekJWOVZQYXU3WWRqZGdaa1kvd05Fcy9OemRIZS9JM2N2QlgrUjJ2bFlJbEtkTVdpK1ovM0FIYTJ3PT08L2RzOlNpZ25hdHVyZVZhbHVlPjxLZXlJbmZvIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwLzA5L3htbGRzaWcjIj48ZHM6WDUwOURhdGE%2BPGRzOlg1MDlDZXJ0aWZpY2F0ZT5NSUlDNGpDQ0FjcWdBd0lCQWdJUVpGNXBVaU9nc3BKRGw2VnRTQ0ZLZnpBTkJna3Foa2lHOXcwQkFRc0ZBREF0TVNzd0tRWURWUVFERXlKQlJFWlRJRk5wWjI1cGJtY2dMU0JzYjJkcGJpMXhZUzV0YjI1aGMyZ3VaV1IxTUI0WERURTBNVEF6TVRBeU16WXpNVm9YRFRFMU1UQXpNVEF5TXpZek1Wb3dMVEVyTUNrR0ExVUVBeE1pUVVSR1V5QlRhV2R1YVc1bklDMGdiRzluYVc0dGNXRXViVzl1WVhOb0xtVmtkVENDQVNJd0RRWUpLb1pJaHZjTkFRRUJCUUFEZ2dFUEFEQ0NBUW9DZ2dFQkFNRWRwdjlRczJzaUtNQzZFZkkxc3lwdk1sVGQ1SFdyTzYvQ1FnUkpRSUVJdGgzVHQwNDBCU3RiNStqQTljWGk1ZTYyTzg3VVdqUlJocUJTU0lyTFU3SjdTbGR6ekRpTTBhQ2NobVovUURJWklMMXcvYlJaNnlyY3ZvWUcyaytzMzdRYXBqMWFGWHR3SzMzMEE5b0hpaHI2d0pGRUR0akxBKy9IbklhRUk2QVVXV2pGS3ZxSm1UdkRNZUdGQVpTVkhNQ3VNRUdhaGpwWUlCWU5WWk03VDU2OTFkK1BOOEwvSksyVEVNT1NORlA0ZzZicTFMbDlScTJVeTEvbUxHSndsbU5SMzBlbnJEazVSWWFlRHdvT0JLeU5sUldQaEhuUUUrWTdabTdiamNna0pKNE5ZNzM5Z0F6TE1Sem95Sm9Rc0xlbzJSdTdmdk5ZSElJb2Q4aENJZEVDQXdFQUFUQU5CZ2txaGtpRzl3MEJBUXNGQUFPQ0FRRUFxcFRNQVhra29aMThNS1ZIRE9ubmpWc1lhUEc3UWw5VHRYQWk3SmVzbkVJVmVTMEF6L3ovV2ZDbVpZb21CWnR0Ymx4M2h1THk2R1VkSzg1S1NzWGpCemxsb1JMNlJ4VW5wREk3QldTRWRrcGFrS295MFJVUUQ5Yml4L2wvTzZNMVFneFk3TmJLaXBDNTVhRVZIMzdXekZqenJnVWdGSGk1WVREUGhvNHV0dUdIMkxLUkVqZ0ZHeFR0UGtZZE1EUTF6cDc0b3N2ZmQyZFVmTFBPbjJ0bGRaVDlZU2F3OGl2VGU4OWdFdEQ0YkdUd0dhQVhzRVphRE1ocS9uVU0zS2pZTGpqQzVaUzdqNzJicTFsZUtnUGJtVmtwZENsWUMrbVNLUVk1Y1VhVlhaK2lRNFRLM3NrMlZ0TUV4clVHZlpFcTFsdytmRUR2MlRIMWdWQU8vZEMwNlE9PTwvZHM6WDUwOUNlcnRpZmljYXRlPjwvZHM6WDUwOURhdGE%2BPC9LZXlJbmZvPjwvZHM6U2lnbmF0dXJlPjxzYW1scDpTdGF0dXM%2BPHNhbWxwOlN0YXR1c0NvZGUgVmFsdWU9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpzdGF0dXM6UmVzcG9uZGVyIj48c2FtbHA6U3RhdHVzQ29kZSBWYWx1ZT0idXJuOm9hc2lzOm5hbWVzOnRjOlNBTUw6Mi4wOnN0YXR1czpSZXF1ZXN0RGVuaWVkIiAvPjwvc2FtbHA6U3RhdHVzQ29kZT48L3NhbWxwOlN0YXR1cz48L3NhbWxwOlJlc3BvbnNlPg%3D%3D";
            if (!string.IsNullOrWhiteSpace(rawSamlData) && rawSamlData.Contains('%'))
            {
                rawSamlData = HttpUtility.UrlDecode(rawSamlData);
            }
            string samlAssertion = string.Empty;

            if (!string.IsNullOrWhiteSpace(rawSamlData))
            {
                // read the base64 encoded bytes
                byte[] samlData = Convert.FromBase64String(rawSamlData);

                // read back into a UTF string
                samlAssertion = System.Text.Encoding.UTF8.GetString(samlData);

            }


            if (!string.IsNullOrWhiteSpace(rawSamlData))
            {
                SocialMedia.Client.Monash.MonashSamlSSO monashSamlSSO = new SocialMedia.Client.Monash.MonashSamlSSO();

                string errormsg = string.Empty;

                bool blnSave = monashSamlSSO.SaveMemberAndLogin(rawSamlData, ref errormsg);

                // If logged in.
                if (blnSave && JXTPortal.Entities.SessionData.Member != null)
                    Response.Redirect("~/advancedsearch.aspx?search=1");
                else
                {
                    Response.Write(@"<h1><a href='http://www.monash.edu' target='_blank'><img style='max-width: 100%;' alt='Monash University' src='http://images.jxt.net.au/monash-university/images/logo.png'></a></h1>

<div>
	<p style='font-family: Arial,Helvetica,sans-serif;'>Please note that only Monash University staff have access to this site.  If you are as staff member, please try again. 
    If you continue to receive this message please <a href='http://www.jobs-monash.jxt.net.au/contact' target='_blank'><strong>contact us</strong></a> with further information.  
    We apologise for any inconvenience caused.
 
	</p>
</div>");
                    //Response.Write(samlAssertion);                    
                    Response.End();                    
                }
            }
            
        }
    }
</script>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
