<%@ Page Title="" Language="C#" MasterPageFile="~/AdministradoresSite.Master" AutoEventWireup="true" CodeBehind="EvaluacionesGruposWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Registros.EvaluacionesGruposWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CausesValidation="false" OnClick="BuscarButton_Click" />
     <br />
     <asp:Label ID="Label3" runat="server" Text="Grupo"></asp:Label>
    <asp:DropDownList ID="GruposDropDownList" runat="server"></asp:DropDownList>
     <br />
    <asp:Label ID="Label4" runat="server" Text="Tipo de Evaluación:"></asp:Label>
    <asp:DropDownList ID="TipoDropDownList" runat="server"></asp:DropDownList>
     <br />
    <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label>
    <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
         <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Descripción:"></asp:Label>
    <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
         <asp:Label ID="Label9" runat="server" Text="Tipo Asignación:"></asp:Label><asp:DropDownList ID="TipoAsignacionDropDownList" runat="server">
        <asp:ListItem Value="0">Teoria</asp:ListItem>
        <asp:ListItem Value="1">Practica</asp:ListItem>
    </asp:DropDownList>
         <asp:Label ID="Label10" runat="server" Text="Ponderacion:"></asp:Label>
    <asp:TextBox ID="PonderacionTextBox" runat="server"></asp:TextBox>
         <br />
    <asp:Label ID="Label6" runat="server" Text="Fecha Asignacion:"></asp:Label>
    <asp:TextBox ID="FechaAsignacionTextBox" runat="server" CssClass="datepicker"  ></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Text="Fecha Entrega:"></asp:Label>
    <asp:TextBox ID="FechaEntregaTextBox" runat="server" CssClass="datepicker" ></asp:TextBox>
     <asp:Label ID="Label8" runat="server" Text="Estatus:"></asp:Label><asp:DropDownList ID="EstatusDropDownList" runat="server">
        <asp:ListItem Value="0">Activo</asp:ListItem>
        <asp:ListItem Value="1">Desactivado</asp:ListItem>
    </asp:DropDownList>
     <br />
     <asp:Button ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click"  />
    <asp:GridView ID="DetalleGridView" runat="server">
    </asp:GridView>
    <br />
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  CausesValidation="false" OnClick="NuevoButton_Click" />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click"  />
    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" Enabled="False" OnClick="EliminarButton_Click"  />
    <br />
</asp:Content>
