<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication2.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://kit.fontawesome.com/06bbb10d94.js" crossorigin="anonymous"></script>
    <link href="Content/CartStyleSheet.css" rel="stylesheet" />
    <div class="header">
        <h2><i class="fa-solid fa-bag-shopping"></i>My Cart</h2>
    </div>
    <div class="row">
        <div class="col-lg-8">
            <hr />
            <div class="cardItems">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        &nbsp
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-2">
                                        <img src="Uploaded/<%#DataBinder.Eval(Container,"DataItem.Title") %>-<%#DataBinder.Eval(Container,"DataItem.Author") %>.jpeg" alt="Alternate Text" style="width: 7rem;" />
                                    </div>
                                    <div class="col">
                                        <h3><%#DataBinder.Eval(Container,"DataItem.Title") %></h3>
                                        <h6><%#DataBinder.Eval(Container,"DataItem.Author") %></h6>
                                        <p>Price: <%#DataBinder.Eval(Container,"DataItem.Price") %></p>
                                    </div>
                                    <div class="col">
                                        <asp:Button Text="Remove" ID="Remove" CssClass="btn btn-danger" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>

        </div>
        <div class="col-1">
        </div>
        <div class="col">
            <hr />
            <div class="cardItem">
                <asp:Label Text="Add PromoCode" runat="server" />
            </div>
            <div class="row">
                <div class="col" style="padding-left: 1rem; padding-right: 0;">
                    <asp:TextBox runat="server" ID="txt_Promo" CssClass="promo" />
                </div>
                <div class="col" style="padding: 0">
                    <asp:Button Text="Check" runat="server" CssClass="btn btn-dark btnPromo" ID="Promo" OnClick="Promo_Click" />
                </div>
            </div>
            <div class="ChecoutItems">
                <label>Shipping Coast</label>
                <asp:Label ID="txt_Shipping"  Text="12$" runat="server" />
            </div>
            <div class="ChecoutItems">
                <label>Discount</label>
                <asp:Label Text="-0$"  ID="txt_Discount" runat="server" />
            </div>
            <div class="ChecoutItems">
                <label>Tax</label>
                <asp:Label Text="12$" ID="txt_Tax" runat="server" />
            </div>
            <div class="ChecoutItems">
                <label>Total</label>
                <asp:Label Text="120$" ID="txt_Total" runat="server" />
            </div>
            <div>
                <asp:Button Text="Checkout" runat="server" CssClass="btn btn-warning btnCheckout" ForeColor="white" />
            </div>
        </div>
    </div>
</asp:Content>
