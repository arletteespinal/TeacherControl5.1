using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class EvaluacionesGrupos
    {
        public int IdEvaluacionGrupo { set; get; }
        public int IdGrupo { set; get; }
        public int IdTipoEvaluacion { set; get; }
        public int CantidadEvaluaciones { set; get; }
        public List<EvaluacionesDetalle> EvaluacionesDetalle { set; get; }
        private Conexion conexion = new Conexion();

        public EvaluacionesGrupos()
        {
            IdEvaluacionGrupo = 0;
            IdGrupo = 0;
            IdTipoEvaluacion = 0;
            CantidadEvaluaciones = 0;
            EvaluacionesDetalle = new List<EvaluacionesDetalle>();
        }

        public bool Insertar()
        {
            string comando = "";
            comando = "INSERT INTO EvaluacionesGrupos (IdGrupo ,IdTipoEvaluacion ,CantidadEvaluaciones)VALUES('" + this.IdGrupo + "','" + this.IdTipoEvaluacion + "','" + this.CantidadEvaluaciones + "')";
            string id = conexion.BuscarDb("select max(IdEvaluacionGrupo) as IdEvaluacionGrupo FROM EvaluacionesGrupos").ToString();

            foreach (EvaluacionesDetalle detalle in EvaluacionesDetalle)
            {
                comando += "INSERT INTO EvaluacionesGruposDetalle(IdEvaluacionGrupo ,Descripcion,TipoAsignacion ,FechaAsignacion,FechaEntrega,PoderacionEvaluacion,Estatus )VALUES('"+id+"','" + detalle.Descripcion + "','" + detalle.TipoAsignacion + "','" + detalle.FechaAsignacion + "','" + detalle.FechaEntrega+ "','" + detalle.Ponderacion + "','" + detalle.Estatus + "')";
            }

            return conexion.EjecutarDB(comando);
        }
        public void agregarDetalle(string Descripcion, DateTime Fecha,DateTime FechaA,int TipoAsignacion, int Ponderacion, int Estatus)
        {
            EvaluacionesDetalle.Add(new EvaluacionesDetalle(Descripcion, Fecha, FechaA, TipoAsignacion, Ponderacion, Estatus));
        }

        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE EvaluacionesGrupos  SET IdGrupo='" + this.IdGrupo + "', IdTipoEvaluacion='" + this.IdTipoEvaluacion + "', CantidadEvaluaciones='" + this.CantidadEvaluaciones + "' WHERE IdEvaluacionGrupo ='" + this.IdEvaluacionGrupo.ToString() + "'");
        }
        public bool Eliminar()
        {
            string comando = "";
            comando = "DELETE FROM EvaluacionesDetalle where IdEvaluacionGrupo='" + this.IdEvaluacionGrupo + "'";
            comando += "DELETE FROM EvaluacionesGrupos  WHERE IdEvaluacionGrupo ='" + this.IdEvaluacionGrupo + "'";
            return conexion.EjecutarDB(comando);
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from EvaluacionesGrupos  where IdEvaluacionGrupo ='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdEvaluacionGrupo = (int)dt.Rows[0]["IdEvaluacionGrupo "];
                IdGrupo = (int)dt.Rows[0]["IdGrupo"];
                IdTipoEvaluacion = (int)dt.Rows[0]["IdTipoEvaluacion"];
                CantidadEvaluaciones = (int)dt.Rows[0]["CantidadEvaluaciones"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from EvaluacionesGrupos  where " + where);
        }
    }
}
