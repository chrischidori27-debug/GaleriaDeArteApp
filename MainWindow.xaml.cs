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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;

namespace AppWpfLogin2P2C
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaArchLogin = "C:\\Users\\CHRIS\\source\\repos\\AppWpfProyecto\\AppWpfLogin2P2C\\Usuarios\\singUp.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtCorreo.Text;
            string contra = pwdContraseña.Password;
            if (correo == "" || contra == "")
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "¡Debe llenar TODOS los campos!";
            }
            else
            {
                try
                {
                    if (!File.Exists(rutaArchLogin))
                    {
                        lblMensaje.Foreground = Brushes.Red;
                        lblMensaje.Content = "La ruta o el archivo no existen";
                        return;
                    }
                    else
                    {
                        var contenidoArch = File.ReadAllLines(rutaArchLogin);
                        foreach(var linea in contenidoArch)
                        {
                            var partes = linea.Split(',');
                            //if para encontrar usuario
                            if (correo.Equals(partes[0]) && contra.Equals(partes[1]) && partes[2] == "usuario")
                            {
                                WinPrincipal winU = new WinPrincipal();
                                winU.Show();
                                this.Close();
                            }
                            //if para encontrar administrador
                            else if(correo.Equals(partes[0]) && contra.Equals(partes[1]) && partes[2] == "administrador")
                            {
                                DataBinding winAd = new DataBinding();
                                winAd.Show(); 
                                this.Close();
                            }
                            else
                            {
                                lblMensaje.Foreground = Brushes.Red;
                                lblMensaje.Content = "Usuario no registrado... Posble impostor!";
                            }
                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                //string datos = txtCorreo.Text + "\n" + pwdContraseña.Password + "\n";
                //lblMensaje.Foreground = Brushes.Black;
                //lblMensaje.Content = datos;
            }
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            WinSing_Up winSingUp = new WinSing_Up();
            winSingUp.Show();
            this.Close();
        }

        private void btnRegistroAd_Click(object sender, RoutedEventArgs e)
        {
            RegistroAdmin winRegAdm = new RegistroAdmin();
            winRegAdm.Show();
            this.Close();
        }

        private void txtCorreo_LostFocus(object sender, RoutedEventArgs e) {
            string emailPattern = "^[a-zA-Z0-9._%$]{3,}@[a-zA-Z0-9._-]{3,}.[a-zA-Z]{2,}";
            if(!Regex.IsMatch(txtCorreo.Text, emailPattern))
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "Correo no valido";
                txtCorreo.Clear();
            }
        }
        private void pwdContraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            string pwdPattern = "^[a-zA-Z0-9.#]{8,}$";
            if (!Regex.IsMatch(pwdContraseña.Password, pwdPattern))
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "Contraseña no valido";
                pwdContraseña.Password = "";
            }
        }
    }
}
