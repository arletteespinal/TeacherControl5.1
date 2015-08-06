using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CalificacionesEstudiantes
    {
        public int IdCalificacion { set; get; }
        public int IdGrupo { set; get; }
        public int IdEvaluacionesDetalle { set; get; }
        public List<CalificacionEstudiantesDetalle> CalificacionDetalle { set; get; }
        private Conexion conexion = new Conexion();

        public CalificacionesEstudiantes()
        {
            IdCalificacion = 0;
            IdGrupo = 0;
            IdEvaluacionesDetalle = 0;
            CalificacionDetalle = new List<CalificacionEstudiantesDetalle>();
        }

        public bool Insertar()
        {
            string comando = "";
            comando = "INSERT INTO CalificacionEstudiantes (IdGrupo ,IdEvaluacionesDetalle)VALUES('" + this.IdGrupo + "','" + this.IdEvaluacionesDetalle+ "')";

            foreach (CalificacionEstudiantesDetalle detalle in CalificacionDetalle)
            {
                comando += "INSERT INTO CalificacionEstudiantesDetalle  (IdCalificacion ,IdEstudiante, Calificacion ,FechaEntrega )VALUES('','" + detalle.IdEstudiante + "','" + detalle.Calificacion+ "','" + detalle.FechaEntregada + "')";
            }

            return conexion.EjecutarDB(comando);
        }

        public void agregarDetalle(int IdEstudiante,float Calificacion, DateTime Fecha)
        {
            CalificacionDetalle.Add(new CalificacionEstudiantesDetalle(IdEstudiante,Calificacion,Fecha));
        }

        public bool Modificar()
        {
            return false;
        }
        public bool Eliminar()
        {
            string comando = "";
            comando = "DELETE FROM CalificacionEstudiantesDetalle where IdCalificacion='" + this.IdCalificacion + "'";
            comando += "DELETE FROM CalificacionEstudiantes  WHERE IdCalificacion ='" + this.IdCalificacion + "'";
            return conexion.EjecutarDB(comando);
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from CalificacionEstudiantes  where IdCalificacion ='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdCalificacion = (int)dt.Rows[0]["IdCalificacion"];
                IdGrupo = (int)dt.Rows[0]["IdGrupo"];
                IdEvaluacionesDetalle = (int)dt.Rows[0]["IdEvaluacionesDetalle"];
            }
            return Retorno;
        }

        public DataTable Listar(string campos, string where)
        {
            return conexion.BuscarDb("Select " + campos + " from  CalificacionEstudiantes where " + where);
        }
    }
}
