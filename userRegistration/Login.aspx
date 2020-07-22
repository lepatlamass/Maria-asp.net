<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                 <tr>
                    <td>
                        <asp:Label Text="User Name" runat="server" />

                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUsername" runat="server" />
                        
                    </td>
                  </tr>
                <tr>
                    <td>
                        <asp:Label Text="Password" runat="server" />

                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                    
                    </td>
                  </tr>
           
                 <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Login" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="Incorrect user credential" ID="lblErrorMessage" runat="server" ForeColor="Red"  />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
