<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="ListaVentas.aspx.cs" Inherits="eCommerce.ListaVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped mt-4" OnRowCommand="gvPedidos_RowCommand">
    <Columns>
        <asp:BoundField DataField="idPedido" HeaderText="Pedido #" />
        <asp:BoundField DataField="fechaPedido" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="estado" HeaderText="Estado" />
        <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="${0:N2}" />
        <asp:BoundField DataField="nombreTipoPago" HeaderText="Medio de Pago" />
        <asp:BoundField DataField="entrega" HeaderText="Entrega" />

        <asp:TemplateField HeaderText="Seguimiento">
            <ItemTemplate>
                <asp:Button ID="btnSeguimiento" runat="server" Text="Ver" CssClass="btn btn-primary btn-sm"
                    CommandName="VerSeguimiento" CommandArgument='<%# Eval("idPedido") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>
