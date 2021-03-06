<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACMasterPage.master" CodeFile="Withdraw.aspx.cs" Inherits="Withdraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Withdraw Fund</h1>
    <br /> 
    <div>
    Costumer Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:DropDownList ID="customerList" runat="server" OnSelectedIndexChanged="customerList_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem>Select Customer... </asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="customerValiadtor" ControlToValidate="customerList" InitialValue="Select Customer..." runat="server" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
        <br />
    </div>

    <br />
    <div>
    Checking Account Balance:&nbsp;&nbsp;&nbsp; <asp:Label ID="checkingLabel" runat="server" Text=""></asp:Label>
    </div>
    <div>
    Saving Account Balance:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="savingLabel" runat="server" Text=""></asp:Label>
    </div>

    <br />
    <div>
        <asp:RadioButtonList ID="accountList" runat="server" RepeatDirection="Vertical">
            <asp:ListItem Value="checking" Selected="True">To Checking Account</asp:ListItem> 
            <asp:ListItem Value="saving">To Saving Account</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />

    <br />
    <div>
    Deposit Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="withAmount" runat="server" CssClass="input"></asp:TextBox>

    <asp:RequiredFieldValidator ID="withAmountValiadtor" ControlToValidate="withAmount" runat="server" ErrorMessage="Must be higher than 0" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="Copare1"  ControlToValidate="withAmount" runat="server" Type="Currency" ValueToCompare="0" Operator="GreaterThan" CssClass="error" ErrorMessage="Must be higher than 0" Display="Dynamic"></asp:CompareValidator>
        <br />
        <br />
    </div>
    
    <br />
    <div>
    <asp:Button ID="withButton" runat="server" Text="Withdraw" CssClass="button" OnClick="button_Submit" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="subLabel" runat="server" Text=""></asp:Label>
    </div>



</asp:Content>