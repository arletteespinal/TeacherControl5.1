using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherControl5._1.ControlPanel.Profesor.Registros
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
            }
        }

        private void Buscar()
        {
            CodigoTextBox.Text = tipos.IdTipoEvaluacion.ToString();
            DescripcionTextBox.Text = tipos.Descripcion;
            if (tipos.Estatus == 0)
            {
                EstatusCheckBox.Checked = false;
            }
            else if (tipos.Estatus == 1)
            {
                EstatusCheckBox.Checked = true;
            }


        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            tipos.Descripcion = DescripcionTextBox.Text;
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
        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
            EstatusCheckBox.Checked = false;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
    }
}