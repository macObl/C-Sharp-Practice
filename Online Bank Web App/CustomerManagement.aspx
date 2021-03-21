<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="CustomerManagement.aspx.cs" Inherits="CustomerManagement" EnableSessionState="True" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Customer Management</h1>
    <br />
    Costumer Name:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtName" runat="server" Width="183px" CssClass="input"></asp:TextBox>
    <asp:RequiredFieldValidator ID="NameValidator" ControlToValidate ="txtName" runat="server" ErrorMessage="Required!" CssClass="error"></asp:RequiredFieldValidator>
     <br />
    <br />
    
     Initial Deposit:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="initialDeposit" runat="server" Width="183px" CssClass="input"></asp:TextBox>

    <asp:RequiredFieldValidator ID="initalValiadtor" ControlToValidate="initialDeposit" runat="server" ErrorMessage="Must be higher than 0" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="Copare1"  ControlToValidate="initialDeposit" runat="server" Type="Currency" ValueToCompare="0" Operator="GreaterThan" CssClass="error" ErrorMessage="Must be higher than 0"  Display="Dynamic"></asp:CompareValidator>
    
    <div>
        <br />
        <asp:Button CssClass="button" runat="server" Text="Add Customer"  OnClick="button_Submit" />
    </div>
    <br />
    <h2>The following customers are currently in the system:</h2>
    <br /> 
    <asp:Table ID="Table" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Checking Account Balance</asp:TableHeaderCell>
                <asp:TableHeaderCell>Saving Account Balance</asp:TableHeaderCell>
                <asp:TableHeaderCell>Status</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>


</asp:Content>