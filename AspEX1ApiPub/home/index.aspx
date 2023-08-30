<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AspEX1ApiPub.home.index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/assets/css/pageC.css"/>
</head>
<body>
    <div>
        <form class="" runat="server">
        <div class="nava">
            <asp:panel runat="server">
            <asp:LinkButton class=" btnf cntxt" ID="logoutbtn" runat="server" Font-Size="Small" OnClick="logoutbtn_Click">Logout</asp:LinkButton>
            </asp:panel>
            <asp:Label class=" btnf blktc" ID="usernamedisplay" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label>
           
        </div>
        <div>
        
            <asp:TreeView ID="TV1" class="wtxtf" runat="server" BorderStyle="None" ForeColor="White" LineImagesFolder="~/TreeLineImages" ShowLines="True" Width="180px">
                <NodeStyle BorderStyle="None" Font-Names="Arial" Font-Underline="False" />
            </asp:TreeView>
        
        </div>
        </form>
    </div>
</body>
</html>
