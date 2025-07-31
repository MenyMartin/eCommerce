<%@ Page Title="" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="eCommerce.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvUsuarios" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False"
    OnPageIndexChanging="gvUsuarios_PageIndexChanging" CssClass="table table-striped">
    <Columns>
        <asp:TemplateField HeaderText="Foto">
            <ItemTemplate>
                <img src='<%# Eval("URLFotoPerfil") %>' alt="Foto" style="width:40px; height:40px; object-fit:cover; border-radius:50%;" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DNI" HeaderText="DNI" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="edad" HeaderText="Edad" />
        <asp:BoundField DataField="direccion" HeaderText="Dirección" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="fechaRegistro" HeaderText="Registrado" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>

</asp:Content>
