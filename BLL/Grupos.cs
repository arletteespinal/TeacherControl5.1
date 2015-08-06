using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Grupos
    {
        public int IdGrupo { set; get; }
        public int IdSemestre { set; get; }
        public int IdAsignatura { set; get; }
        public int IdProfesor { set; get; }
        public int Estatus { set; get; }
        public List<Horarios> Horarios {set; get;} 
        private Conexion conexion = new Conexion();

        public Grupos()
        {
            IdGrupo = 0;
            IdSemestre = 0;
            IdAsignatura = 0;
            IdProfesor = 0;
            Estatus = 0;
            Horarios = new List<Horarios>();
        }

        public bool Insertar()
        {
            string comando = "";
            comando = "INSERT INTO Grupos(IdSemestre,IdAsignatura,IdProfesor,Estatus)VALUES('" + this.IdSemestre + "','" + this.IdAsignatura + "','" + this.IdProfesor + "','" + this.Estatus.ToString() + "')";
            
            foreach (Horarios detalle in Horarios)
            {
                comando += "insert into Horarios(IdGrupo,IdDia,HoraInicio,HoraFin)values((select max(IdGrupo) as IdGrupo from Grupos),'" + detalle.IdDia + "','" + detalle.HoraInicio + "','" + detalle.HoraFin + "')";
            }
            return conexion.EjecutarDB(comando);
        }

        public void agregarDetalle(int IdDia, string Dia,string HInicio, string HFin)
        {
            Horarios.Add(new Horarios(IdDia, Dia, HInicio, HFin));
        }

        public bool Modificar()
        {
            string comando = "";
            comando = "UPDATE Grupos SET IdSemestre='" + this.IdSemestre + "', IdAsignatura='" + this.IdAsignatura + "', IdProfesor='" + this.IdProfesor + "', Estatus='" + this.Estatus.ToString() + "' WHERE IdGrupo='" + this.IdGrupo.ToString() + "'";
            foreach (Horarios detalle in Horarios)
            {
                comando += "insert into Horarios(IdGrupo,IdDia,HoraInicio,HoraFin)values('','" + detalle.IdDia + "','" + detalle.HoraInicio + "','" + detalle.HoraFin + "')";
            }
            return conexion.EjecutarDB(comando);
        }
        public bool Eliminar()
        {
            string comando = "";
            comando = "delete from Horarios where IdGrupo='" + this.IdGrupo + "'";
            comando += "DELETE FROM Grupos WHERE IdGrupo='" + this.IdGrupo + "'";
            return conexion.EjecutarDB(comando);
        }

        public bool Buscar(int id)
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select * from Grupos where IdGrupo='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                IdGrupo = (int)dt.Rows[0]["IdGrupo"];
                IdSemestre = (int)dt.Rows[0]["IdSemestre"];
                IdAsignatura = (int)dt.Rows[0]["IdAsignatura"];
                IdProfesor = (int)dt.Rows[0]["IdProfesor"];
                Estatus = (int)dt.Rows[0]["Estatus"];
            }
            return Retorno;
        }

        public static DataTable Listar(string campos, string where)
        {
            Conexion conexion = new Conexion();
            return conexion.BuscarDb("Select " + campos + " from Grupos  " + where);
        }
    }
}
