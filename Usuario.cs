using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWpfLogin2P2C
{
    public class Usuario
    {
        //Propiedades
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int AnioNac { get; set; }
        public string CorreoElec { get; set; }
        public int Telefono { get; set; }
        public string Contraseña { get; set; }
        //Constructores
        public Usuario(string nombre, string paterno, string materno, int anioNac, string correoElec, int telefono, string contraseña)
        {
            Nombre = nombre;
            Paterno = paterno;
            Materno = materno;
            AnioNac = anioNac;
            CorreoElec = correoElec;
            Telefono = telefono;
            Contraseña = contraseña;
        }
        public Usuario()
        {
            Nombre = "";
            Paterno = "";
            Materno = "";
            AnioNac = 0;
            CorreoElec = "";
            Telefono = 0;
            Contraseña = "";
        }
        //Funcionalidad
    }
}
