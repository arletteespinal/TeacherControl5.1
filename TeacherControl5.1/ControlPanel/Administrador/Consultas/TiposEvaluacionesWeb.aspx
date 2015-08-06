<%@ Page Title="" Language="C#" MasterPageFile="~/AdministradoresSite.Master" AutoEventWireup="true" CodeBehind="TiposEvaluacionesWeb.aspx.cs" Inherits="TeacherControl5._1.ControlPanel.Administrador.Consultas.TiposEvaluacionesWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Filtar por:"></asp:Label>
       <br />
    <asp:DropDownList ID="FiltarDropDownList" runat="server">
        <asp:ListItem Value="0">Código</asp:ListItem>
        <asp:ListItem Value="1">Descripción</asp:ListItem>
        <asp:ListItem Value="2">Código Profesor</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="FiltarTextBox" runat="server"></asp:TextBox>
    &nbsp;<asp:CheckBox ID="EstatusCheckBox" runat="server" Text="Activo" />
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click"  />
    <br />
    <asp:GridView ID="TiposGridView" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/ControlPanel/Administrador/Registros/TiposEvaluacionesWeb.aspx?Codigo={0}" Text="Editar" />
        </Columns>
    </asp:GridView>
</asp:Content>
