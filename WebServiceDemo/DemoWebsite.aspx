<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoWebsite.aspx.cs" Inherits="WebServiceDemo.DemoWebsite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="First Name:" runat="server" />
            <asp:TextBox runat="server" ID="TextBoxName" />
            <hr />
            <asp:Button Text="Click Me" runat="server" ID="ButtonClickMe" OnClick="ButtonClickMe_Click" />
            <hr />
            <asp:Label Text="" runat="server" ID="LabelWelcomeMessage" />
        </div>
    </form>
</body>
</html>
