<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="eCommerce.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center mb-4">Contactate con nosotros!</h1>

        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-md-6 bg-white p-4 shadow rounded">
                    <h2 class="text-center mb-4">Contacto</h2>

                    <asp:Label ID="lblMensajeExito" runat="server" ForeColor="Green" Visible="false" />

                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>

                    <div class="mb-3">
                        <label for="txtMensaje" class="form-label">Mensaje</label>
                        <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                    </div>

                    <div class="text-center">
                        <asp:Button Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" ID="btnEnviar" runat="server" />
                    </div>

                    <asp:Label ID="lblResultado" runat="server" CssClass="text-success mt-3 d-block text-center" Visible="false" />
                </div>
            </div>
        </div>
    
</asp:Content>
