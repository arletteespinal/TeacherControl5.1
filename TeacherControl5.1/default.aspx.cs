using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherControl5._1
{
    public partial class Login : System.Web.UI.Page
    {
        private Usuarios usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            usu = new Usuarios();
        }

        protected void IniciarSeccionButton_Click(object sender, EventArgs e)
        {
            bool recordar=false;
            if(RecuerdameCheckBox.Checked==false)
            {
                recordar = false;
            }
            else if (RecuerdameCheckBox.Checked == true)
            {
                recordar = true;
            }

            if (usu.Autenticar(UsuarioTextBox.Text, PasswordTextBox.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UsuarioTextBox.Text, recordar);
                Session["IdUsuario"] = usu.IdUsuario;
                if (usu.IdTipoUsuario == 1)
                {
                    Response.Redirect("~/ControlPanel/Administrador/InicioWeb.aspx");
                }
                else if (usu.IdTipoUsuario == 2)
                {
                    Response.Redirect("~/ControlPanel/Profesor/InicioWeb.aspx");
                }
                else if (usu.IdTipoUsuario == 3)
                {
                    Response.Redirect("~/ControlPanel/Estudiante/InicioWeb.aspx");
                }
                
               
            }
            else
            {

            }
        }
    }
}