using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControl5._1.ControlPanel.Administrador.Registros
{
    public partial class EvaluacionesGruposWeb : System.Web.UI.Page
    {
        private EvaluacionesGrupos evaluaciones = new EvaluacionesGrupos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (evaluaciones.Buscar(id))
                {
                    Buscar(id);

                }
                if (CodigoTextBox.Text == string.Empty)
                {
                    EliminarButton.Enabled = false;

                }
                else
                {
                    EliminarButton.Enabled = true;

                }

                GruposDropDownList.DataSource = Grupos.Listar("g.IdGrupo,( s.Periodo+'-'+a.Descripcion+'-'+p.Nombres+' '+p.Apellidos) as Descripcion ", " g, Semestres s, Asignaturas a, Profesores p");
                GruposDropDownList.DataValueField = "IdGrupo";
                GruposDropDownList.DataTextField = "Descripcion";
                GruposDropDownList.DataBind();

                TipoDropDownList.DataSource = TiposEvaluaciones.Listar("IdTipoEvaluacion as IdTipo, Descripcion", "1=1");
                TipoDropDownList.DataValueField = "IdTipo";
                TipoDropDownList.DataTextField = "Descripcion";
                TipoDropDownList.DataBind();

                Session.Abandon();
            }
        }

        private void Buscar(int idR)
        {
            GruposDropDownList.SelectedValue = evaluaciones.IdGrupo.ToString();
            TipoDropDownList.SelectedValue = evaluaciones.IdTipoEvaluacion.ToString();
            CodigoTextBox.Text = evaluaciones.IdEvaluacionGrupo.ToString();
            CantidadTextBox.Text = evaluaciones.CantidadEvaluaciones.ToString();
            DetalleGridView.DataSource = EvaluacionesDetalle.Listar("*", " IdEvaluacionGrupo='" + idR + "'");
            DetalleGridView.DataBind();
            Session.Abandon();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ControlPanel/Administrador/Consultas/EvaluacionesGruposWeb.aspx");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
        private void LimpiarComponentes()
        {
            CodigoTextBox.Text = " ";
            CantidadTextBox.Text = " ";
            PonderacionTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            GuardarButton.Enabled = true;
            if (CodigoTextBox.Text == string.Empty)
            {

                if (Session["evaluacion"] != null)
                {
                    evaluaciones = (EvaluacionesGrupos)Session["evaluacion"];
                }

                evaluaciones.agregarDetalle(DescripcionTextBox.Text, DateTime.ParseExact(FechaAsignacionTextBox.Text, "MM/dd/yyyy", null), DateTime.ParseExact(FechaEntregaTextBox.Text, "MM/dd/yyyy", null), Convert.ToInt32(TipoAsignacionDropDownList.SelectedValue.ToString()), Convert.ToInt32(PonderacionTextBox.Text), Convert.ToInt32(EstatusDropDownList.SelectedIndex));

                DetalleGridView.DataSource = evaluaciones.EvaluacionesDetalle;
                DetalleGridView.DataBind();

                Session["evaluacion"] = evaluaciones;
            }
            else
            {

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                evaluaciones.IdEvaluacionGrupo = Convert.ToInt32(CodigoTextBox.Text);
                if (evaluaciones.Eliminar())
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
            try
            {


                if (CodigoTextBox.Text == string.Empty)
                {

                    if (Session["evaluacion"] != null)
                    {
                        evaluaciones = (EvaluacionesGrupos)Session["evaluacion"];
                    }

                    evaluaciones.IdGrupo = Convert.ToInt32(GruposDropDownList.SelectedValue.ToString());
                    evaluaciones.IdTipoEvaluacion = Convert.ToInt32(TipoDropDownList.SelectedValue.ToString());
                    evaluaciones.CantidadEvaluaciones = Convert.ToInt32(CantidadTextBox.Text);
                    if (evaluaciones.Insertar())
                    {

                    }



                }
                else
                {
                    int id = 0;
                    int.TryParse(CodigoTextBox.Text, out id);
                    if (evaluaciones.Modificar())
                    {


                    }
                }
            }
            catch (Exception) { }
            
        }
    }
}