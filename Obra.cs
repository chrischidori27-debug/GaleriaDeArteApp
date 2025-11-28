using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWpfLogin2P2C
{
    public class Obra
    {
        //propiedades
        public string autor { get; set; }
        public double precio { get; set; }
        public int AnioDeCreacion { get; set; }
        public string estilo { get; set; }
        public string ImagenRuta { get; set; }
        //constructores
        public Obra()
        {
            this.autor = "No definido";
            this.precio = 0.0;
            this.AnioDeCreacion = 0;
            this.estilo = "No definido";
            this.ImagenRuta = "No definido";
        }
        public Obra(string a,double p,int anio ,string e, string img)
        {
            this.autor = a;
            this.precio = p;
            this.AnioDeCreacion = anio;
            this.estilo = e;
            this.ImagenRuta = img;
        }
        //funciones
        public string verDatos()
        {
            return (autor + " " + precio.ToString()+" "+AnioDeCreacion.ToString()+" "+estilo +" "+ ImagenRuta);
        }
    }
}
