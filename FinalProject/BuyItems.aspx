<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyItems.aspx.cs" Inherits="FinalProject_RMTApp.Buy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            margin-left: 0px;
        }
        body {
            background-color: #cfdff9;
            font-family: Calibri;
        }
        .auto-style4 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="labelTitle" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="ITEM PURCHASE" CssClass="auto-style4"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" />
            <br />
            <br />
            Total Price: $<asp:Label ID="labelTotal" runat="server" Text="0.00"></asp:Label>
            <br />
            <br />
            Your Account: $<asp:Label ID="labelRMT" runat="server" Text="Label"></asp:Label>
            &nbsp;<br />
            <br />
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Game Selection"></asp:Label>
            :<br />
            <asp:DropDownList ID="ddlSelection" runat="server" OnSelectedIndexChanged="ddlSelection_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True">Please select a game</asp:ListItem>
            </asp:DropDownList>
            <br />
            <div class="auto-style2">
                &nbsp;<br />
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
                </asp:GridView>
                <div class="auto-style1">
&nbsp;<br />
                    <asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="True" Height="23px" Visible="False" Width="187px" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Please select an item</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="btnCart" runat="server" OnClick="btnCart_Click" Text="Add to cart" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnPurchase" runat="server" OnClick="Button1_Click" Text="Purchase" Visible="False" />
                    &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="The cart is empty" Visible="False"></asp:Label>
&nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="Not enough Credit" Visible="False"></asp:Label>
                    &nbsp;
                    <asp:Label ID="labelInCart" runat="server" Font-Bold="True" ForeColor="Red" Text="In your cart!" Visible="False"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                <br />
                    <asp:DropDownList ID="ddlRemove" runat="server" Height="16px" Visible="False" Width="152px">
                        <asp:ListItem Selected="True">Select an item ID to remove</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRemove" runat="server" CssClass="auto-style3" OnClick="btnRemove_Click" Text="Remove" Visible="False" Width="80px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Visible="False" Width="80px" />
                    <br />
                    <br />
                    <asp:TextBox ID="txtCart" runat="server" Height="113px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="443px" BackColor="#3C3C3C" ForeColor="White"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
