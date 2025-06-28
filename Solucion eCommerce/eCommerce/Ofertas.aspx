<%@ Page Title="Ofertas" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Ofertas.aspx.cs" Inherits="eCommerce.Ofertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="text-center mb-4">Productos en Oferta</h2>
        <div class="row">
            <asp:Repeater ID="rptOfertas" runat="server" OnItemDataBound="rptOfertas_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <a href='<%# "DetalleProducto.aspx?id=" + Eval("idProducto") %>' style="text-decoration: none; color: inherit;">
                            <div class="card shadow h-100">
                                <div class="card-header text-center bg-primary text-white">
                                    <%# Eval("nombre") + " - " + Eval("marca") %>
                                </div>
                                <div class="card-body p-0">
                                    <div id='carouselOferta<%# Eval("idProducto") %>' class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                                        <div class="carousel-inner">
                                            <asp:Repeater ID="rptImagenes" runat="server">
                                                <ItemTemplate>
                                                    <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                        <img src='<%# ResolveUrl(Container.DataItem.ToString()) %>' class="img-fluid w-100 object-fit-contain" style="height: 200px;" alt="Imagen Producto" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <button class="carousel-control-prev" type="button" data-bs-target='#carouselOferta<%# Eval("idProducto") %>' data-bs-slide="prev">
                                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                            <span class="visually-hidden">Anterior</span>
                                        </button>
                                        <button class="carousel-control-next" type="button" data-bs-target='#carouselOferta<%# Eval("idProducto") %>' data-bs-slide="next">
                                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                            <span class="visually-hidden">Siguiente</span>
                                        </button>
                                    </div>
                                </div>
                                <div class="card-footer text-center">
                                    <span class="text-muted text-decoration-line-through me-2">$<%# Eval("precio") %></span>
                                    <span class="text-success fw-bold">
                                        <%# "$" + (Convert.ToDecimal(Eval("precio")) * (1 - Convert.ToInt32(Eval("descuento")) / 100m)).ToString("0.00") %>
                                    </span>
                                    <br />
                                    <span class="badge bg-danger mt-1"><%# Eval("descuento") %>% OFF</span>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
