<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Jorge_aplicada2_p2.Registros.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="text-center">
        <h1>Articulos</h1>
    </div>

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="ArticuloId:"></asp:Label>
            <asp:TextBox ID="ArticuloIdTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
            <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Existencia:"></asp:Label>
            <asp:TextBox ID="ExistenciaTextBox" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
</asp:Content>
