<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="eCommerce.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container mt-4">
    <div class="row justify-content-center">
        <div class="col-md-5 text-center">
            <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle mb-4" Style="width: 180px; height: 180px; object-fit: cover;" />

            <div class="card shadow">
                <div class="card-body">
                    <h4 class="card-title mb-4">Mi Perfil</h4>

                    <p><strong>Nombre:</strong>
                        <asp:Label ID="lblNombre" runat="server" CssClass="text-muted" /></p>
                    <p><strong>Apellido:</strong>
                        <asp:Label ID="lblApellido" runat="server" CssClass="text-muted" /></p>
                    <p><strong>DNI:</strong>
                        <asp:Label ID="lblDNI" runat="server" CssClass="text-muted" /></p>
                    <p><strong>Edad:</strong>
                        <asp:Label ID="lblEdad" runat="server" CssClass="text-muted" /></p>
                    <p><strong>Dirección:</strong>
                        <asp:Label ID="lblDireccion" runat="server" CssClass="text-muted" /></p>
                    <p><strong>Email:</strong>
                        <asp:Label ID="lblEmail" runat="server" CssClass="text-muted" /></p>
                    <p><strong>Contraseña:</strong>
                        <asp:Label ID="lblPassword" runat="server" CssClass="text-muted" /></p>
                    <p><strong>Fecha de registro:</strong>
                        <asp:Label ID="lblFechaRegistro" runat="server" CssClass="text-muted" /></p>

                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" CssClass="btn btn-danger mt-3 w-100" OnClick="btnCerrarSesion_Click" />
                </div>
            </div>
        </div>        
    </div>
</div>
</asp:Content>
