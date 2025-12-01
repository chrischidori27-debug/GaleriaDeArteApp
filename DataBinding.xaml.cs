using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;

namespace AppWpfLogin2P2C
{
    /// <summary>
    /// Lógica de interacción para DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        public ObservableCollection<Obra> ListaObras { get; set; }
        public Obra ObraSelect { get; set; }
        string rutaimg;
        public DataBinding()
        {
            InitializeComponent();
            ListaObras = new ObservableCollection<Obra>
            {
            };
            DataContext = this;
            lstBObras.ItemsSource = ListaObras;
        }

        private void btnAgregarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Imágenes|*.jpg;*.jpeg;*.png";

            bool? result = img.ShowDialog();
            
            if (result == true)
            {
                ImagenSelec.Source = new BitmapImage(new Uri(img.FileName));
                //string destino = System.IO.Path.Combine("C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\ImagenesG\\", System.IO.Path.GetFileName(img.FileName));
                //File.Copy(img.FileName, destino, true);
            }
            rutaimg = img.FileName;
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            ListaObras.Remove(ObraSelect);
            txtAutor.Clear();
            txtPrecio.Clear();
            txtAnioCreacion.Clear();
            txtEstilo.Clear();
            ImagenSelec.Source = null;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string autor = txtAutor.Text;
            double precio = double.Parse(txtPrecio.Text);
            int anio = int.Parse(txtAnioCreacion.Text);
            string estilo = txtEstilo.Text;
            ListaObras.Add(new Obra(autor, precio, anio, estilo, rutaimg));
            txtAutor.Clear();
            txtPrecio.Clear();
            txtAnioCreacion.Clear();
            txtEstilo.Clear();
            ImagenSelec.Source = null;
        }

        private void lstBObras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ObraSelect != null)
            {
                txtAutor.Text = ObraSelect.autor;
                txtPrecio.Text =  ObraSelect.precio.ToString();
                txtAnioCreacion.Text = ObraSelect.AnioDeCreacion.ToString();
                txtEstilo.Text = ObraSelect.estilo;
                ImagenSelec.Source = new BitmapImage(new Uri(ObraSelect.ImagenRuta, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
