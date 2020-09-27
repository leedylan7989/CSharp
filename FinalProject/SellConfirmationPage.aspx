<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellConfirmationPage.aspx.cs" Inherits="FinalProject_RMTApp.SellConfirmationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-decoration: underline;
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
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Font-Bold="True" Font-Size="XX-Large" Text="Thank you!"></asp:Label>
        </div>
        <div id="linkDiv" runat="server" class="auto-style1" visible="false">

            <asp:Label ID="labelLink" runat="server" Text="Label"></asp:Label>

        </div>
        <div id="currency" runat="server" visible="false" class="auto-style1">

            <asp:Label ID="labelCurrency" runat="server" Font-Bold="True" Text="Label"></asp:Label>

        </div>
        <p class="auto-style1">
            <asp:Button ID="btnReturn" runat="server" Height="47px" Text="Return to the first page" Width="176px" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
