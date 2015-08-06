using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
   public class Semestres
    {
        public int IdSemestre { set; get; }
        public string Periodo { set; get; }
        public string Descripcion { set; get; }
        public DateTime Fechainicio { set; get; }
        public DateTime Fechafin { set; get; }
        public int IdProfesor { set; get; }
        private Conexion conexion = new Conexion();

        public Semestres()
        {
            IdSemestre = 0;
            Periodo = null;
            Descripcion = null;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("INSERT INTO Semestres(Periodo,Descripcion,Fechainicio,Fechafin,IdProfesor)VALUES('" + this.Periodo + "','" + this.Descripcion + "','" + this.Fechainicio.ToString("MM/dd/yyyy") + "','" + this.Fechafin.ToString("MM/dd/yyyy") + "','"+IdProfesor.ToString()+"')");
        }
        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE Semestres SET Periodo='" + this.Periodo + "', Descripcion='" + this.Descripcion + "', Fechainicio='" + this.Fechainicio.ToString("MM/dd/yyyy") + "', Fechafin='" + this.Fechafin.ToString("MM/dd/yyyy") + "' WHERE IdSemestre='" + this.IdSemestre + "'");
        }
        public bool Eliminar()
        {
            return conexion.EjecutarDB("DELETE FROM Semestres WHERE IdSemestre='" + this.IdSemestre + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Semestres where IdSemestre='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdSemestre = (int)dt.Rows[0]["IdSemestre"];
                Descripcion = dt.Rows[0]["Descripcion"].ToString();
                Periodo = dt.Rows[0]["Periodo"].ToString();
                Fechafin = (DateTime)dt.Rows[0]["Fechafin"];
                Fechainicio = (DateTime)dt.Rows[0]["Fechainicio"];
                IdProfesor = (int)dt.Rows[0]["IdProfesor"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Semestres where " + where);
        }
    }
}
