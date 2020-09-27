<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Selection.aspx.cs" Inherits="FinalProject_RMTApp.GameSelection" %>

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
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Select "></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnCurrency" runat="server" Font-Size="X-Large" Height="71px" OnClick="btnCurrency_Click" Text="In-game Currency" Width="215px" />
            <br />
            <br />
            <asp:Button ID="btnItems" runat="server" Font-Size="X-Large" Height="71px" Text="In-game Items" Width="215px" OnClick="btnItems_Click" />
            <br />
            <br />
            <asp:Button ID="btnAccounts" runat="server" Font-Size="X-Large" Height="71px" Text="In-game Accounts" Width="215px" OnClick="btnAccounts_Click" />
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" Font-Size="X-Large" Height="71px" Text="Return" Width="215px" OnClick="btnReturn_Click" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
