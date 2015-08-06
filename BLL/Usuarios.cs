using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Usuarios
    {
        public int IdUsuario { set; get; }
        public string Nombre { set; get; }
        public string Clave { set; get; }
        public int IdTipoUsuario { set; get; }
        public int Estatus { set; get; }
        private Conexion conexion = new Conexion();

        public Usuarios()
        {
            Nombre = null;
            Clave = null;
            IdTipoUsuario = 0;
            Estatus = 0;
            IdUsuario = 0;
        }

        public bool Insertar()
        {
            return conexion.EjecutarDB("INSERT INTO Usuarios(Nombre,Clave,IdTipoUsuario,Estatus)VALUES('" + this.Nombre + "','" + this.Clave + "','" + this.IdTipoUsuario.ToString() + "','" + this.Estatus.ToString() + "')");
        }

        public bool Modificar()
        {
            return conexion.EjecutarDB("UPDATE Usuarios SET Nombre='" + this.Nombre + "', Clave='" + this.Clave + "', IdTipoUsuario='" + this.IdTipoUsuario.ToString() + "', Estatus='" + this.Estatus.ToString() + "' WHERE IdUsuario='" + this.IdUsuario.ToString() + "'");
        }

        public bool Eliminar()
        {
            return conexion.EjecutarDB("DELETE FROM Usuarios WHERE IdUsuario='" + this.IdUsuario + "'");
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Usuarios where IdUsuario='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdUsuario = (int)dt.Rows[0]["IdUsuario"];
                Nombre = dt.Rows[0]["Nombre"].ToString();
                Clave = dt.Rows[0]["Clave"].ToString();
                IdTipoUsuario = (int)dt.Rows[0]["IdTipoUsuario"];
                Estatus = (int)dt.Rows[0]["Estatus"];
            }
            return Retorno;
        }

        public Boolean Autenticar(string NombreUsuario, string Clave)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();

            dt = conexion.BuscarDb("SELECT IdUsuario,IdTipoUsuario from Usuarios Where Nombre = '" + NombreUsuario + "' And Clave = '" + Clave + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdUsuario = (int)dt.Rows[0]["IdUsuario"];
                IdTipoUsuario = (int)dt.Rows[0]["IdTipoUsuario"];
            }

            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Usuarios where " + where);
        }

    }
}
