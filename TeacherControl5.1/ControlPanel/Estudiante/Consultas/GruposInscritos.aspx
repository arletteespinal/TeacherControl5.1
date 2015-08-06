<%@ Page Title="" Language="C#" MasterPageFile="~/EstudiantesSite.Master" AutoEventWireup="true" CodeBehind="GruposInscritos.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Estudiante.Consultas.GruposInscritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Filtar por:"></asp:Label>
       <br />
    <asp:DropDownList ID="FiltarDropDownList" runat="server">
        <asp:ListItem Value="0">Código Grupo</asp:ListItem>
        <asp:ListItem Value="1">Asignatura</asp:ListItem>
        <asp:ListItem Value="2">Profesor</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="FiltarTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click"  />
    <br />
    <asp:GridView ID="InscripcionGridView" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/ControlPanel/Estudiante/Registros/InscripcionesWeb.aspx?Codigo={0}" Text="Editar" />
        </Columns>
    </asp:GridView>
</asp:Content>
