using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Profesores
    {
        public int IdProfesor { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Documento { set; get; }
        public int IdTipoDocumento { set; get; }
        public string Email { set; get; }
        public string Telefono { set; get; }
        public int Genero { set; get; }
        private Conexion conexion = new Conexion();

        public Profesores()
        {
            IdProfesor = 0;
            Nombres = null;
            Apellidos = null;
            Documento = null;
            IdTipoDocumento = 0;
            Email = null;
            Telefono = null;
            Genero = 0;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("INSERT INTO Profesores(Nombres,Apellidos,Genero,Email,Telefono,Documento,IdTipoDocumento)VALUES('" + this.Nombres + "','" + this.Apellidos +"','"+this.Genero+ "','" + this.Email + "','" + this.Telefono + "','" + this.Documento + "','" + this.IdTipoDocumento + "')");
        }
        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE Profesores SET Nombres='" + this.Nombres + "', Apellidos='" + this.Apellidos + "',Genero='" + this.Genero + "', Email='" + this.Email + "', Telefono='" + this.Telefono + "', Documento='" + this.Documento + "', IdTipoDocumento='" + this.IdTipoDocumento + "'  WHERE IdProfesor='" + this.IdProfesor.ToString() + "'");
        }
        public bool Eliminar()
        {
            return conexion.EjecutarDB("DELETE FROM Profesores WHERE IdIdProfesor='" + this.IdProfesor + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Profesores where IdProfesor='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdProfesor = (int)dt.Rows[0]["IdProfesor"];
                Nombres = dt.Rows[0]["Nombres"].ToString();
                Apellidos = dt.Rows[0]["Apellidos"].ToString();
                Documento = dt.Rows[0]["Documento"].ToString();
                IdTipoDocumento = (int)dt.Rows[0]["IdTipoDocumento"];
                Email = dt.Rows[0]["Email"].ToString();
                Telefono = dt.Rows[0]["Telefono"].ToString();
                Genero=(int)dt.Rows[0]["Genero"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Profesores where " + where);
        }
    }
}
