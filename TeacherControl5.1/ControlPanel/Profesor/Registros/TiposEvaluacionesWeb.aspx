<%@ Page Title="" Language="C#" MasterPageFile="~/ProfesoresSite.Master" AutoEventWireup="true" CodeBehind="TiposEvaluacionesWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Profesor.Registros.TiposEvaluacionesWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CausesValidation="false"/>
   <br />
     <asp:Label ID="Label3" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Descripción&quot; es obligatorio." ForeColor="Red" ControlToValidate="DescripcionTextBox">*</asp:RequiredFieldValidator>
       <br />
    <asp:Label ID="Label2" runat="server" Text="Estatus:"></asp:Label>
    <asp:CheckBox ID="EstatusCheckBox" runat="server" Text="Activo" />
     <br />
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  CausesValidation="false" OnClick="NuevoButton_Click"  />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click"   />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
</asp:Content>
