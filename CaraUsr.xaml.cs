using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppWpfLogin2P2C
{
    /// <summary>
    /// Lógica de interacción para CaraUsr.xaml
    /// </summary>
    public partial class CaraUsr : Window
    {
        private readonly string rutaArchImg = "C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\Usuarios";
        public ObservableCollection<Obra> ListaObras { get; set; }
        public Obra ObraSelect { get; set; }
        public CaraUsr()
        {
            InitializeComponent();
            ListaObras = new ObservableCollection<Obra>
            {
                new Obra("Picasso",2000,1754,"barroco","C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\images\\LogoLogin Mariposa.png"),
                new Obra("Leonidas",2000,1754,"ya tu sabe",rutaArchImg+"\\fondo.jpg\\"),
                new Obra("Adan",2000,1754,"barroco", rutaArchImg+"\\fondo.jpg\\"),
                new Obra("Picasso",2000,1754,"barroco", rutaArchImg+"\\fondo.jpg\\")
            };
            DataContext = this;
            lstBObras.ItemsSource = ListaObras;
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Obra Comprada");
            ListaObras.Remove(ObraSelect);
        }
        private void lstBObras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
