<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="eCommerce.Vender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center mb-4">Ventas del usuario</h1>

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-8 bg-white shadow p-4 rounded">
                <h3 class="text-center mb-4">Cargar Producto</h3>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre del producto</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Fotos del producto</label><br />
                    <asp:FileUpload ID="fuFoto1" runat="server" CssClass="form-control mb-2" />
                    <asp:FileUpload ID="fuFoto2" runat="server" CssClass="form-control mb-2" />
                    <asp:FileUpload ID="fuFoto3" runat="server" CssClass="form-control mb-2" />
                </div>

                <div class="text-center">
                    <asp:Button Text="Guardar" runat="server" />
                </div>

                <asp:Label ID="lblResultado" runat="server" CssClass="text-success mt-3 d-block text-center" Visible="false" />
            </div>
        </div>
    </div>
</asp:Content>
