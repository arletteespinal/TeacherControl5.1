<%@ Page Title="" Language="C#" MasterPageFile="~/Administradores.Master" AutoEventWireup="true" CodeBehind="UsuariosWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Consultas.UsuariosWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Filtar por:"></asp:Label>
       <br />
    <asp:DropDownList ID="FiltarDropDownList" runat="server">
        <asp:ListItem Value="0">IdUsuario</asp:ListItem>
        <asp:ListItem Value="1">Nombre Usuario</asp:ListItem>
        <asp:ListItem Value="2">Estatus</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="FiltarTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
    <br />
    <asp:GridView ID="UsuariosGridView" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/ControlPanel/Administrador/Registros/UsuariosWeb.aspx?Codigo={0}" Text="Editar" />
        </Columns>
    </asp:GridView>
</asp:Content>
