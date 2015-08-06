using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Profesor.Registros
{
    public partial class SemestresWeb : System.Web.UI.Page
    {
        private Semestres semestres;
        protected void Page_Load(object sender, EventArgs e)
        {
            semestres = new Semestres();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            
            semestres.Descripcion = DescripcionTextBox.Text;
            semestres.Fechainicio = DateTime.Now;
            semestres.Fechafin = DateTime.Now;
            //semestres.Fechainicio =Convert.ToDateTime(FechaInicioTextBox.Text);
            //semestres.Fechafin = Convert.ToDateTime(FechaFinTextBox.Text);
            if (CodigoTextBox.Text == string.Empty)
            {
                if (semestres.Insertar())
                {
                    limpiarComponentes();
                }
            }
            else
            {
                semestres.Periodo = PeriodoTextBox.Text;
                if (semestres.Modificar())
                {
                    limpiarComponentes();
                }
            }
            

        }

        private void limpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
            PeriodoTextBox.Text = " ";
            FechaFinTextBox.Text = " ";
            FechaInicioTextBox.Text = " ";
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }

        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
            PeriodoTextBox.Text = " ";
            FechaFinTextBox.Text = " ";
            FechaInicioTextBox.Text = " ";
        }
    }
}