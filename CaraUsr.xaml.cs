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
using System.IO;
using System.Text.RegularExpressions;

namespace AppWpfLogin2P2C
{
    /// <summary>
    /// Lógica de interacción para CaraUsr.xaml
    /// </summary>
    public partial class CaraUsr : Window
    {
        private readonly string rutaArchObras = "C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\Usuarios\\Obras.txt";
        public ObservableCollection<Obra> ListaObras { get; set; }
        public Obra ObraSelect { get; set; }
        public CaraUsr()
        {
            InitializeComponent();
            ListaObras = new ObservableCollection<Obra>
            {
            };
            DataContext = this;
            lstBObras.ItemsSource = ListaObras;
            AgregarObras();
        }
        public void AgregarObras()
        {
            var contenidoArch = File.ReadAllLines(rutaArchObras);
            foreach (var linea in contenidoArch)
            {
                var partes = linea.Split(',');
                Obra ObraAgregada = new Obra(partes[0], double.Parse(partes[1]), int.Parse(partes[2]), partes[3], @partes[4]);
                ListaObras.Add(ObraAgregada);
            }
        }
        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Obra Comprada");
            ListaObras.Remove(ObraSelect);
        }
        private void lstBObras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winSingUp = new MainWindow();
            winSingUp.Show();
            this.Close();
        }
    }
}
