<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Jorge_aplicada2_p2.Registros.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <h1>Ventas</h1>
    </div>

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="VentaId:"></asp:Label>
            <asp:TextBox ID="VentaIdTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="BuscarButton" runat="server" class ="btn btn-info btn-sm" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Fecha:"></asp:Label>
            <asp:TextBox ID="FechaTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Monto:"></asp:Label>
            <asp:TextBox ID="MontoTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="ArticuloId:"></asp:Label>
            <asp:DropDownList ID="ArticuloIdDropDownList" runat="server"></asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Cantidad:"></asp:Label>
            <asp:TextBox ID="CantidadTextBox" runat="server" MaxLength="4"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="PrecioTextBox" runat="server" MaxLength="6"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="text-center">
        <asp:Button ID="AgregarButton" runat="server" CssClass="btn btn-info" Text="Agregar" OnClick="AgregarButton_Click" /><br />
        <asp:GridView ID="VentasGridView" runat="server" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ArticuloId" HeaderText="Articulo Id" SortExpression="ArticuloId" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
            </Columns>
        </asp:GridView>
    </div>
    <br />

    <div class="container">
        <div class="form-group">
            <div class="text-center">
                <asp:Button ID="NuevoButton" runat="server" class ="btn btn-warning btn-sm" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button ID="GuardarButton" runat="server" class ="btn btn-success btn-sm" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="EliminarButton" runat="server" class ="btn btn-danger btn-sm" Text="Eliminar" OnClick="EliminarButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
