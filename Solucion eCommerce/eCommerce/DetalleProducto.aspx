<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="eCommerce.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row">

            <!-- Carrusel de imágenes -->
            <div class="col-md-6">
                <asp:Repeater ID="rptImagenes" runat="server">
                    <HeaderTemplate>
                        <div id="carouselProducto" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                            <img src='<%# ResolveUrl(Container.DataItem.ToString()) %>'
                                class="img-fluid d-block mx-auto"
                                style="max-height: 400px;" alt="Imagen del producto" />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselProducto" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon"></span>
                            </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselProducto" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                        </button>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <!-- Detalles del producto -->
            <div class="col-md-6">
                <h2>
                    <asp:Label ID="lblNombre" runat="server" /></h2>
                <h4 class="text-muted">
                    <asp:Label ID="lblMarca" runat="server" /></h4>
                <h3 class="text-success mb-3">$<asp:Label ID="lblPrecio" runat="server" /></h3>
                <p>
                    <strong>Stock:</strong>
                    <asp:Label ID="lblStock" runat="server" />
                </p>
                <p>
                    <strong>Tipo:</strong>
                    <asp:Label ID="lblTipo" runat="server" />
                </p>
                <p>
                    <strong>Fecha de publicación:</strong>
                    <asp:Label ID="lblFecha" runat="server" />
                </p>
                <hr />
                <p>
                    <strong>Descripción:</strong><br />
                    <asp:Label ID="lblDescripcion" runat="server" />
                </p>
                <!-- Botón Comprar -->
                <asp:Button ID="btnAgregarAlCariito" runat="server" Text="Agregar al carrito" CssClass="btn btn-success btn-lg mt-3 w-100" OnClick="btnAgregarAlCarrito_Click" />
            </div>
        </div>

        <!-- Datos del vendedor -->
        <div class="row mt-5 border-top pt-4">
            <div class="col-md-2 text-center">
                <div style="width: 100px; height: 100px; overflow: hidden; border-radius: 50%; margin: auto;">
                    <asp:Image ID="imgVendedor" runat="server" CssClass="w-100 h-100 object-fit-cover" />
                </div>
            </div>
            <div class="col-md-10 d-flex align-items-center">
                <h5 class="mb-0">Vendedor:
                    <asp:Label ID="lblVendedor" runat="server" /></h5>
            </div>
        </div>
    </div>

</asp:Content>

