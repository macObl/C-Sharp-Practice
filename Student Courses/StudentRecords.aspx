<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRecords.aspx.cs" Inherits="CST8256Lab2.StudentRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Course Information</h1>
            Student ID: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="studentID" runat="server" CssClass="input" Width="116px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="studentID" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
            <br />
            <br />
            Student Name: &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="studentName" runat="server" CssClass="input" Width="116px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="studentName" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regularExpValidator"
                ValidationExpression="[a-zA-Z]+\s+[a-zA-Z]+"
                ControlToValidate ="studentName" CssClass="error"
                Display="Dynamic" ErrorMessage="Must be in first_name last_name!" runat="server"></asp:RegularExpressionValidator>
            <br />
            <br />
            Grade (0-100): &nbsp;&nbsp;&nbsp <asp:TextBox ID="studentGrade" runat="server" CssClass="input" Width="116px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="studentGrade" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="quantityRange" ControlToValidate="studentGrade" runat="server" MinimumValue="1" MaximumValue="100" Type="Integer" Display="Dynamic" ErrorMessage="Must Be Between 1-100"  CssClass="error"></asp:RangeValidator>
            <br />
            <br />
             &nbsp;&nbsp;&nbsp  &nbsp;&nbsp;&nbsp <asp:Button ID="bntAddRecords" runat="server" Text="Add to Course Records" OnClick="btnAddRecords_Click" CssClass="button" Width="208px"/>
            <br />
            <br />
            Following student records have been added:
            <br />
            <br />
            Order By
            <br />
            <asp:RadioButtonList ID="RadioButtonList" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList_SelectedValue">
                <asp:ListItem Value="ID" Selected="True">ID</asp:ListItem>
                <asp:ListItem Value="Name">Name</asp:ListItem>
                <asp:ListItem Value="Grade">Grade</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Table runat="server" ID="tblCourses" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Grade</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
