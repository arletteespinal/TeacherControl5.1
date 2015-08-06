using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherControl5._1.ControlPanel.Profesor.Registros
{
    public partial class AsignaturasWeb : System.Web.UI.Page
    {
        private Asignaturas asignaturas = new Asignaturas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (asignaturas.Buscar(id))
                {
                    Buscar();

                }
            }
        }

        private void Buscar()
        {
            CodigoTextBox.Text = asignaturas.IdAsignatura.ToString();
            CodigoAsignaturaTextBox.Text = asignaturas.CodigoAsignatura;
            DescripcionTextBox.Text = asignaturas.Descripcion;
            CreditosTextBox.Text = asignaturas.Creditos.ToString();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            asignaturas.Descripcion = DescripcionTextBox.Text;
            asignaturas.Creditos = Convert.ToInt16(CreditosTextBox.Text);
            asignaturas.CodigoAsignatura = CodigoAsignaturaTextBox.Text;
            if (CodigoTextBox.Text == string.Empty)
            {
                if (asignaturas.Insertar())
                {
                    LimpiarComponentes();
                }
            }
            else
            {
                asignaturas.IdAsignatura = Convert.ToInt32(CodigoTextBox.Text);
                if (asignaturas.Modificar())
                {
                    LimpiarComponentes();
                }
            }
        }

        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            CodigoAsignaturaTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
            CreditosTextBox.Text = " ";

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }

    
    }
}