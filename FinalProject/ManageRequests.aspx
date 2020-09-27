<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRequests.aspx.cs" Inherits="FinalProject_RMTApp.ManageRequestsaspx" %>

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
        td, th {
            padding: 12px;
            font-size: 18px;
            border-width: 0px 0px 1px 0px;
            border-color: black;
            border-style: solid;
            border-color: #8b9099;
        }

        th {
            color: white;
            background-color: rgb(60, 60, 60);
        }
        table{
            display:inline-block;
        }
        .auto-style4 {
            width: 878px;
        }
        .auto-style5 {
            width: 866px;
        }
        .auto-style6 {
            text-align: center;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Font-Bold="True" Font-Size="XX-Large" Text="Manage Sell Requests"></asp:Label>
            <br />
            <br />

        <asp:Button ID="btnReturn" runat="server" Height="33px" Text="Return" Width="235px" OnClick="btnReturn_Click" CausesValidation="False" />

            <br />
            <br />
            <asp:Label ID="labelError" runat="server" ForeColor="Red" Text="Discussion does not exist" Visible="False"></asp:Label>

            <br />

            <br />
        </div>
    <div runat="server" id="items" class="auto-style1">

        <table class="auto-style4" runat="server" id="itemstable">
            <tr>
                <th>Request ID</th>
                <th>Username</th>
                <th>Item name</th>
                <th>Desired Price</th>
                <th>Game name</th>
                <th>Discussion Link</th>
            </tr>
        </table>

    </div>
    <br />
    <div id="accounts" runat="server" class="auto-style1">

        <table class="auto-style5" id="accountstable" runat="server">
            <tr>
                <th>Request ID</th>
                <th>Username</th>
                <th>Account name</th>
                <th>Desired Price</th>
                <th>Game name</th>
                <th>Discussion Link</th>
            </tr>
        </table>

    </div>
        <br />
        <br />
        <div class="auto-style6">

            <strong>Select an item type to accept a request:<br />
            <asp:DropDownList ID="ddlType" runat="server" Height="17px" Width="188px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Selected="True">Please select an item type</asp:ListItem>
                <asp:ListItem>Items</asp:ListItem>
                <asp:ListItem>Accounts</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            </strong>

        </div>
        <div class="auto-style1" id="price" runat="server" visible="false">

            <asp:Label ID="labelItems" runat="server" Font-Bold="True" Text="Select an ID:"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlList" runat="server" AutoPostBack="True" Height="16px" Width="180px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="labelPrice" runat="server" Font-Bold="True" Text="Final Price:"></asp:Label>
            <br />
            <asp:TextBox ID="txtPrice" runat="server" Width="154px"></asp:TextBox>

            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price format should only contain numeric characters and a dot" ForeColor="Red" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click" Text="Accept" />

        </div>
    </form>
    </body>
</html>
