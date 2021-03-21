<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookStore.aspx.cs" Inherits="BookStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <h1>Online Book Store</h1>
    <form id="form1" runat="server">
        <a  href="ShoppingCartView.aspx">View Cart</a> (<asp:Label runat="server" ID="lblNumItems"></asp:Label>) <br /><br />
        <asp:DropDownList  ID="drpBookSelection" runat="server" CssClass="dropdown" 
            OnSelectedIndexChanged="drpBookSelection_SelectedIndexChanged" AutoPostBack="true" >
            <asp:ListItem Value="-1">Select a Book ... </asp:ListItem>
        </asp:DropDownList><br />
        
        <%-- todo: Add Required Field Validator --%>
        <asp:RequiredFieldValidator ID="bookValiadtor" ControlToValidate="drpBookSelection" InitialValue="-1" runat="server" ErrorMessage="Must Select One" CssClass="error"></asp:RequiredFieldValidator>
              
        <div class="description">
            <asp:Label runat="server" ID="lblDescription"></asp:Label>
        </div>
        <br />
        <span class="emphsis">Price: </span><asp:Label runat="server" ID="lblPrice" CssClass="Price" ></asp:Label>                
        <span class="emphsis">Quantity: </span><asp:TextBox runat="server" ID="txtQuantity" cssclass="input"/>
        
        <%-- todo: Add Required Field Validator --%>
        <asp:RequiredFieldValidator ID="quantityValidator" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
        <%-- todo: Add Range Validator --%>
        <asp:RangeValidator ID="quantityRange" ControlToValidate="txtQuantity" runat="server" MinimumValue="1" MaximumValue="3" Type="Integer" ErrorMessage="Must Be Between 1-3"  CssClass="error"></asp:RangeValidator>

        <br /><br /><asp:Button runat="server" ID="btnAddToCart" Text="Add to Cart" cssclass="button" OnClick="btnAddToCart_Click"/>
    </form>  
</body>
</html>

