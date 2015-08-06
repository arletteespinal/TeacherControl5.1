using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Consultas
{
    public partial class UsuariosWeb : System.Web.UI.Page
    {
        private Usuarios usuarios = new Usuarios();
        private string filtro;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtro = "1=1";
            if (!IsPostBack)
            {
                //UsuariosGridView.DataSource = usuarios.Listar("IdUsuario as Codigo,Nombre,Clave,IdTipoUsuario,Estatus",filtro);
                //UsuariosGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (FiltarDropDownList.SelectedIndex == 0)
            {
                filtro = "IdUsuario='"+FiltarTextBox.Text+"'";
            }
            else if (FiltarDropDownList.SelectedIndex == 1)
            {
                filtro = "Nombre like '%" + FiltarTextBox.Text + "%'";
            }

            else if (FiltarDropDownList.SelectedIndex == 2)
            {
                filtro = "Estatus='" + FiltarTextBox.Text + "'";
            }
            if (FiltarTextBox.Text == string.Empty)
            {
                filtro = "1=1";
            }
             //UsuariosGridView.DataSource = usuarios.Listar("IdUsuario as Codigo,Nombre,Clave,IdTipoUsuario,Estatus",filtro);
             //UsuariosGridView.DataBind();
        }
    }
}