<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="eCommerce.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">
            <!-- Columna de perfil (izquierda) -->
            <div class="col-md-5 text-center">
                <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle mb-4" Style="width: 180px; height: 180px; object-fit: cover;" />

                <div class="card shadow">
                    <div class="card-body">
                        <h4 class="card-title mb-4">Mi Perfil</h4>

                        <p><strong>Nombre:</strong>
                            <asp:Label ID="lblNombre" runat="server" CssClass="text-muted" /></p>
                        <p><strong>Apellido:</strong>
                            <asp:Label ID="lblApellido" runat="server" CssClass="text-muted" /></p>
                        <p><strong>DNI:</strong>
                            <asp:Label ID="lblDNI" runat="server" CssClass="text-muted" /></p>
                        <p><strong>Edad:</strong>
                            <asp:Label ID="lblEdad" runat="server" CssClass="text-muted" /></p>
                        <p><strong>Dirección:</strong>
                            <asp:Label ID="lblDireccion" runat="server" CssClass="text-muted" /></p>
                        <p><strong>Email:</strong>
                            <asp:Label ID="lblEmail" runat="server" CssClass="text-muted" /></p>
                        <p><strong>Contraseña:</strong>
                            <asp:Label ID="lblPassword" runat="server" CssClass="text-muted" /></p>
                        <p><strong>Fecha de registro:</strong>
                            <asp:Label ID="lblFechaRegistro" runat="server" CssClass="text-muted" /></p>

                        <asp:Button ID="btnPanelAdmin" runat="server" Text="Panel de administrador" OnClick="btnPanelAdmin_Click" Visible="false" CssClass="btn btn-primary mt-2" />

                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" CssClass="btn btn-danger mt-3 w-100" OnClick="btnCerrarSesion_Click" />
                    </div>
                </div>
            </div>

            <!-- Columna de pedidos (derecha) -->
            <div class="col-md-7">
                <h4 class="mb-3">Mis pedidos</h4>
                <asp:Repeater ID="rptPedidos" runat="server" OnItemDataBound="rptPedidos_ItemDataBound">
                    <ItemTemplate>
                        <div class="card my-2">
                            <div class="card-header" data-bs-toggle="collapse" href='<%# "#collapse" + Eval("idPedido") %>' style="cursor: pointer" aria-expanded="false" aria-controls='<%# "collapse" + Eval("idPedido") %>'>
                                Pedido #<%# Eval("idPedido") %> - <%# Eval("fechaPedido", "{0:dd/MM/yyyy}") %> - Total: $<%# Eval("total") %>
                            </div>
                            <div id='<%# "collapse" + Eval("idPedido") %>' class="collapse">
                                <div class="card-body">
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
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
