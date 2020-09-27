<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="FinalProject_RMTApp.LoginPage" StyleSheetTheme="" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            margin-left: 0px;
        }
        body {
            background-color: #cfdff9;
            font-family: Calibri;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style5">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Welcome to RMT!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Please login in to proceed"></asp:Label>
            <br />
            <br />
            UserName:
                        <asp:TextBox ID="TextBox1" runat="server" style="text-align: left" Width="201px" CssClass="auto-style6"></asp:TextBox>
                    <br />
                    <br />
            Password:
                        <asp:TextBox ID="TextBox2" runat="server" style="text-align: left" Width="195px"></asp:TextBox>
                    <br />
            <br />
        </div>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Registration</asp:LinkButton>
        </div>
    </form>
</body>
</html>
