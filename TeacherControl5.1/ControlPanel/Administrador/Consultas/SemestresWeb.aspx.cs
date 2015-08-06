using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Consultas
{
    public partial class SemestresWeb : System.Web.UI.Page
    {
        private string filtro;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtro = "1=1";
            if (!IsPostBack)
            {
                SemestresGridView.DataSource = Semestres.Listar("IdSemestre as Codigo, Periodo, Descripcion, FechaInicio,FechaFin,IdProfesor", filtro);
                SemestresGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (FiltarDropDownList.SelectedIndex == 0)
            {
                filtro = "IdSemestre='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 1)
            {
                filtro = "Periodo='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 2)
            {
                filtro = "Descripcion like'%" + FiltarTextBox.Text + "%'";
            }

            else if (FiltarDropDownList.SelectedIndex == 3)
            {
                filtro = "IdProfesor='" + FiltarTextBox.Text + "'";
            }
            if (FiltarTextBox.Text == string.Empty)
            {
                filtro = "1=1";
            }
            SemestresGridView.DataSource = Semestres.Listar("IdSemestre as Codigo, Periodo, Descripcion, FechaInicio,FechaFin,IdProfesor", filtro);
            SemestresGridView.DataBind();
        }


        
    }
}