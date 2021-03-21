<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="App_Themes/SiteStyles.css" />
    <style type="text/css">
        #Button1 {
        }
        #form1 {
            height: 327px;
        }
    </style>
</head>
<body>
    <h1>Algonquin College Course Registration</h1>
    <asp:Panel runat="server" ID="Regestration"> 
        <form id="form1" runat="server">
            <div style="float:left">
            Student Name:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" Width="183px" CssClass="input"></asp:TextBox>
            </div>
            <div style="float:left">
                <asp:RadioButtonList ID="studentType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="full-time" Selected="True">Full Time</asp:ListItem> 
                    <asp:ListItem Value="part-time">Part Time</asp:ListItem>
                    <asp:ListItem Value="co-op">Co-op</asp:ListItem>
                </asp:RadioButtonList>
            </div>
    &nbsp;
        
            <p>Follwing courses are currently available for registration</p>
            
            <asp:Label ID="error" runat="server" CssClass="emphsis"></asp:Label>
            <asp:CheckBoxList ID="liCourses" runat="server">
            </asp:CheckBoxList>
        
            
           <asp:Button runat="server" ID="submit" OnClick="Submit_Click" Height="32px" Text="Submit" Width="80px" CssClass="button" />
            

        </form>
    </asp:Panel>

    <asp:Panel runat="server" ID="Results">

        <p>Thank you <asp:Label ID="Name" runat="server" CssClass="emphsis"></asp:Label>, for using our online regisration system</p>
        <p>You have been registered as a <asp:Label ID="Type" runat="server" CssClass="distinct"></asp:Label> for the following courses</p>
        <br />
        <asp:Table ID="Table" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Title</asp:TableHeaderCell>
                <asp:TableHeaderCell>Weekly Hours</asp:TableHeaderCell>
                <asp:TableHeaderCell>Fee Payable</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>
    </body>

</html>
