<%@ Page Title="" Language="C#" MasterPageFile="~/AdministradoresSite.Master" AutoEventWireup="true" CodeBehind="SemestresWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Registros.SemestresWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click"  CausesValidation="false"/>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Periodo:"></asp:Label>
    <asp:TextBox ID="PeriodoTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Descripción&quot; es obligatorio." ForeColor="Red" ControlToValidate="DescripcionTextBox">*</asp:RequiredFieldValidator>
   <br />
    <asp:Label ID="Label4" runat="server" Text="Fecha Inicio:"></asp:Label>
    <asp:TextBox ID="FechaInicioTextBox" runat="server"  CssClass="datepicker"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Fecha Inicio&quot; es obligatorio." ControlToValidate="FechaInicioTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Fecha Fin:"></asp:Label>
    <asp:TextBox ID="FechaFinTextBox" runat="server"  CssClass="datepicker"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Fecha Fin&quot; es obligatorio" ControlToValidate="FechaFinTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Profesor:"></asp:Label>
    <asp:DropDownList ID="ProfesoresDropDownList" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click"  CausesValidation="false"/>
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click"  />
    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" Enabled="False" OnClick="EliminarButton_Click" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
</asp:Content>
