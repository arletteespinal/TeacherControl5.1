using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Registros
{
    public partial class InscripcionesWeb : System.Web.UI.Page{
    
        private BLL.Inscripciones inscripcion = new BLL.Inscripciones();
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
                if (CodigoTextBox.Text == string.Empty)
                {
                    EliminarButton.Enabled = false;

                }
                else
                {
                    EliminarButton.Enabled = true;

                }

                EstudiantesDropDownList.DataSource = BLL.Estudiantes.Listar("IdEstudiante, Nombres+' '+Apellidos as NombreCompleto", "1=1");
                EstudiantesDropDownList.DataValueField = "IdEstudiante";
                EstudiantesDropDownList.DataTextField = "NombreCompleto";
                EstudiantesDropDownList.DataBind();

                GruposDropDownList.DataSource = Grupos.Listar("g.IdGrupo,( s.Periodo+'-'+a.Descripcion+'-'+p.Nombres+' '+p.Apellidos) as Descripcion ", " g, Semestres s, Asignaturas a, Profesores p");
                GruposDropDownList.DataValueField = "IdGrupo";
                GruposDropDownList.DataTextField = "Descripcion";
                GruposDropDownList.DataBind();
            }


        }

        private void Buscar()
        {
            EstudiantesDropDownList.SelectedValue = inscripcion.IdEstudiante.ToString();
            GruposDropDownList.SelectedValue = inscripcion.IdGrupo.ToString();
            CodigoTextBox.Text = inscripcion.IdInscripcion.ToString();
            EstatusDropDownList.SelectedIndex = inscripcion.Estatus;
            
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ControlPanel/Administrador/Consultas/InscripcionesWeb.aspx");
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            inscripcion.IdEstudiante = Convert.ToInt32(EstudiantesDropDownList.SelectedValue.ToString());
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

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                inscripcion.IdInscripcion = Convert.ToInt32(CodigoTextBox.Text);
                if (inscripcion.Eliminar())
                {
                    LimpiarComponentes();
                }
            }
            catch (Exception)
            {

            }
        }

        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
    }
}