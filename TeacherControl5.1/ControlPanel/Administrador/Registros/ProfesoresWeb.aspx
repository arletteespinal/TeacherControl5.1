<%@ Page Title="" Language="C#" MasterPageFile="~/Administradores.Master" AutoEventWireup="true" CodeBehind="ProfesoresWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Registros.ProfesoresWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Nombre Usuario:"></asp:Label>
    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Buscar" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Nombres:"></asp:Label>   
     <asp:TextBox ID="NombresTextBox" runat="server"></asp:TextBox>
    <br />
     <asp:Label ID="Label4" runat="server" Text="Apellidos:"></asp:Label>   
    <asp:TextBox ID="ApellidosTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Genero:"></asp:Label>
    <asp:DropDownList ID="GeneroDropDownList" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Telefono:"></asp:Label>
    <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Tipo de documento:"></asp:Label>
    <asp:DropDownList ID="TipodocumentoDropDownList" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Documento:"></asp:Label>
    <asp:TextBox ID="DocumentoTextBox" runat="server"></asp:TextBox>
    <br/>
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar"  />
    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" Enabled="False" />

</asp:Content>
