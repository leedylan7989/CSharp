<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIscussion.aspx.cs" Inherits="FinalProject_RMTApp.DIscussion" %>

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
            width: 99px;
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
        <asp:Label ID="Label1" runat="server" Text="Discussion" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <div id="discussionDiv" runat="server" class="auto-style2">
        </div>
        <hr />
        <div id="replyList" runat="server" class="auto-style2">

        </div>
        <hr />
        <div id="reply" runat="server" class="auto-style2">

            <asp:TextBox ID="TextBox1" runat="server" BackColor="#3C3C3C" ForeColor="White" Height="145px" TextMode="MultiLine" Width="486px"></asp:TextBox>

            <br />
            <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Reply" Width="110px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Reset1" class="auto-style3" type="reset" value="reset" /></div>
        </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnReturn" runat="server" OnClick="Button2_Click" Text="Return" />
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
