<%@ Page Title="" Language="C#" MasterPageFile="~/AdministradoresSite.Master" AutoEventWireup="true" CodeBehind="InscripcionesWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Registros.InscripcionesWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CausesValidation="false" OnClick="BuscarButton_Click"/>
     <br />
     <asp:Label ID="Label2" runat="server" Text="Estudiante:"></asp:Label>
     <asp:DropDownList ID="EstudiantesDropDownList" runat="server">
     </asp:DropDownList>
     <br />
     <asp:Label ID="Label3" runat="server" Text="Grupo"></asp:Label>
    <asp:DropDownList ID="GruposDropDownList" runat="server"></asp:DropDownList>
     <br />
    <asp:Label ID="Label4" runat="server" Text="Estatus:"></asp:Label>
    <asp:DropDownList ID="EstatusDropDownList" runat="server">
        <asp:ListItem Value="0">Inscrito</asp:ListItem>
        <asp:ListItem Value="1">Retirado</asp:ListItem>
     </asp:DropDownList>
     <br />
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  CausesValidation="false" OnClick="NuevoButton_Click" />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click"   />
    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" Enabled="False" OnClick="EliminarButton_Click"  />
    <br />
    </asp:Content>
