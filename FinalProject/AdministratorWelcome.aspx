<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministratorWelcome.aspx.cs" Inherits="FinalProject_RMTApp.AdministratorWelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        body {
            background-color: #cfdff9;
            font-family: Calibri;
        }
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text="Welcome!" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnRequest" runat="server" Font-Bold="True" Font-Size="XX-Large" Height="73px" Width="395px" Text="View all sell requests" OnClick="btnRequest_Click" />
            <br />
            <br />
&nbsp;<asp:Button ID="btnForum" runat="server" Font-Bold="True" Font-Size="XX-Large" Height="73px" Text="Forum" Width="386px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="XX-Large" Height="73px" Text="Log out" Width="386px" OnClick="btnReturn_Click" />
        </div>
    </form>
</body>
</html>
