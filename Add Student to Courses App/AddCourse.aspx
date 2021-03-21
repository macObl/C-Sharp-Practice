<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACMasterPage.master" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add New Courses</h1>
    Course Number: &nbsp;&nbsp;&nbsp<asp:TextBox ID="courseNumber" runat="server" CssClass="input" Width="170px"></asp:TextBox>
    <asp:Label  runat="server" ID="lblError" CssClass="error"></asp:Label>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="courseNumber" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
    <br />
    <br />
    Course Name:&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp<asp:TextBox ID="courseName" runat="server" CssClass="input" Width="171px"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="courseName" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp<asp:Button ID="btnAddCourse" runat="server" Text="Submit Course Information" OnClick="btnSubmit_Click" CssClass="button" />
    <br />
    <br />
    <asp:Panel runat="server" ID="courses">
        <asp:Table ID="Table" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell><a href="AddCourse.aspx?sort=code">Code</a></asp:TableHeaderCell>
                <asp:TableHeaderCell><a href="AddCourse.aspx?sort=title">Code Title</a></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>



</asp:Content>