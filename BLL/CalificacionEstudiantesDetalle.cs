using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CalificacionEstudiantesDetalle
    {
        public int IdCalificacionDetalle { set; get; }
        public int IdEstudiante { set; get; }
        public float Calificacion { set; get; }
        public DateTime FechaEntregada { set; get; }

        public CalificacionEstudiantesDetalle(int IdEstudiante,float Calificacion, DateTime Fecha)
        {
            this.Calificacion = Calificacion;
            this.IdEstudiante = IdEstudiante;
            this.FechaEntregada = Fecha;
        }
    }
}
