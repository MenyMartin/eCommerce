<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="eCommerce.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="mb-4 text-center">Carrito de compras</h2>   

    </div>

    <asp:Repeater ID="rptCarrito" runat="server">
    <ItemTemplate>
        <div class="card mb-3 mx-auto" style="max-width: 540px;">
            <div class="row g-0 align-items-center">
                <div class="col-md-4">
                    <img src='<%# Eval("ImagenURL") %>' class="img-fluid rounded-start" alt="Producto" style="max-height: 120px; object-fit: contain;" />
                </div>
                <div class="col-md-8">
                    <div class="card-body p-2">
                        <h5 class="card-title mb-1" style="font-size: 1rem;"><%# Eval("Nombre") %> - <%# Eval("Marca") %></h5>
                        <p class="card-text mb-1" style="font-size: 0.9rem;">Cantidad: <%# Eval("Cantidad") %></p>
                        <p class="card-text mb-1" style="font-size: 0.9rem;">Precio unitario: $<%# Eval("PrecioUnitario", "{0:0.00}") %></p>
                        <p class="card-text mb-0 fw-bold" style="font-size: 0.9rem;">Subtotal: $<%# Eval("Subtotal", "{0:0.00}") %></p>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<h4 class="text-end mt-4"><asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-primary" /></h4>
    <div class="text-end mt-3">
        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-success" OnClick="btnFinalizarCompra_Click" />
    </div>
</asp:Content>
