using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Asignaturas
    {
        public int IdAsignatura { set; get; }
        public string CodigoAsignatura { set; get; }
        public string Descripcion { set; get; }
        public int Creditos { set; get; }
        public int IdProfesor { set; get; }
        private Conexion conexion = new Conexion();

        public Asignaturas()
        {
            IdAsignatura = 0;
            CodigoAsignatura = " ";
            Descripcion = " ";
            IdProfesor = 0;
            Creditos = 0;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("INSERT INTO Asignaturas(CodigoAsignatura,Descripcion,Creditos,IdProfesor)VALUES('" + this.CodigoAsignatura + "','" + this.Descripcion + "','" + this.Creditos + "','" + this.IdProfesor + "')");
        }
        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE Asignaturas SET CodigoAsignatura='" + this.CodigoAsignatura + "', Descripcion='" + this.Descripcion + "', Creditos='" + this.Creditos + "', IdProfesor='" + this.IdProfesor + "' WHERE IdAsignatura='" + this.IdAsignatura.ToString() + "'");
        }
        public bool Eliminar()
        {
            return conexion.EjecutarDB("DELETE FROM Asignaturas WHERE IdAsignatura='" + this.IdAsignatura + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Asignaturas where IdAsignatura='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdAsignatura = (int)dt.Rows[0]["IdAsignatura"];
                Descripcion = dt.Rows[0]["Descripcion"].ToString();
                CodigoAsignatura = dt.Rows[0]["CodigoAsignatura"].ToString();
                Creditos = (int)dt.Rows[0]["Creditos"];
                IdProfesor = (int)dt.Rows[0]["IdProfesor"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Asignaturas where " + where);
        }
    }
}
