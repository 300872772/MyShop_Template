<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Pages_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlShoppingCart" runat="server">


    </asp:Panel>

    <table>
        <tr>
            <td> <b>Total:   </b></td>
            <td><asp:Literal ID="litTotal" runat="server" Text="" /></td>
        </tr>

        <tr>
            <td> <b>Tax:   </b></td>
            <td><asp:Literal ID="litTax" runat="server" Text="" /></td>
        </tr>

         <tr>
            <td> <b>Shipping:   </b></td>
            <td><asp:Literal ID="litShipping" runat="server" Text="$ 15" /></td>
        </tr>

        <tr>
            <td> <b>Total Amount:   </b></td>
            <td><asp:Literal ID="litTotalamount" runat="server" Text="" /></td>
        </tr>

        <tr>
            <td> <asp:Button ID="lnkContinue" runat="server" PostBackUrl ="~/Index.aspx" 
                Text="Continue Shopping" CssClass="button3"></asp:Button>

                OR
                <asp:Button ID="btnCheckOut" runat="server" PostBackUrl ="~/Pages/Success.aspx" 
                CssClass="button1"  Text="Continue Checkout" />

            </td>
            
        </tr>
    </table>

</asp:Content>

