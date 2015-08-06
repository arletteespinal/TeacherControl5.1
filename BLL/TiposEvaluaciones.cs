using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TiposEvaluaciones
    {
        public int IdTipoEvaluacion { set; get; }
        public string Descripcion { set; get; }
        public int IdProfesor { set; get; }
        public int Estatus { set; get; }
        private Conexion conexion = new Conexion();

        public TiposEvaluaciones()
        {
            IdTipoEvaluacion = 0;
            IdProfesor = 0;
            Descripcion = "";
            Estatus = 0;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("insert into TiposEvaluaciones(Descripcion,IdProfesor,Estatus)values('" + this.Descripcion + "','" + this.IdProfesor + "','" + this.Estatus + "')");
        }

        public bool Modificar()
        {
            return conexion.EjecutarDB("update TiposEvaluaciones set Descripcion='" + this.Descripcion + "',IdProfesor='" + this.IdProfesor + "',Estatus='" + this.Estatus + "' where IdTipoEvaluacion='" + this.IdTipoEvaluacion + "'");
        }

        public bool Eliminar()
        {
            return conexion.EjecutarDB("delete from TiposEvaluaciones where IdTipoEvaluacion='" + this.IdTipoEvaluacion + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from TiposEvaluaciones where IdTipoEvaluacion='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdTipoEvaluacion = (int)dt.Rows[0]["IdTipoEvaluacion"];
                Descripcion = dt.Rows[0]["Descripcion"].ToString();
                IdProfesor = (int)dt.Rows[0]["IdProfesor"];
                Estatus = (int)dt.Rows[0]["Estatus"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from TiposEvaluaciones where " + where);
        }
    }
}
