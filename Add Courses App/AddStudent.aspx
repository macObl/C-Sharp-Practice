<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACMasterPage.master" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Student Records</h1>
    Course:&nbsp;&nbsp;&nbsp <asp:DropDownList ID="courseList" runat="server" CssClass="dropdown" OnSelectedIndexChanged="courseList_SelectedIndexChanged" AutoPostBack="true">
       
                             </asp:DropDownList>
    <br />
    <br />
    <br />
    Student Number: &nbsp;&nbsp;&nbsp<asp:TextBox ID="number" runat="server" CssClass="input"></asp:TextBox>
    <br />
   <br />
    Student Name: &nbsp;&nbsp;&nbsp; &nbsp;&nbsp<asp:TextBox ID="name" runat="server" CssClass="input"></asp:TextBox>
    <br />
    <br />
    Grade: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="grade" runat="server" CssClass="input"></asp:TextBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp<asp:Button ID="btnAddStudent" runat="server" Text="Submit Course Information" OnClick="btnAddStudent_OnClick"  CssClass="button" />
    <br />
    <br />
    <asp:Panel runat="server" ID="studentNameIDGrade">
        <asp:Table ID="Table" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell><a href="AddStudent.aspx?sort=id">ID</a></asp:TableHeaderCell>
                <asp:TableHeaderCell><a href="AddStudent.aspx?sort=name">Name</a></asp:TableHeaderCell>
                <asp:TableHeaderCell><a href="AddStudent.aspx?sort=grade">Grade</a></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
