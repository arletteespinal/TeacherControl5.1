using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Estudiantes
    {

        public int IdEstudiante { set; get; }
        public string Matricula { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Documento { set; get; }
        public int IdTipoDocumento { set; get; }
        public string Email { set; get; }
        public string Telefono { set; get; }
        public int Genero { set; get; }
        private Conexion conexion = new Conexion();

        public Estudiantes()
        {
            IdEstudiante = 0;
            Matricula = null;
            Nombres = null;
            Apellidos = null;
            Documento = null;
            IdTipoDocumento = 0;
            Email = null;
            Telefono = null;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("INSERT INTO Estudiantes(IdEstudiante,Matricula,Nombres,Apellidos,Genero,Documento,IdTipoDocumento,Email,Telefono)VALUES('" + this.Matricula + "','" + this.Nombres + "','" + this.Apellidos+"','"+this.Genero + "','" + this.Documento + "','" + this.IdTipoDocumento + "','" + this.Email + "','" + this.Telefono + "')");
        }
        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE Estudiantes SET Matricula ='" + this.Matricula + "', Nombres='" + this.Nombres + "', Apellidos='" + this.Apellidos+"',Genero='"+this.Genero + "', Documento='" + this.Documento + "', IdTipoDocumento='" + this.IdTipoDocumento + "', Email='" + this.Email + "', Telefono='" + this.Telefono + "' WHERE IdEstudiante='" + this.IdEstudiante.ToString() + "'");
        }
        public bool Eliminar()
        {
            return conexion.EjecutarDB("DELETE FROM Estudiantes WHERE IdEstudiante='" + this.IdEstudiante + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Estudiantes where IdEstudiante='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdEstudiante = (int)dt.Rows[0]["IdEstudiante"];
                Matricula = dt.Rows[0]["Matricula"].ToString();
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
            return conexion.BuscarDb("Select " + campos + " from Estudiantes where " + where);
        }
    }
}
