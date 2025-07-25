<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="eCommerce.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="mb-4 text-center">Carrito de compras</h2>   

    </div>

    <div class="mb-4 text-center">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
    </div>

    <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
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

                        <asp:Button ID="btnQuitar" runat="server" Text="Quitar" CommandName="Quitar" CommandArgument='<%# Eval("idProducto") %>' CssClass="btn btn-sm btn-danger mt-2" />
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

    <div class="d-flex justify-content-center mt-4">
        <div class="card p-3 shadow-sm" style="max-width: 300px;">
            <h4 class="text-center mb-0">
                <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-primary" />
            </h4>
        </div>
    </div>

   <div class="d-flex justify-content-center mt-4">
        <asp:DropDownList ID="ddlMedioPago" runat="server" CssClass="form-select w-100" style="max-width: 400px;">
            <asp:ListItem Text="Seleccione un medio de pago" Value="" />
            <asp:ListItem Text="Tarjeta" Value="Tarjeta" />
            <asp:ListItem Text="Mercado Pago" Value="MercadoPago" />
            <asp:ListItem Text="Efectivo" Value="Efectivo" />
        </asp:DropDownList>
    </div>

    <div class="mb-4 text-center">
        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-success" OnClick="btnFinalizarCompra_Click" />
    </div>

    

</asp:Content>
