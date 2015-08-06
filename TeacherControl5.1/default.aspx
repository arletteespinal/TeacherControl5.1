<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TeacherControl5._1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
        <title>Teacher's Control | LogIn</title>
    <link href="Resource/css/estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <header>
        	<div class="titulo">
                    Bienvenidos a Teacher's Control
                </div>
        </header>
        <div id="contenido">
               	<div id="logo">
                	<img src="Resource/img/logo.jpg"/>
                </div>
                <div id="form">
                	<asp:TextBox ID="UsuarioTextBox" runat="server" CssClass="entradaA" ></asp:TextBox>
                     <br /><asp:TextBox ID="PasswordTextBox" runat="server" CssClass="entradaB" TextMode="Password" ></asp:TextBox>
                    <div id="check">
                    	<asp:CheckBox ID="RecuerdameCheckBox" runat="server" Text="  Recuerdame" CssClass="check"/>
                    </div>
                    <asp:Button ID="IniciarSeccionButton" runat="server" CssClass="boton" Text="Iniciar Sesión" OnClick="IniciarSeccionButton_Click" />
                    <asp:HyperLink ID="RegistroHyperLink" runat="server" CssClass="reg">Registrate Aqui</asp:HyperLink>
                </div>
                 
                	
    	</div>
        <footer>
        </footer>
    </form>
</body>
</html>
