<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="InvoiceDetail.aspx.cs"
    Inherits="InvoiceDetail" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>
        <asp:Literal ID="ltAdvertiserNameHeader" runat="server" />
        Invoice: INV-<%=OrderID %></title>
    <link rel="stylesheet" href="/styles/invoice.css" media="all" />
</head>
<body>
    <header class="clearfix">
      <div id="logo">
        <asp:Literal ID="ltAdvertiserLogoUrl" runat="server" />
      </div>
      <div id="company">
        <asp:Literal ID="ltInvoiceSiteInfo" runat="server" />
      </div>
    </header>
    <main>
      <div id="details" class="clearfix">
        <div id="client">
          <div class="to">INVOICE TO:</div>
          <h2 class="name"><asp:Literal ID="ltClientName" runat="server" /></h2>
          <div class="address"><asp:Literal ID="ltClientAddress" runat="server" /></div>
          <div class="email"><asp:Literal ID="ltClientEmail" runat="server" /><!-- a href="mailto:john@example.com">john@example.com</a --></div>
        </div>
        <div id="invoice">
          <h1>INVOICE INV-<%=OrderID %></h1>
          <div class="date">Date of Invoice: <asp:Literal ID="ltDateOfInvoice" runat="server" /></div>
        </div>
      </div>
      <table border="0" cellspacing="0" cellpadding="0">
        <thead>
          <tr>
            <th class="no">#</th>
            <th class="desc"><strong>DESCRIPTION</strong></th>
            <th class="unit"><strong>UNIT PRICE</strong></th>
            <th class="qty"><strong>QUANTITY</strong></th>
            <th class="total"><strong>TOTAL</strong></th>
          </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptInvoice" runat="server" 
                onitemdatabound="rptInvoice_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="no"><%# Container.ItemIndex + 1 %></td>
                        <td class="desc"><h3><asp:Literal id="ltPackName" runat="server" /></h3><asp:Literal id="ltPackDescription" runat="server" /></td>
                        <td class="unit"><asp:Literal id="ltUnitPrice" runat="server" /></td>
                        <td class="qty"><asp:Literal id="ltQuantity" runat="server" /></td>
                        <td class="total"><asp:Literal id="ltTotal" runat="server" /></td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
        </tbody>
        <tfoot>
          <tr>
            <td colspan="2"></td>
            <td colspan="2">SUBTOTAL</td>
            <td><asp:Literal ID="ltSubTotal" runat="server" /></td>
          </tr>
          <tr>
            <td colspan="2"></td>
            <td colspan="2"><asp:Literal ID="ltTaxLabel" runat="server" />:</td>
            <td><asp:Literal ID="ltTax" runat="server" /></td>
          </tr>
          <tr>
            <td colspan="2"></td>
            <td colspan="2">GRAND TOTAL</td>
            <td><asp:Literal ID="ltGrandTotal" runat="server" /></td>
          </tr>
        </tfoot>
      </table>

      <asp:Literal ID="ltInvoiceSiteFooter" runat="server" />

      <%--<div id="thanks">Thank you!</div>

      <div class="notices">
        <h3>Bank Details:</h3>
        <div class="notice">
          Account Name: Care Careers <br/>Bank: Commonwealth Bank
          <br/>Account Number: 01324561456 <br/>BSB: 012 365
        </div>
      </div>
      <div class="notices">
        <h3>NOTICE:</h3>
        <div class="notice">This needs to be customisable per white label. This will probably be used by a client to advise on payment terms and penalties for late payment.</div>
      </div>
    </main>
    <footer>
      Invoice was created on a computer and is valid without the signature and seal.
    </footer>--%>
</body>
</html>
