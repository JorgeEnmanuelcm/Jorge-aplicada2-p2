<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jorge_aplicada2_p2.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="text-center">
        <asp:LinkButton ID="ArticulosLinkButton" runat="server" CssClass="btn btn-info" Text="Articulos" OnClick="ArticulosLinkButton_Click"><span class="glyphicon glyphicon-saved"></span>&nbsp;Articulos</asp:LinkButton>
        <asp:LinkButton ID="ToastrButton" runat="server" CssClass="btn btn-info" Text="Ventas" OnClick="ToastrButton_Click"><span class="glyphicon glyphicon-saved"></span>&nbsp;Ventas</asp:LinkButton>
    </div>
    <br />
</asp:Content>
