using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
   public class Inscripciones
    {
        public int IdInscripcion { set; get; }
        public int IdEstudiante { set; get; }
        public int IdGrupo { set; get; }
        public int Estatus { set; get; }
        private Conexion conexion = new Conexion();

        public Inscripciones()
        {
            IdEstudiante = 0;
            IdInscripcion = 0;
            IdGrupo = 0;
            Estatus = 0;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("INSERT INTO Inscripciones(IdEstudiante,IdGrupo,Estatus)VALUES('" + this.IdEstudiante + "','" + this.IdGrupo + "','" + this.Estatus + "')");
        }
        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE Inscripciones SET IdEstudiante='" + this.IdEstudiante + "', IdGrupo='" + this.IdGrupo + "', Estatus='" + this.Estatus + "' WHERE IdInscripcion='" + this.IdInscripcion.ToString() + "'");
        }
        public bool Eliminar()
        {
            return conexion.EjecutarDB("DELETE FROM Inscripciones WHERE IdInscripcion='" + this.IdInscripcion + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Inscripciones where IdInscripcion='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdInscripcion = (int)dt.Rows[0]["IdInscripcion"];
                Estatus = (int)dt.Rows[0]["Estatus"];
                IdEstudiante = (int)dt.Rows[0]["IdEstudiante"];
                IdGrupo = (int)dt.Rows[0]["IdGrupo"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Inscripciones " + where);
        }
    }
}
