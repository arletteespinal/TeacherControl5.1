using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherControl5._1.ControlPanel.Profesor.Registros
{
    public partial class InscripcionesWeb : System.Web.UI.Page
    {
        private Inscripciones inscripcion = new Inscripciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (inscripcion.Buscar(id))
                {
                    Buscar();

                }
            }
        }

        private void Buscar()
        {
            EstudianteTextBox.Text = inscripcion.IdEstudiante.ToString();
            GruposDropDownList.SelectedValue = inscripcion.IdGrupo.ToString();
            CodigoTextBox.Text = inscripcion.IdInscripcion.ToString();
            EstatusDropDownList.SelectedIndex = inscripcion.Estatus;

        }

        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            EstudianteTextBox.Text = " ";

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            inscripcion.IdEstudiante = Convert.ToInt32(EstudianteTextBox.Text.ToString());
            inscripcion.IdGrupo = Convert.ToInt32(GruposDropDownList.SelectedValue.ToString());
            if (EstatusDropDownList.SelectedIndex == 0)
            {
                inscripcion.Estatus = 0;
            }
            else if (EstatusDropDownList.SelectedIndex == 1)
            {
                inscripcion.Estatus = 1;
            }

            if (CodigoTextBox.Text == string.Empty)
            {
                if (inscripcion.Insertar())
                {
                    LimpiarComponentes();
                }
            }
            else
            {
                inscripcion.IdInscripcion = Convert.ToInt32(CodigoTextBox.Text);
                if (inscripcion.Modificar())
                {
                    LimpiarComponentes();
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
    }
}