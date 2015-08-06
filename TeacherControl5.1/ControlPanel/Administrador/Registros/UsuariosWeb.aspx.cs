using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Registros
{
    public partial class UsuariosWeb : System.Web.UI.Page
    {
        private Usuarios usuarios = new Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (usuarios.Buscar(id))
                {
                     Buscar();

                }
                if (CodigoTextBox.Text == string.Empty)
                {
                    EliminarButton.Enabled = false;

                }
                else
                {
                    EliminarButton.Enabled = true;

                }

                //TiposDropDownList.DataSource = usuarios.Listar("IdTipoUsuario as IdTipo, Descripcion", " 1=1");
                //TiposDropDownList.DataValueField = "IdTipo";
                //TiposDropDownList.DataTextField = "Descripcion";
                //TiposDropDownList.DataBind();
            }
        }

        private void Buscar()
        {
            CodigoTextBox.Text = usuarios.IdUsuario.ToString();
            NombreTextBox.Text = usuarios.Nombre;
            ContrasenaTextBox.Text = usuarios.Clave;
            TiposDropDownList.SelectedValue = usuarios.IdTipoUsuario.ToString();
            if (usuarios.Estatus == 1)
            {
                EstatusCheckBox.Checked = true;
            }
            else if (usuarios.Estatus == 0)
            {
                EstatusCheckBox.Checked = false;
            }

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            usuarios.Nombre = NombreTextBox.Text;
            usuarios.Clave = ContrasenaTextBox.Text;
            usuarios.IdTipoUsuario = Convert.ToInt32(TiposDropDownList.SelectedValue);
            if (EstatusCheckBox.Checked == true)
            {
                usuarios.Estatus = 1;
            }
            else
            {
                usuarios.Estatus = 0;
            }

            if (ContrasenaTextBox.Text == CContrasenaTextBox.Text)
            {

                if (CodigoTextBox.Text == string.Empty)
                {

                    usuarios.Insertar();
                    LimpiarComponentes();
                }
                else
                {
                    usuarios.IdUsuario = Convert.ToInt32(CodigoTextBox.Text);
                    usuarios.Modificar();
                    LimpiarComponentes();
                }
            }

            
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {

                usuarios.IdUsuario = Convert.ToInt32(CodigoTextBox.Text);
                usuarios.Eliminar();
                LimpiarComponentes();

            }
            catch (Exception)
            {

            }
        }

        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            NombreTextBox.Text = " ";
            ContrasenaTextBox.Text = " ";
            CContrasenaTextBox.Text = " ";
            EstatusCheckBox.Checked = false;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
    }
}