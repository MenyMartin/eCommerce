<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="eCommerce.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel CssClass="d-flex align-items-center mb-3" runat="server">
    <span class="me-2 fw-bold">Buscador de clientes:</span>
    <asp:TextBox ID="txtBuscar" CssClass="form-control form-control-sm me-2 w-auto" placeholder="Buscar" runat="server" />
    <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-outline-success btn-sm" runat="server" OnClick="btnBuscar_Click" />
</asp:Panel>

<asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped mt-4">
    <Columns>
        <asp:TemplateField HeaderText="Foto">
            <ItemTemplate>
                <img src='<%# Eval("URLFotoPerfil") %>' alt="Foto" style="width:50px; height:50px; object-fit:cover;" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DNI" HeaderText="DNI" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="direccion" HeaderText="Dirección" />
        <asp:BoundField DataField="edad" HeaderText="Edad" />
        <asp:BoundField DataField="fechaRegistro" HeaderText="Registro" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>

</asp:Content>
