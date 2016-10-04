<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaptchaTest.aspx.cs" Inherits="JXTPortal.Website.CaptchaTest" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            height: 17px;
        }
    </style>

<script src="https://www.google.com/recaptcha/api.js" async defer></script>
</head>
<body style="font-family: Calibri">

    <form action="/captchatest.aspx" method="post">
      <div class="g-recaptcha" data-sitekey="6Lf9FhUTAAAAAPmy1laIwzFONw7m-htIeDv9y6Wf"></div>
      <br/>
      <input type="submit" value="Submit">
    </form>



    <%--<form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <p>
                        <strong>Captcha Sample</strong></p>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        This is the resulting captcha:</p>
                </td>
                <td>
                    <cc1:CaptchaControl ID="CaptchaControl1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                        CaptchaMaxTimeout="240" FontColor="#529E00" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="font-weight: bold">
                        Available options:</p>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        Control width in pixels:</p>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCtlWidth" Text="180" Width="50px" />
                    <asp:RangeValidator ID="rcCtlWidth" runat="server" ControlToValidate="txtCtlWidth"
                        ErrorMessage="Input number as control's width!" ForeColor="Red" MaximumValue="500"
                        MinimumValue="100" Type="Integer">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 200px">
                    Control height in pixels:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCtlHeight" Text="50" Width="50px" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="chArithmetic" runat="server" Text="Arithmetic" />
                </td>
            </tr>
            <tr>
                <td>
                    Arithmetic function:
                </td>
                <td>
                    <asp:DropDownList ID="ddlFunction" runat="server">
                        <asp:ListItem>Random</asp:ListItem>
                        <asp:ListItem Selected="True">Addition</asp:ListItem>
                        <asp:ListItem>Substraction</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Back color:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBackColor" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Font color:
                </td>
                <td>
                    <asp:DropDownList ID="ddlFontColor" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Line color:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLineColor" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Noise color:
                </td>
                <td>
                    <asp:DropDownList ID="ddlNoiseColor" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Background noise:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBackNoise" runat="server">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem Selected="True">Low</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>High</asp:ListItem>
                        <asp:ListItem>Extreme</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Line noise:
                </td>
                <td class="style1">
                    <asp:DropDownList ID="ddlLineNoise" runat="server">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem Selected="True">Low</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>High</asp:ListItem>
                        <asp:ListItem>Extreme</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Captcha chars:
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtChars" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Font warping:
                </td>
                <td>
                    <asp:DropDownList ID="ddlFontWarp" runat="server">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem Selected="True">Low</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>High</asp:ListItem>
                        <asp:ListItem>Extreme</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Captcha height:
                </td>
                <td class="style2">
                    <asp:TextBox runat="server" ID="txtCapHeight" Text="180" Width="50px" />
                </td>
            </tr>
            <tr>
                <td>
                    Captcha width:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCapWidth" Text="180" Width="50px" />
                </td>
            </tr>
            <tr>
                <td>
                    Length (characters):
                </td>
                <td>
                    <asp:TextBox ID="txtCapLength" runat="server" MaxLength="2" Width="25px">5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Max timeout (sec):
                </td>
                <td>
                    <asp:TextBox ID="txtMaxTimeout" runat="server" MaxLength="2" Width="25px">180</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Min timeout (sec):
                </td>
                <td>
                    <asp:TextBox ID="txtMinTimeout" runat="server" MaxLength="2" Width="25px">3</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Custom validator error message:
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    ImageTag:
                </td>
                <td>
                    <asp:TextBox ID="txtImageTag" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 200px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="cmdApply" runat="server" Text="Apply Changes" OnClick="cmdApply_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    Verify your answer:
                </td>
                <td>
                    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="cmdCheck" runat="server" Text="Validate CAPTCHA" OnClick="cmdCheck_Click" />
                </td>
            </tr>
        </table>
        <p>
            Warning: when you are changing the Arithmetic in code, it will produce image of
            evaluation, but will expect text of it, not the result, as the answer. If Arithmetic
            is set in Markup, the result of evaluation is expected.</p>
    </div>
    </form>--%>

</body>
</html>
