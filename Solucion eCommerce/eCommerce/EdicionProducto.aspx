<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="EdicionProducto.aspx.cs" Inherits="eCommerce.EdicionProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5">
    <div class="row justify-content-center">
        <div class="col-md-8 bg-white shadow p-4 rounded">
            <h3 class="text-center mb-4">Editar Producto</h3>

            <!-- Nombre -->
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre" />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <!-- Marca -->
            <div class="mb-3">
                <asp:Label ID="lblMarca" runat="server" Text="Marca:" AssociatedControlID="txtMarca" />
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <!-- Tipo -->
            <div class="mb-3">
                <asp:Label ID="lblTipo" runat="server" Text="Tipo:" AssociatedControlID="txtTipo" />
                <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <!-- Precio -->
            <div class="mb-3">
                <asp:Label ID="lblPrecio" runat="server" Text="Precio:" AssociatedControlID="txtPrecio" />
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <!-- Stock -->
            <div class="mb-3">
                <asp:Label ID="lblStock" runat="server" Text="Stock:" AssociatedControlID="txtStock" />
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <!-- Descripción -->
            <div class="mb-3">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" AssociatedControlID="txtDescripcion" />
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" ReadOnly="true" />
            </div>

            <!-- Descuento -->
            <div class="mb-3">
                <asp:Label ID="lblDescuento" runat="server" Text="Descuento (%):" AssociatedControlID="txtDescuento" />
                <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <!-- Imágenes -->
            <div class="mb-3">
                <asp:Label ID="lblImagenes" runat="server" Text="Imágenes:" />
                <asp:Repeater ID="rptImagenes" runat="server">
                    <ItemTemplate>
                        <div style="display: inline-block; width: 150px; margin: 10px; border: 1px solid #ccc; border-radius: 8px; text-align: center; vertical-align: top;">
                            <div style="width: 100%; height: 150px; overflow: hidden;">
                                <img src='<%# Container.DataItem.ToString() %>' style="width: 100%; height: 100%; object-fit: contain;" />
                            </div>
                            <<asp:Button ID="btnEliminarImagen" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm mt-2"
                                CommandArgument='<%# Container.DataItem.ToString() %>' OnClick="btnEliminarImagen_Click" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            

        </div>
    </div>
</div>
</asp:Content>
