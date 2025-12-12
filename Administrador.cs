using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWpfLogin2P2C
{
    public class Administrador : Usuario
    {

        public string Codigo { get; set; }  

        public Administrador(string nombre, string paterno, string materno, int anioNac, string correoElec, int telefono, string contraseña, string codigo)
            : base(nombre, paterno, materno, anioNac, correoElec, telefono, contraseña) 
        {
            Codigo = codigo;
        }

        public Administrador() : base()
        {
            Codigo = "";
        }
    }
}
