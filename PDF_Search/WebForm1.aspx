<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PDF_Search.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtBoxSearchString"   />
            <asp:Button Text="Search" ID="txtBoxSearchPDF" OnClick="txtBoxSearchPDF_Click" runat="server" />
            <asp:Label Text="" ID="lblNoSearchString" runat="server" />

            <asp:Panel runat="server" ID="Panel1"></asp:Panel>
        </div>
    </form>
</body>
</html>
