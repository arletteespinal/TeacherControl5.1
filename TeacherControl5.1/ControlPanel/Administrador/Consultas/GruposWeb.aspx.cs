using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace TeacherControl5._1.ControlPanel.Administrador.Consultas
{
    public partial class GruposWeb : System.Web.UI.Page
    {
        private string filtro;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtro = "where 1=1";
            if (!IsPostBack)
            {
                GruposGridView.DataSource = Grupos.Listar("IdGrupo as Codigo, IdSemestre, IdAsignatura, IdProfesor, Estatus", filtro);
                GruposGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (FiltarDropDownList.SelectedIndex == 0)
            {
                filtro = "where IdGrupo='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 1)
            {
                filtro = "where IdAsignatura='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 2)
            {
                filtro = "where IdSemestre='" + FiltarTextBox.Text + "'";
            }

            else if (FiltarDropDownList.SelectedIndex == 3)
            {
                filtro = "where IdProfesor='" + FiltarTextBox.Text + "'";
            }
            if (FiltarTextBox.Text == string.Empty)
            {
                filtro = "where 1=1";
            }
            GruposGridView.DataSource = Grupos.Listar("IdGrupo as Codigo, IdSemestre, IdAsignatura, IdProfesor, Estatus", filtro);
            GruposGridView.DataBind();
        }
    }
}