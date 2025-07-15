<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="eCommerce.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="mb-4 text-center">Administración de ventas</h2>

        <div class="d-flex justify-content-center gap-3">

            <asp:Button ID="btnAlta" runat="server" Text="Vender un producto" CssClass="btn btn-success" OnClick="btnAlta_Click" />
            
        </div>

    </div>

</asp:Content>
