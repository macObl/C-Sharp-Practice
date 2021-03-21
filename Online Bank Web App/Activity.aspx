<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACMasterPage.master" CodeFile="Activity.aspx.cs" Inherits="Activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Account Activities</h1>
    <br /> 
    <div>
    Costumer Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:DropDownList ID="customerList" runat="server" OnSelectedIndexChanged="customerList_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem>Select Customer... </asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="customerValiadtor" ControlToValidate="customerList" InitialValue="Select Customer..." runat="server" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    </div>

    <asp:Panel runat="server" ID="checking">
        <asp:Table ID="checkingTable" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                <asp:TableHeaderCell>Transaction Type</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

    <asp:Panel runat="server" ID="saving">
        <asp:Table ID="savingTable" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                <asp:TableHeaderCell>Transaction Type</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>
</asp:Content>
