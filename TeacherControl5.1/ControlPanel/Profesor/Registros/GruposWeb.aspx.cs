using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherControl5._1.ControlPanel.Profesor.Registros
{
    public partial class GruposWeb : System.Web.UI.Page
    {
        private Grupos grupos = new Grupos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Codigo"], out id);
                if (grupos.Buscar(id))
                {
                    Buscar(id);

                }

                SemestreDropDownList.DataSource = Semestres.Listar("IdSemestre, Descripcion", "1=1");
                SemestreDropDownList.DataValueField = "IdSemestre";
                SemestreDropDownList.DataTextField = "Descripcion";
                SemestreDropDownList.DataBind();

                AsignaturaDropDownList.DataSource = Asignaturas.Listar("IdAsignatura, Descripcion", "1=1");
                AsignaturaDropDownList.DataValueField = "IdAsignatura";
                AsignaturaDropDownList.DataTextField = "Descripcion";
                AsignaturaDropDownList.DataBind();

                DiaDropDownList.DataSource = DiasSemana.Listar("IdDia, Descripcion", "1=1");
                DiaDropDownList.DataValueField = "IdDia";
                DiaDropDownList.DataTextField = "Descripcion";
                DiaDropDownList.DataBind();
            }
        }

        private void Buscar(int idR)
        {
            SemestreDropDownList.SelectedValue = grupos.IdSemestre.ToString();
            AsignaturaDropDownList.SelectedValue = grupos.IdAsignatura.ToString();
            CodigoTextBox.Text = grupos.IdGrupo.ToString();
            DetalleGridView.DataSource = Horarios.Listar("*", " IdGrupo='" + idR + "'");
            DetalleGridView.DataBind();
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            GuardarButton.Enabled = true;
            if (CodigoTextBox.Text == string.Empty)
            {

                if (Session["grupos"] != null)
                {
                    grupos = (Grupos)Session["grupos"];
                }

                grupos.agregarDetalle(Convert.ToInt16(DiaDropDownList.SelectedValue), DiaDropDownList.SelectedItem.ToString(), HoraInicioTextBox.Text, HoraFinTextBox.Text);

                DetalleGridView.DataSource = grupos.Horarios;
                DetalleGridView.DataBind();

                Session["grupos"] = grupos;
            }
            else
            {

            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {


                if (CodigoTextBox.Text == string.Empty)
                {

                    if (Session["grupos"] != null)
                    {
                        grupos = (Grupos)Session["grupos"];
                    }

                    //grupos.IdProfesor = Convert.ToInt32(ProfesoresDropDownList.SelectedValue.ToString());
                    grupos.IdSemestre = Convert.ToInt32(SemestreDropDownList.SelectedValue.ToString());
                    grupos.IdAsignatura = Convert.ToInt32(AsignaturaDropDownList.SelectedValue.ToString());
                    grupos.Estatus = Convert.ToInt32(EstatusDropDownList.SelectedIndex.ToString());



                    if (grupos.Insertar())
                    {

                    }



                }
                else
                {
                    int id = 0;
                    int.TryParse(CodigoTextBox.Text, out id);
                    if (grupos.Modificar())
                    {


                    }
                }
            }
            catch (Exception) { }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
        private void LimpiarComponentes()
        {
            HoraFinTextBox.Text = " ";
            HoraInicioTextBox.Text = " ";
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
            Session.Abandon();
            CodigoTextBox.Text = " ";
        }
    }
}