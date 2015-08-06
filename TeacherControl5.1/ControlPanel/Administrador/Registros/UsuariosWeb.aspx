<%@ Page Title="" Language="C#" MasterPageFile="~/AdministradoresSite.Master" AutoEventWireup="true" CodeBehind="UsuariosWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Registros.UsuariosWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Nombre Usuario:"></asp:Label>
    <asp:TextBox ID="NombreTextBox" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox" ErrorMessage="El Campo &quot;Nombre Usuario&quot; es obligatorio." ForeColor="#CC0000">*</asp:RequiredFieldValidator>
    <br/>
    <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
    <asp:TextBox ID="ContrasenaTextBox" runat="server" TextMode="Password"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ContrasenaTextBox" ErrorMessage="El Campo &quot;Contraseña&quot; es obligatorio." ForeColor="#CC0000">*</asp:RequiredFieldValidator>
    <br/>
    <asp:Label ID="Label4" runat="server" Text="Confirmar Contraseña:"></asp:Label>
    <asp:TextBox ID="CContrasenaTextBox" runat="server" TextMode="Password"></asp:TextBox>
     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ContrasenaTextBox" ControlToValidate="CContrasenaTextBox" ErrorMessage="Las contraseñas no coiciden." ForeColor="#CC0000">*</asp:CompareValidator>
    <br/>
    <asp:Label ID="Label5" runat="server" Text="Tipo de Usuario:"></asp:Label>
    <asp:DropDownList ID="TiposDropDownList" runat="server">
    </asp:DropDownList>
    <br/>
    <asp:Label ID="Label6" runat="server" Text="Estatus:"></asp:Label>
     <asp:CheckBox ID="EstatusCheckBox" runat="server" Text="Activo" />
    <br/>
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" Enabled="False" OnClick="EliminarButton_Click" />
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
</asp:Content>
