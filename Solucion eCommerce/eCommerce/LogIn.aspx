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
            </div>
        </div>

        <asp:Button Text="LogIn" runat="server" />

        <div class="mt-3">
            <a href="#">¿Olvidaste tu contraseña?</a>
        </div>
    </div>


</asp:Content>
