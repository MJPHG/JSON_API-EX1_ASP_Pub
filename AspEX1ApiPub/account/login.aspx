<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AspEX1ApiPub.account.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" type="text/css" href="/assets/css/pageC.css"/>
</head>
<body>
    <div class="lif">
        <form class="" runat="server">
            <div class="topsp">        
                <asp:Label class="spe" runat="server">Username</asp:Label>
                <div>
                    <asp:TextBox class="spe tbf" ID="usertb" runat="server"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Label class="spe" runat="server">Password</asp:Label>
                <div>
                <asp:TextBox class="spe tbf" ID="passtb" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            </div>
            <div>
                <div>
                <asp:Label class="spe tbf" ID="promptR" runat="server" Font-Bold="False" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                    </div>
                <asp:Button class="spe btnf" ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click"  />
            </div>
        </form>
    </div>
</body>
</html>
