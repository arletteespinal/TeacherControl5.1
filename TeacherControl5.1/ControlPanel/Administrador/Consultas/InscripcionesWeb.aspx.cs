using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Consultas
{
    public partial class InscripcionesWeb : System.Web.UI.Page
    {
        private string filtro;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtro = "1=1";
            if (!IsPostBack)
            {
                InscripcionGridView.DataSource = Inscripciones.Listar("IdInscripcion as Codigo,IdEstudiante, IdGrupo, Estatus", "Where " + filtro);
                InscripcionGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (FiltarDropDownList.SelectedIndex == 0)
            {
                filtro = " IdInscripcion='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 2)
            {
                filtro = " IdEstudiante='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 1)
            {
                filtro = " IdGrupo='" + FiltarTextBox.Text + "'";
            }
            if (FiltarTextBox.Text == string.Empty)
            {
                filtro = " 1=1";
            }
            InscripcionGridView.DataSource = Inscripciones.Listar("IdInscripcion as Codigo,IdEstudiante, IdGrupo, Estatus", "Where " + filtro);
            InscripcionGridView.DataBind();
        }
    }
}