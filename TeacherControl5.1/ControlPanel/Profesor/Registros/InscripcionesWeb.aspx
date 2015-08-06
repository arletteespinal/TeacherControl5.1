<%@ Page Title="" Language="C#" MasterPageFile="~/ProfesoresSite.Master" AutoEventWireup="true" CodeBehind="InscripcionesWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Profesor.Registros.InscripcionesWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CausesValidation="false"/>
     <br />
     <asp:Label ID="Label2" runat="server" Text="Código Estudiante:"></asp:Label>
     <asp:TextBox ID="EstudianteTextBox" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Código Estudiante&quot; es obligatorio." ForeColor="Red" ControlToValidate="EstudianteTextBox">*</asp:RequiredFieldValidator>
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
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  CausesValidation="false" OnClick="NuevoButton_Click"  />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click"  />
     <br />
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <br />
</asp:Content>
