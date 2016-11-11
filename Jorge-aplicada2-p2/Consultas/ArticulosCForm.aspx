﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticulosCForm.aspx.cs" Inherits="Jorge_aplicada2_p2.Consultas.ArticulosCForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="BuscarLabel" For="BuscarTexBox" runat="server" Font-Bold="True" Text="Buscar por:"></asp:Label>
        </div>
        <div class="col-md-2 col-sm-2 col-xs-3">
            <asp:DropDownList ID="CamposDropDownList" runat="server" class="btn btn-primary dropdown-toggle">
                <asp:ListItem>ArticuloId</asp:ListItem>
                <asp:ListItem>Descripcion</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="BuscarTextBox" runat="server" CssClass="form-control" placeholder="Buscar" MaxLength="16"></asp:TextBox>
        </div>
        <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
    </div>
    <br />
    <br />
    <br />

    <div class="form-group">
        <div class="table table-responsive col-md-12">
            <asp:GridView ID="ConsultaGridView" runat="server" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
