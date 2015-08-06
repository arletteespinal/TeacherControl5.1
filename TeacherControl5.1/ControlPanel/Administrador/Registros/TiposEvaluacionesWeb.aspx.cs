using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Registros
{
    public partial class TiposEvaluacionesWeb : System.Web.UI.Page
    {
        private TiposEvaluaciones tipos = new TiposEvaluaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (tipos.Buscar(id))
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

                ProfesoresDropDownList.DataSource = BLL.Profesores.Listar("IdProfesor, Nombres+' '+Apellidos as NombreCompleto", "1=1");
                ProfesoresDropDownList.DataValueField = "IdProfesor";
                ProfesoresDropDownList.DataTextField = "NombreCompleto";
                ProfesoresDropDownList.DataBind();
            }
        }

        private void Buscar()
        {
            CodigoTextBox.Text = tipos.IdTipoEvaluacion.ToString();
            DescripcionTextBox.Text = tipos.Descripcion;
            ProfesoresDropDownList.SelectedValue = tipos.IdProfesor.ToString();
            if (tipos.Estatus == 0)
            {
                EstatusCheckBox.Checked = false;
            }
            else if (tipos.Estatus == 1)
            {
                EstatusCheckBox.Checked = true;
            }
            

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ControlPanel/Administrador/Consultas/TiposEvaluacionesWeb.aspx");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }

        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
            EstatusCheckBox.Checked = false;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                tipos.IdTipoEvaluacion = Convert.ToInt32(CodigoTextBox.Text);
                if (tipos.Eliminar())
                {
                    LimpiarComponentes();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            tipos.Descripcion=DescripcionTextBox.Text ;
            tipos.IdProfesor = Convert.ToInt32(ProfesoresDropDownList.SelectedValue.ToString());
            if (EstatusCheckBox.Checked == false)
            {
                tipos.Estatus = 0;
            }
            else if (EstatusCheckBox.Checked == true)
            {
                tipos.Estatus = 1;
            }
            
            if (CodigoTextBox.Text == string.Empty)
            {
                if (tipos.Insertar())
                {
                    LimpiarComponentes();
                }
            }
            else
            {
                tipos.IdTipoEvaluacion = Convert.ToInt32(CodigoTextBox.Text);
                if (tipos.Modificar())
                {
                    LimpiarComponentes();
                }
            }
        }
    }
}