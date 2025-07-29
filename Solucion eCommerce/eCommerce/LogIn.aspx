<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="eCommerce.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/styles-login.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center mb-4">LogIn usuario</h1>

    <div class="login-container text-center">
        <h4 class="mb-4">Iniciar Sesión</h4>


        <div class="d-flex justify-content-center">


            <div class="w-75 w-md-50">
                <div class="mb-3 text-center">
                    <label for="txtUsuario" class="form-label">Usuario</label><br />
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" />
                </div>

                <div class="mb-3 text-center">
                    <label for="txtClave" class="form-label">Contraseña</label><br />
                    <asp:TextBox ID="txtClave" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" TextMode="Password" />
                </div>

                <asp:Button ID="btnLogin" Text="LogIn" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
        </div>
       

        <div>
            <label for="btnRegistrarse" class="form-label">¿Todavía no tenés cuenta?</label>
            <asp:Button ID="btnRegistrarse" Text="Registrate" runat="server" OnClick="btnRegistrarse_Click" CssClass="btn btn-success" />
        </div>

        <div class="text-center mt-3">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Visible="false" CssClass="fw-bold"></asp:Label>
        </div>
    </div>

    <!-- Panel de registro -->
    <asp:Panel ID="pnlRegistro" runat="server" Visible="false" CssClass="text-center mt-5">
        <h4 class="mb-4">Crear Cuenta</h4>

        <div class="d-flex justify-content-center">
            <div class="w-75 w-md-50">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="Nombre" />
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="Apellido" />
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="DNI" />
                <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="Edad" />
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="Dirección" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="Email" TextMode="Email" />
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="Contraseña" TextMode="Password" />
                <asp:TextBox ID="txtURLFotoPerfil" runat="server" CssClass="form-control form-control-sm w-25 mx-auto mb-2" placeholder="URL Foto Perfil" />

                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger mt-3" OnClick="btnVolver_Click" />
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" CssClass="btn btn-success mt-3" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
