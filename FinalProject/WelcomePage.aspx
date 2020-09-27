<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="FinalProject_RMTApp.WelcomePage" %>

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
            <br />
            <asp:Label ID="welcomeLabel" runat="server" Font-Size="XX-Large" Text="Welcome!"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnBuy" runat="server" Font-Bold="True" Font-Size="X-Large" Height="51px" OnClick="btnBuy_Click" Text="Buy in-game currency / items / accounts" Width="479px" />
            <br />
            <br />
            <br />
&nbsp;<asp:Button ID="btnSell" runat="server" Font-Bold="True" Font-Size="X-Large" Height="58px" Text="Sell in-game currency / items / accounts" Width="472px" OnClick="btnSell_Click" />
            <br />
            <br />
            <asp:Button ID="btnForum" runat="server" Font-Bold="True" Font-Size="X-Large" Height="58px" Text="RMT Discussion Forum" Width="472px" OnClick="btnForum_Click" />
            <br />
            <br />
            <asp:Button ID="btnLogout" runat="server" Font-Bold="True" Font-Size="X-Large" Height="58px" Text="Log Out" Width="472px" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
