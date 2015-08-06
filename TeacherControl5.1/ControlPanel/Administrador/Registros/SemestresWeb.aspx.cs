using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Registros
{
    public partial class SemestresWeb : System.Web.UI.Page
    {
        private Semestres semestres = new Semestres();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (semestres.Buscar(id))
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

                ProfesoresDropDownList.DataSource = BLL.Profesores.Listar("IdProfesor, Nombres+' '+Apellidos as NombreCompleto", "1=1");
                ProfesoresDropDownList.DataValueField = "IdProfesor";
                ProfesoresDropDownList.DataTextField = "NombreCompleto";
                ProfesoresDropDownList.DataBind();
            }
        }
        private void Buscar() 
        {
            CodigoTextBox.Text = semestres.IdSemestre.ToString();
            PeriodoTextBox.Text = semestres.Periodo;
            DescripcionTextBox.Text = semestres.Descripcion;
            FechaFinTextBox.Text = semestres.Fechafin.ToString();
            FechaInicioTextBox.Text = semestres.Fechainicio.ToString();
            ProfesoresDropDownList.SelectedValue = semestres.IdProfesor.ToString() ;
            
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            semestres.Periodo = PeriodoTextBox.Text;
            semestres.Descripcion = DescripcionTextBox.Text;
            semestres.Fechainicio = DateTime.Now;
            semestres.Fechafin = DateTime.Now;
            //semestres.Fechainicio =Convert.ToDateTime(FechaInicioTextBox.Text);
            //semestres.Fechafin = Convert.ToDateTime(FechaFinTextBox.Text);
            semestres.IdProfesor = Convert.ToInt32( ProfesoresDropDownList.SelectedValue.ToString());
            if (CodigoTextBox.Text == string.Empty)
            {
                if (semestres.Insertar())
                {
                    LimpiarComponentes();
                }
            }
            else
            {
                semestres.IdSemestre = Convert.ToInt32(CodigoTextBox.Text);
                if (semestres.Modificar())
                {
                    LimpiarComponentes();
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try{
                semestres.IdSemestre= Convert.ToInt32 (CodigoTextBox.Text);
                if (semestres.Eliminar())
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
            DescripcionTextBox.Text = " ";
            PeriodoTextBox.Text = " ";
            FechaFinTextBox.Text = " ";
            FechaInicioTextBox.Text = " ";
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ControlPanel/Administrador/Consultas/SemestresWeb.aspx");
        }
    }
}