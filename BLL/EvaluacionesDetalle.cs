using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class EvaluacionesDetalle
    {
        public int IdEvaluacionDetalle { set; get; }
        public string Descripcion { set; get; }
        public int TipoAsignacion { set; get; }
        public DateTime FechaAsignacion { set; get; }
        public DateTime FechaEntrega { set; get; }
        public int Ponderacion { set; get; }
        public int Estatus { set; get; }

        public EvaluacionesDetalle(string Descripcion, DateTime Fecha, DateTime FechaA, int TipoAsignacion,int Ponderacion, int Estatus)
        {
            this.Descripcion = Descripcion;
            this.FechaEntrega = Fecha;
            this.Ponderacion = Ponderacion;
            this.Estatus = Estatus;
            this.TipoAsignacion = TipoAsignacion;
            this.FechaAsignacion = FechaA;
        }


        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from EvaluacionesGrupos  where " + where);
        }
    }
}
