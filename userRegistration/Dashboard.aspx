<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUserDetails" Text="" runat="server" />
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="LogOut" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
