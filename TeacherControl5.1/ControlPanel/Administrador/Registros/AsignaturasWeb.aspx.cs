using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Registros
{
    public partial class AsignaturasWeb : System.Web.UI.Page
    {
        private Asignaturas asignaturas ;
        protected void Page_Load(object sender, EventArgs e)
        {
            asignaturas = new Asignaturas();//todo: oojo
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);

                if (asignaturas.Buscar(id))
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
        private void Buscar()//todo:ojo
        {
            CodigoTextBox.Text = asignaturas.IdAsignatura.ToString();
            CodigoAsignaturaTextBox.Text = asignaturas.CodigoAsignatura;
            DescripcionTextBox.Text = asignaturas.Descripcion;
            CreditosTextBox.Text = asignaturas.Creditos.ToString();
            ProfesoresDropDownList.SelectedValue = asignaturas.IdProfesor.ToString();

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            CodigoAsignaturaTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
            CreditosTextBox.Text = " ";

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                asignaturas.IdAsignatura = Convert.ToInt32(CodigoTextBox.Text);

                if (asignaturas.Eliminar())
                {
                    LimpiarComponentes();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            asignaturas.Descripcion = DescripcionTextBox.Text;
            asignaturas.IdProfesor = Convert.ToInt32(ProfesoresDropDownList.SelectedValue.ToString());
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ControlPanel/Administrador/Consultas/AsignaturasWeb.aspx");
        }
    }
}