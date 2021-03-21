<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CST8256Lab2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Information</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Course Information</h1>

            <asp:Label ID="Label1" runat="server" Text="Course Number: "></asp:Label>&nbsp;&nbsp;&nbsp
            <asp:textbox  ID="cNumber" runat="server" CssClass="input" Width="116px"></asp:textbox>

            <asp:RequiredFieldValidator runat="server" ControlToValidate="cNumber" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="Course Name: "></asp:Label>&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp
            <asp:textbox ID="cName" runat="server" CssClass="input" Width="116px"></asp:textbox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="cName" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp<asp:Button ID="btnAddCourse" runat="server" Text="Submit Course Inforamtion" OnClick="btnAddCourse_Click"  CssClass="button" Width="208px"/>
        </div>
    </form>
</body>
</html>
