using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Estudiante.Registros
{
    public partial class InscribirGrupo : System.Web.UI.Page
    {
        private BLL.Inscripciones inscripcion = new BLL.Inscripciones();
        private Grupos grupos = new Grupos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(CodigoGrupoTextBox.Text, out id);
            if (grupos.Buscar(id))
            {
                Buscar(id);
            }
            
        }
        private void Buscar(int id)
        {
            DetalleGridView.DataSource = Horarios.Listar("*"," IdGrupo='"+id+"'");
            DetalleGridView.DataBind();

            AsignaturaDropDownList.DataSource = Grupos.Listar("g.IdAsignatura, a.Descripcion", " g join Asignaturas a on g.IdAsignatura = a.IdAsignatura where IdGrupo='"+id+"'");
            AsignaturaDropDownList.DataValueField = "IdAsignatura";
            AsignaturaDropDownList.DataTextField = "Descripcion";
            AsignaturaDropDownList.DataBind();

            SemestreDropDownList.DataSource = Grupos.Listar("g.IdSemestre, s.Descripcion", " g join Semestres s on g.IdSemestre = s.IdSemestre where IdGrupo='" + id + "'");
            SemestreDropDownList.DataValueField = "IdSemestre";
            SemestreDropDownList.DataTextField = "Descripcion";
            SemestreDropDownList.DataBind();

            ProfesoresDropDownList.DataSource = Grupos.Listar("g.IdProfesor, p.Nombres+' '+p.Apellidos as NombreCompleto", " g join Profesores p on g.IdProfesor = p.IdProfesor where IdGrupo='" + id + "'");
            ProfesoresDropDownList.DataValueField = "IdProfesor";
            ProfesoresDropDownList.DataTextField = "NombreCompleto";
            ProfesoresDropDownList.DataBind();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            //inscripcion.IdEstudiante = Convert.ToInt32(EstudiantesDropDownList.SelectedValue.ToString());
            inscripcion.IdGrupo = Convert.ToInt32(CodigoGrupoTextBox.Text);
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
                    //LimpiarComponentes();
                }
            }
            else
            {
                inscripcion.IdInscripcion = Convert.ToInt32(CodigoTextBox.Text);
                if (inscripcion.Modificar())
                {
                    //LimpiarComponentes();
                }
            }
        }
        
    }
}