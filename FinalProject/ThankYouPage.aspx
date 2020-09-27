<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYouPage.aspx.cs" Inherits="FinalProject_RMTApp.ThankYouPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }body {
            background-color: #cfdff9;
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="False" style="" Text="Thank you for your purchase!"></asp:Label>
            <br />
            <br />
            <br />
&nbsp;<asp:Label ID="Label2" runat="server" Text="INSTRUCTIONS"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="195px" Width="428px" BackColor="#3C3C3C" ForeColor="White" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="40px" OnClick="Button1_Click" Text="Return to the first page" Width="145px" />
        </div>
    </form>
</body>
</html>
