<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="AltaProducto.aspx.cs" Inherits="eCommerce.Vender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <h1 class="text-center mb-4">Ventas del usuario</h1>

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-8 bg-white shadow p-4 rounded">
                <h3 class="text-center mb-4">Cargar Producto</h3>

                <!-- Nombre -->
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre del producto</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="valNombre" runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>

                <!-- Marca -->
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="valMarca" runat="server"
                        ControlToValidate="txtMarca"
                        ErrorMessage="La marca es obligatoria"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>

                <!-- Tipo -->
                <div class="mb-3">
                    <label for="txtTipo" class="form-label">Tipo / Categoría</label>
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="valTipo" runat="server"
                        ControlToValidate="txtTipo"
                        ErrorMessage="El tipo es obligatorio"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>

                <!-- Precio -->
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ID="valPrecio" runat="server"
                        ControlToValidate="txtPrecio"
                        ErrorMessage="El precio es obligatorio"
                        CssClass="text-danger"
                        Display="Dynamic" />
                    <asp:RangeValidator ID="valRangoPrecio" runat="server"
                        ControlToValidate="txtPrecio"
                        MinimumValue="1"
                        MaximumValue="999999"
                        Type="Double"
                        ErrorMessage="El precio debe ser mayor a 0"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>

                <!-- Stock -->
                <div class="mb-3">
                    <label for="txtStock" class="form-label">Stock</label>
                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ID="valStock" runat="server"
                        ControlToValidate="txtStock"
                        ErrorMessage="El stock es obligatorio"
                        CssClass="text-danger"
                        Display="Dynamic" />
                    <asp:RangeValidator ID="valRangoStock" runat="server"
                        ControlToValidate="txtStock"
                        MinimumValue="0"
                        MaximumValue="1000000"
                        Type="Integer"
                        ErrorMessage="Stock inválido"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>

                <!-- Descripción -->
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                </div>

                <!-- Descuento -->
                <div class="mb-3">
                    <label for="txtDescuento" class="form-label">Descuento (%)</label>
                    <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control" TextMode="Number" />
                    <asp:RangeValidator ID="valRangoDescuento" runat="server"
                        ControlToValidate="txtDescuento"
                        MinimumValue="0"
                        MaximumValue="100"
                        Type="Integer"
                        ErrorMessage="El descuento debe estar entre 0 y 100"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>

                <!-- URLs de imágenes -->
                <div class="mb-3">
                    <label class="form-label">URLs de imágenes del producto</label><br />

                    <asp:TextBox ID="txtFoto1" runat="server" CssClass="form-control mb-2" placeholder="https://... (obligatoria)" />
                    <asp:RequiredFieldValidator ID="valFoto1" runat="server"
                        ControlToValidate="txtFoto1"
                        ErrorMessage="Debe ingresar al menos una URL de imagen"
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <asp:TextBox ID="txtFoto2" runat="server" CssClass="form-control mb-2" placeholder="https://... (opcional)" />
                    <asp:TextBox ID="txtFoto3" runat="server" CssClass="form-control mb-2" placeholder="https://... (opcional)" />

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

                <div class="text-center mt-3">
                    <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>

                <asp:Label ID="lblResultado" runat="server" CssClass="text-success mt-3 d-block text-center" Visible="false" />
            </div>
        </div>
    </div>

</asp:Content>
