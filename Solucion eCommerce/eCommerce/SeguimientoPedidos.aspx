<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="SeguimientoPedidos.aspx.cs" Inherits="eCommerce.SeguimientoPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfIdPedido" runat="server" />
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <h4 class="mb-3 text-center">Seguimiento del pedido</h4>

                <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-success d-none" />

                <asp:Panel ID="pnlPedido" runat="server" CssClass="card">
                    <div class="card-header">
                        <asp:Label ID="lblEncabezado" runat="server" />
                    </div>
                    <div class="card-body">
                        <p><strong>Cliente:</strong>
                            <asp:Label ID="lblCliente" runat="server" /></p>
                        <p><strong>Fecha:</strong>
                            <asp:Label ID="lblFecha" runat="server" /></p>
                        <p><strong>Total:</strong> $<asp:Label ID="lblTotal" runat="server" /></p>
                        <p><strong>Medio de pago:</strong>
                            <asp:Label ID="lblTipoPago" runat="server" /></p>
                        <p><strong>Tipo de entrega:</strong>
                            <asp:Label ID="lblEntrega" runat="server" /></p>
                        <%--estado y su desplegable--%>
                        <div class="d-flex align-items-center mb-3">
                            <p class="mb-0 me-2"><strong>Estado:</strong></p>
                            <asp:Label ID="lblEstado" runat="server" CssClass="me-4" />

                            <asp:Label ID="lblCambiar" runat="server" Text="Cambiar estado:" CssClass="me-2" />
                            <asp:DropDownList ID="ddlEstadoNuevo" runat="server" CssClass="form-select me-2" Width="150px">
                                <asp:ListItem Text="Procesado" Value="Procesado" />
                                <asp:ListItem Text="Enviado" Value="Enviado" />
                                <asp:ListItem Text="Entregado" Value="Entregado" />
                            </asp:DropDownList>

                            <asp:Button ID="btnCambiarEstado" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnCambiarEstado_Click" />
                        </div>

                        <hr />
                        <h5>Productos del pedido</h5>
                        <asp:Repeater ID="rptDetalles" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between border-bottom py-1">
                                    <div><strong>Producto:</strong> <%# Eval("nombreProducto") %> - <%# Eval("marcaProducto") %></div>
                                    <div><strong>Cantidad:</strong> <%# Eval("cantidad") %></div>
                                    <div><strong>Subtotal:</strong> $<%# Eval("subtotal", "{0:0.00}") %></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>
