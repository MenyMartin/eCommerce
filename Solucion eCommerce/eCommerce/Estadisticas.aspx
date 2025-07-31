<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="eCommerce.Estadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="card mt-4 p-3">
    <div class="d-flex align-items-center">
        <asp:Image ID="imgFotoPerfil" runat="server" CssClass="rounded-circle" Width="100px" Height="100px" Style="object-fit:cover;" />
        <div class="ms-4">
            <h4><asp:Label ID="lblNombre" runat="server" /></h4>
            <p><asp:Label ID="lblDNI" runat="server" /></p>
            <p><asp:Label ID="lblEmail" runat="server" /></p>
            <p><asp:Label ID="lblDireccion" runat="server" /></p>
            <p><asp:Label ID="lblEdad" runat="server" /></p>
            <p><asp:Label ID="lblFechaRegistro" runat="server" /></p>
        </div>
    </div>
</div>

<div class="card mt-4 p-3 bg-light">
    <h5>Estadísticas</h5>
    <ul class="list-group list-group-flush">
        <li class="list-group-item">Dinero Gastado: <strong><asp:Label ID="lblDineroGastado" runat="server" /></strong></li>
        <li class="list-group-item">Pedidos Realizados: <strong><asp:Label ID="lblPedidosRealizados" runat="server" /></strong></li>
        <li class="list-group-item">Productos Pedidos: <strong><asp:Label ID="lblProductosPedidos" runat="server" /></strong></li>
        <li class="list-group-item">Producto Más Pedido: <strong><asp:Label ID="lblProductoMasPedido" runat="server" /></strong></li>
    </ul>
</div>

</asp:Content>
