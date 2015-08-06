using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Estudiante.Consultas
{
    public partial class GruposInscritos : System.Web.UI.Page
    {
        private string filtro;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtro = " and 1=1";
            if (!IsPostBack)
            {
                InscripcionGridView.DataSource = Inscripciones.Listar("i.IdInscripcion as Codigo, i.IdGrupo as CodigoGrupo,s.Periodo+' - '+s.Descripcion as Semestre,a.Descripcion as Asignatura,p.Nombres+' '+p.Apellidos as Profesor, i.Estatus ","i join Grupos g on i.IdGrupo=g.IdGrupo join Semestres s on s.IdSemestre=g.IdSemestre join Asignaturas a on g.IdAsignatura = a.IdAsignatura join Profesores p on p.IdProfesor=g.IdProfesor where i.IdEstudiante='2'"+ filtro);
                InscripcionGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
           
             if (FiltarDropDownList.SelectedIndex == 0)
            {
                filtro = "and g.IdGrupo='" + FiltarTextBox.Text + "'";
            }
             else if (FiltarDropDownList.SelectedIndex == 1)
             {
                 filtro = "and a.Descripcion like '%" + FiltarTextBox.Text + "%'";
             }
             else if (FiltarDropDownList.SelectedIndex == 2)
             {
                 filtro = "and p.Nombres like'%" + FiltarTextBox.Text + "%' and p.Apellidos like '%" + FiltarTextBox.Text + "%'";
             }
            if (FiltarTextBox.Text == string.Empty)
            {
                filtro = "and 1=1";
            }
            InscripcionGridView.DataSource = Inscripciones.Listar("i.IdInscripcion as Codigo, i.IdGrupo as CodigoGrupo,s.Periodo+' - '+s.Descripcion as Semestre,a.Descripcion as Asignatura,p.Nombres+' '+p.Apellidos as Profesor, i.Estatus ", "i join Grupos g on i.IdGrupo=g.IdGrupo join Semestres s on s.IdSemestre=g.IdSemestre join Asignaturas a on g.IdAsignatura = a.IdAsignatura join Profesores p on p.IdProfesor=g.IdProfesor where i.IdEstudiante='2'" + filtro);
            InscripcionGridView.DataBind();
        }
    }
}