<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscussionList.aspx.cs" Inherits="FinalProject_RMTApp.DiscussionList" %>

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

        table{
            display:inline-block;
        }

        body {
            background-color: #cfdff9;
            text-align: center;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Font-Bold="True" Font-Size="XX-Large" Text="RMT DISCUSSION FORUM"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" />
            <br />
            <br />
        </div>
        <div runat="server" id="discussionList" class="auto-style1">
            <table id="listTable" runat="server">
                <tr>
                    <th>Discussion ID</th>
                    <th>Discussion Title</th>
                    <th>Discussion Owner</th>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:Button ID="btnAddDiscussion" runat="server" OnClick="btnAddDiscussion_Click" Text="Add a discussion" />
            <br />
            <asp:Label ID="labelAdd" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Add a Discussion" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Title:" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="txtTitle" runat="server" BackColor="#3C3C3C" ForeColor="White" Visible="False" Width="299px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Body:" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" BackColor="#3C3C3C" ForeColor="White" Height="160px" TextMode="MultiLine" Visible="False" Width="309px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Visible="False" Width="89px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Visible="False" Width="89px" />
        </div>
    </form>
</body>
</html>
