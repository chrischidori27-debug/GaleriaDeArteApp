using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWpfLogin2P2C
{
    public class Venta
    {
        //Propiedades
        public string Codigo { get; set; }
        public string Espesificacion { get; set; }
        public Obra ObraVenta;
        //Constructores
        public Venta()
        {
            Codigo = "No Definido";
            Espesificacion = "No Definido";
            ObraVenta = new Obra();
        }
        public Venta(string cod, string Espe, Obra obra)
        {
            Codigo = cod;
            Espesificacion = Espe;
            ObraVenta = obra;
        }
        //Funcionalidad
    }
}
