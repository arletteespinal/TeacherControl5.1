using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Consultas
{
    public partial class TiposEvaluacionesWeb : System.Web.UI.Page
    {
        private string filtro;
        protected void Page_Load(object sender, EventArgs e)
        {

            filtro = "1=1";
            if (!IsPostBack)
            {
                TiposGridView.DataSource = TiposEvaluaciones.Listar("IdTipoEvaluacion as Codigo, Descripcion,IdProfesor,(CASE  WHEN Estatus=0 then 'Desactivado' when Estatus=1 then 'Activado' end) as Estatus", filtro);
                TiposGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (FiltarDropDownList.SelectedIndex == 0)
            {
              
                filtro = "IdTipoEvaluacion='" + FiltarTextBox.Text + "'";
            }
            else if (FiltarDropDownList.SelectedIndex == 1)
            {
               
                filtro = "Descripcion like'%" + FiltarTextBox.Text + "%'";
            }

            else if (FiltarDropDownList.SelectedIndex == 2)
            {
              
                filtro = "IdProfesor='" + FiltarTextBox.Text + "'";
            }
            if (FiltarTextBox.Text == string.Empty)
            {
                filtro = "1=1";
            }
            if (EstatusCheckBox.Checked == false)
            {
                filtro+="and Estatus = '0'";
            }
            else if (EstatusCheckBox.Checked == true)
            {
                filtro += "and Estatus = '1'";
            }

            TiposGridView.DataSource = TiposEvaluaciones.Listar("IdTipoEvaluacion as Codigo, Descripcion,IdProfesor,(CASE  WHEN Estatus=0 then 'Desactivado' when Estatus=1 then 'Activado' end) as Estatus", filtro);
            TiposGridView.DataBind();
        }

       
    }
}