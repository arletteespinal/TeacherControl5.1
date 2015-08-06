using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DiasSemana
    {
        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from DiasSemana where " + where);
        }
    }
}
