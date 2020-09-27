<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellPage.aspx.cs" Inherits="FinalProject_RMTApp.SellPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-decoration: underline;
        }
        .auto-style3 {
            width: 478px;
        }
        table{
             display:inline-block;
         }
        .auto-style5 {
            width: 195px;
            text-align: right;
        }
        .auto-style7 {
            width: 519px;
        }
        .auto-style9 {
            width: 100%;
        }
        .auto-style12 {
            text-align: left;
            width: 291px;
        }
        .auto-style13 {
            width: 126px;
            text-align: right;
            height: 49px;
        }
        .auto-style14 {
            text-align: left;
            width: 291px;
            height: 49px;
        }
        .auto-style15 {
            text-align: left;
            width: 374px;
        }
        .auto-style17 {
            text-align: right;
            height: 23px;
            width: 159px;
        }
        .auto-style18 {
            text-align: left;
            height: 23px;
        }
        .auto-style19 {
            text-align: left;
        }
        .auto-style20 {
            text-align: right;
            height: 26px;
            width: 159px;
        }
        .auto-style21 {
            text-align: left;
            height: 26px;
        }
        body {
            background-color: #cfdff9;
            font-family: Calibri;
        } td{
              vertical-align:top;
          }
        .auto-style22 {
            width: 126px;
            text-align: right;
        }
        .auto-style23 {
            width: 159px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style19">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Font-Bold="True" Font-Size="XX-Large" Text="SELL YOUR STUFF"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" Height="23px" OnClick="btnReturn_Click" Text="Return" Width="81px" CausesValidation="False" />
            <br />
            <br />
            <span class="auto-style2">Enter Your Trade Information</span><br />
            <br />
            Select Your Game:<br />
            <asp:DropDownList ID="ddlGame" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlGame_SelectedIndexChanged">
                <asp:ListItem>Please select a game</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <div runat="server" id="tradeForm" visible="false" class="auto-style19">

            <table class="auto-style3">
                <tr>
                    <td class="auto-style5"><strong>Item Name:</strong></td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style15">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtItemName" ErrorMessage="Invalid Item Name" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z!:#\s]*$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please type an item name" ForeColor="Red" ControlToValidate="txtItemName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>Desired Price</strong></td>
                    <td class="auto-style15">$<asp:TextBox ID="txtDesiredPrice" runat="server"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style15">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDesiredPrice" ErrorMessage="Price must be numeric in a regular price format" ForeColor="Red" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please type your desired price" ForeColor="Red" ControlToValidate="txtDesiredPrice"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

        </div>
        <div runat="server" id="tradeFormCurrency" visible="false" class="auto-style19">

            <table class="auto-style7">
                <tr>
                    <td class="auto-style13"><strong>Amount to sell:</strong></td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    &nbsp;<br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount must be numeric with no characters" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Please type an amount to sell" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22"><strong>Currency Type:</strong></td>
                    <td class="auto-style12">
                        <asp:DropDownList ID="ddlCurrencyType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate Price" Width="120px" OnClick="btnCalculate_Click" />
            <br />
            <br />
            <asp:Label ID="labelPayment" runat="server" Text="The Price we pay: " Visible="False"></asp:Label>

            <asp:Label ID="txtPayment" runat="server" Text="Label" Visible="False"></asp:Label>

        </div>
        <div runat="server" id="tradeFormAccounts" visible="false" class="auto-style19">

            Enter information of the account to sell:<br />
            <table class="auto-style9">
                <tr>
                    <td class="auto-style17"><strong>Account Username:</strong></td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUsername" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Please type a username</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUsername" ErrorMessage="Invalid username" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z.@]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20"><strong>Account Password:</strong></td>
                    <td class="auto-style21">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please type a password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Invalid Password" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z!@#$%^&amp;*]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style23"><strong>Detail: </strong></td>
                    <td class="auto-style19">
                        <asp:TextBox ID="txtDetail" runat="server" Width="315px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please type the account detail" ForeColor="Red" ControlToValidate="txtDetail">Please type the account detail</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDetail" ErrorMessage="Invalid Detail" ForeColor="Red" ValidationExpression="^[0-9A-Za-z\s!.?@$\-]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style23"><strong>Desired Price:</strong></td>
                    <td class="auto-style19">$<asp:TextBox ID="txtAccountPrice" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please type your desired price" ForeColor="Red" ControlToValidate="txtAccountPrice">Please type your desired price</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtAccountPrice" ErrorMessage="Invalid Price format" ForeColor="Red" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>

        </div>
        <p class="auto-style19">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnProceed" runat="server" Text="Confirm and Proceed" OnClick="btnProceed_Click" Visible="False" />
        </p>
    </form>
</body>
</html>
