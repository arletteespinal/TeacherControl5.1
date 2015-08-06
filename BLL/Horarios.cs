using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Horarios
    {
        public int IdHorario { set; get; }
        public int IdDia { set; get; }
        public string Dia { set; get; }
        public string HoraInicio { set; get; }
        public string HoraFin { set; get; }

        public Horarios(int IdDia,string Dia ,string HoraInicio, string HoraFin)
        {
            this.IdDia = IdDia;
            this.HoraInicio = HoraInicio;
            this.HoraFin = HoraFin;
            this.Dia = Dia;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Horarios where " + where);
        }
    }
}
