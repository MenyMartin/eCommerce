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
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <!-- Marca -->
                <div class="mb-3">
                    <asp:Label ID="lblMarca" runat="server" Text="Marca:" AssociatedControlID="txtMarca" />
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
                </div>

                <!-- Tipo -->
                <div class="mb-3">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" AssociatedControlID="txtTipo" />
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" />
                </div>

                <!-- Precio -->
                <div class="mb-3">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio:" AssociatedControlID="txtPrecio" />
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                </div>

                <!-- Stock -->
                <div class="mb-3">
                    <asp:Label ID="lblStock" runat="server" Text="Stock:" AssociatedControlID="txtStock" />
                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" />
                </div>

                <!-- Descripción -->
                <div class="mb-3">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" AssociatedControlID="txtDescripcion" />
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                </div>

                <!-- Descuento -->
                <div class="mb-3">
                    <asp:Label ID="lblDescuento" runat="server" Text="Descuento (%):" AssociatedControlID="txtDescuento" />
                    <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control" />
                </div>

                <!-- Carga de Imágenes -->
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

                <!-- URLs de imágenes -->
                <div class="mb-3">
                    <label class="form-label">URLs de imágenes del producto</label><br />

                    <asp:TextBox ID="txtFoto1" runat="server" CssClass="form-control mb-2" placeholder="Nuevo url imagen" />
                    <asp:RequiredFieldValidator ID="valFoto1" runat="server"
                        ControlToValidate="txtFoto1"
                        ErrorMessage="Debe ingresar al menos una URL de imagen"
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <asp:TextBox ID="txtFoto2" runat="server" CssClass="form-control mb-2" placeholder="Nuevo url imagen" />
                    <asp:TextBox ID="txtFoto3" runat="server" CssClass="form-control mb-2" placeholder="Nuevo url imagen" />

                    <div id="contenedorFotosExtras"></div>

                    <button type="button" id="btnAgregarFoto" class="btn btn-sm btn-outline-primary mt-2">+ Agregar otra foto</button>
                </div>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" HeaderText="Errores:" />

                <script>
                    let contadorFotos = 3;

                    document.getElementById('btnAgregarFoto').addEventListener('click', function () {
                        contadorFotos++;

                        const contenedor = document.getElementById('contenedorFotosExtras');

                        const nuevoInput = document.createElement('input');
                        nuevoInput.type = 'text';
                        nuevoInput.name = 'fotoExtra' + contadorFotos;
                        nuevoInput.className = 'form-control mb-2';
                        nuevoInput.placeholder = 'https://... (opcional)';

                        contenedor.appendChild(nuevoInput);
                    });
                </script>

                <div class="mb-3 text-center">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
