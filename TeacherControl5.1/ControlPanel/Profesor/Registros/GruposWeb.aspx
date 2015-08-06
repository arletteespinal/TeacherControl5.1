<%@ Page Title="" Language="C#" MasterPageFile="~/ProfesoresSite.Master" AutoEventWireup="true" CodeBehind="GruposWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Profesor.Registros.GruposWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Enabled="False"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CausesValidation="false"/>
     <br />
     <asp:Label ID="Label7" runat="server" Text="Semestre:"></asp:Label>
     <asp:DropDownList ID="SemestreDropDownList" runat="server">
     </asp:DropDownList>
     <br />
     <asp:Label ID="Label8" runat="server" Text="Asignatura:"></asp:Label>
     <asp:DropDownList ID="AsignaturaDropDownList" runat="server">
     </asp:DropDownList>
     <br />
     <asp:Label ID="Label9" runat="server" Text="Estatus:"></asp:Label>
     <asp:DropDownList ID="EstatusDropDownList" runat="server">
         <asp:ListItem Value="0">Abierto</asp:ListItem>
         <asp:ListItem Value="1">Cerrado</asp:ListItem>
         <asp:ListItem Value="2">Terminado</asp:ListItem>
     </asp:DropDownList>
     <br />
    <asp:Label ID="Label2" runat="server" Text="Dia:"></asp:Label>
    <asp:DropDownList ID="DiaDropDownList" runat="server"></asp:DropDownList>
    <asp:Label ID="Label3" runat="server" Text="Hora Inicio:"></asp:Label>
    <asp:TextBox ID="HoraInicioTextBox" runat="server"></asp:TextBox>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="HoraInicioTextBox" ErrorMessage="Hora Inicio no es valida." ForeColor="Red" ValidationExpression="(([01]\d)|(2[0-3])):([0-5]\d)">*</asp:RegularExpressionValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="HoraInicioTextBox" ErrorMessage="El campo &quot;Hora Inicio&quot; es obligatorio para agregar horario." ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:Label ID="Label4" runat="server" Text="Hora Fin:"></asp:Label>
    <asp:TextBox ID="HoraFinTextBox" runat="server"></asp:TextBox>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="HoraFinTextBox" ErrorMessage="Hora Fin no es valida" ForeColor="Red" ValidationExpression="(([01]\d)|(2[0-3])):([0-5]\d)">*</asp:RegularExpressionValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="HoraFinTextBox" ErrorMessage="El campo &quot;Hora Fin&quot; es obligatorio para agregar horario." ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:Button ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
     <br />
    <asp:GridView ID="DetalleGridView" runat="server"></asp:GridView>
      <br />
    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  CausesValidation="false" OnClick="NuevoButton_Click"  />
    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Enabled="False" CausesValidation="false" OnClick="GuardarButton_Click" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
</asp:Content>
