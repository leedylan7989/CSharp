<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FinalProject_RMTApp.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style6 {
            text-align: right;
            width: 96px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            height: 23px;
            text-align: right;
            width: 103px;
        }
        .auto-style11 {
            text-align: center;
            height: 60px;
        }
        .auto-style12 {
            text-align: right;
            width: 103px;
        }
        .auto-style13 {
            width: 104px;
        }body {
            background-color: #cfdff9;
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style5">
            <div class="auto-style11">
                <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Font-Bold="True" Font-Size="XX-Large" Text="USER REGISTRATION"></asp:Label>
                <br />
                <br />
            </div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Account Information"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">Username:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtUsername" runat="server" Width="190px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username must contain only alphanumeric characters" ForeColor="Red" ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Password:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtPassword" runat="server" Width="190px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password should contain only alphanumeric characters, &amp;, #, $, @, and *" ForeColor="Red" ValidationExpression="^[0-9A-Za-z&amp;*#@$]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </div>
        <p class="auto-style5">
            <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Personal Information"></asp:Label>
        </p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">First Name:</td>
                <td>
                    <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstname" ErrorMessage="First name cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Last Name:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLastname" ErrorMessage="Last name cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <p class="auto-style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Register" Width="107px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Reset1" class="auto-style13" type="reset" value="reset" /></p>
        <p class="auto-style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" Width="107px" />
        </p>
    </form>
</body>
</html>
