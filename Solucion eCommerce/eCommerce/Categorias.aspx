<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="eCommerce.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="mb-4 text-center">
            <asp:Label ID="lblTitulo" runat="server" />
        </h2>

        <div class="row">
            <asp:Repeater ID="rptProductos" runat="server" OnItemDataBound="rptProductos_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <a href='<%# "DetalleProducto.aspx?id=" + Eval("idProducto") %>' style="text-decoration: none; color: inherit;">
                            <div class="card shadow h-100">
                                <div class="card-header text-center bg-primary text-white">
                                    <%# Eval("nombre") + " - " + Eval("marca") %>
                                </div>
                                <div class="card-body p-0">
                                    <div id='carouselCard<%# Eval("idProducto") %>' class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                                        <div class="carousel-inner">
                                            <asp:Repeater ID="rptImagenes" runat="server">
                                                <ItemTemplate>
                                                    <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                        <img src='<%# ResolveUrl(Container.DataItem.ToString()) %>' class="img-fluid w-100 object-fit-contain" style="height: 200px;" alt="Imagen Producto" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <button class="carousel-control-prev" type="button" data-bs-target='#carouselCard<%# Eval("idProducto") %>' data-bs-slide="prev">
                                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                            <span class="visually-hidden">Anterior</span>
                                        </button>
                                        <button class="carousel-control-next" type="button" data-bs-target='#carouselCard<%# Eval("idProducto") %>' data-bs-slide="next">
                                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                            <span class="visually-hidden">Siguiente</span>
                                        </button>
                                    </div>
                                </div>
                                <div class="card-footer text-muted text-center">
                                    <%# "$" + Eval("precio") %>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>