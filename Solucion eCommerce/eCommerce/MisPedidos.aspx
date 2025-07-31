<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="eCommerce.MisPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
    <div class="row">      
                
        <div class="col-md-7 mx-auto">
            <h4 class="mb-3 text-center">Mis pedidos</h4>
            <asp:Repeater ID="rptPedidos" runat="server" OnItemDataBound="rptPedidos_ItemDataBound">
                <ItemTemplate>
                    <div class="card my-2">
                        <div class="card-header" data-bs-toggle="collapse" href='<%# "#collapse" + Eval("idPedido") %>' style="cursor: pointer" aria-expanded="false" aria-controls='<%# "collapse" + Eval("idPedido") %>'>
                            Pedido #<%# Eval("idPedido") %> - <%# Eval("fechaPedido", "{0:dd/MM/yyyy}") %> - Total: $<%# Eval("total")%> - Medio de pago: <%# Eval("nombreTipoPago") %>
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
