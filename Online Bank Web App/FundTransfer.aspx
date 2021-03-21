<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACMasterPage.master" CodeFile="FundTransfer.aspx.cs" Inherits="FundTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Transfer Fund</h1>
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
            <asp:ListItem Value="checking" Selected="True">From Checking to Saving</asp:ListItem> 
            <asp:ListItem Value="saving">From Saving To Checking</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />

    <br />
    <div>
    Deposit Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tranAmount" runat="server" CssClass="input"></asp:TextBox>

    <asp:RequiredFieldValidator ID="depAmountValiadtor" ControlToValidate="tranAmount" runat="server" ErrorMessage="Must be higher than 0" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="Copare1"  ControlToValidate="tranAmount" runat="server" Type="Currency" ValueToCompare="0" Operator="GreaterThan" CssClass="error" ErrorMessage="Must be higher than 0" Display="Dynamic"></asp:CompareValidator>
        <br />
        <br />
    </div>
    
    <br />
    <div>
    <asp:Button ID="depButton" runat="server" Text="Transfer" CssClass="button" OnClick="button_Submit" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="subLabel" runat="server" Text=""></asp:Label>
    </div>



</asp:Content>