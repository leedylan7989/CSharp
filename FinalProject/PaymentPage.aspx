<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="FinalProject_RMTApp.PaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        body {
            background-color: #cfdff9;
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="PURCHASE CONFIRMATION"></asp:Label>
            <br />
            <br />
            <strong>Your Total:</strong><br />
            <br />
            <asp:TextBox ID="tbItemList" runat="server" BackColor="#3C3C3C" ForeColor="White" Height="268px" TextMode="MultiLine" Width="392px" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Pay and Proceed" Width="149px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" Width="149px" />
            <br />
        </div>
    </form>
</body>
</html>
