using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppWpfLogin2P2C
{
    /// <summary>
    /// Lógica de interacción para DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        private readonly string rutaArchLogin = "C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\Usuarios\\Obras.txt";
        private readonly string rutaArchObras = "C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\Usuarios\\Obras.txt";
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
            cmbEstilo.SelectedItem = null;
            ImagenSelec.Source = null;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtAutor.Text == "" || txtPrecio.Text == "" || txtAnioCreacion.Text == "")
            {
                MessageBox.Show("DEBEN LLENARSE TODAS LAS OBRAS");
            }
            else
            {
                string letterPattern = "^[A-Za-zñ]+$";
                string numericPattern = "^[0-9]+$";
                if (!Regex.IsMatch(txtAutor.Text, letterPattern))
                {
                    MessageBox.Show("El formato del Autor es incorrecto");
                    txtAutor.Clear();
                    txtAutor.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtPrecio.Text, numericPattern))
                {
                    MessageBox.Show("El formato del precio es incorrecto");
                    txtPrecio.Clear();
                    txtPrecio.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtAnioCreacion.Text, numericPattern))
                {
                    MessageBox.Show("El formato del año de nacimento es incorrecto");
                    txtPrecio.Clear();
                    txtPrecio.Focus();
                    return;
                }
                string autor = txtAutor.Text;
                double precio = double.Parse(txtPrecio.Text);
                int anio = int.Parse(txtAnioCreacion.Text);
                ComboBoxItem select = cmbEstilo.SelectedItem as ComboBoxItem;
                string estilo = select.Content.ToString();

                Obra obraAgregada = new Obra(autor, precio, anio, estilo, rutaimg);

                string datos = obraAgregada.autor + "," + obraAgregada.precio.ToString() + "," + obraAgregada.AnioDeCreacion.ToString()
                    + "," + obraAgregada.estilo + "," + obraAgregada.ImagenRuta + "\n";

                File.AppendAllText(rutaArchLogin, datos, Encoding.UTF8);

                ListaObras.Add(obraAgregada);
                txtAutor.Clear();
                txtPrecio.Clear();
                txtAnioCreacion.Clear();
                cmbEstilo.SelectedItem = null;
                ImagenSelec.Source = null;
            }
        }

        private void lstBObras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ObraSelect != null)
            {
                txtAutor.Text = ObraSelect.autor;
                txtPrecio.Text =  ObraSelect.precio.ToString();
                txtAnioCreacion.Text = ObraSelect.AnioDeCreacion.ToString();
                cmbEstilo.SelectedItem = ObraSelect.estilo;
                ImagenSelec.Source = new BitmapImage(new Uri(ObraSelect.ImagenRuta, UriKind.RelativeOrAbsolute));
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winSingUp = new MainWindow();
            winSingUp.Show();
            this.Close();
        }
    }
}
