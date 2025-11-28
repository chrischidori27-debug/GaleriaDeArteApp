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
using System.IO;
using System.Text.RegularExpressions;

namespace AppWpfLogin2P2C
{
    /// <summary>
    /// Lógica de interacción para WinSing_Up.xaml
    /// </summary>
    public partial class WinSing_Up : Window
    {
        private readonly string rutaArchLogin = "E:\\Sing Up\\singUp.txt";
        public WinSing_Up()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //bool swEntrada = false;
            if (txtNombre.Text == "" || txtAñoNacimiento.Text == "" || txtCelular.Text == "" || txtMaterno.Text == "" ||
                txtPaterno.Text == "" || pwdContraseña.Password == "")
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "debe llenar TODOS los campos!";
            }
            else
            {
              //los campos no estan vacios
                string letterPattern = "^[A-Za-z]+$";
                string numericPattern = "^[0-9]{4,8}$";
                if (!Regex.IsMatch(txtNombre.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Nombre es incorrecto";
                    txtNombre.Clear();
                    txtNombre.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtMaterno.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Apellido Materno es incorrecto";
                    txtMaterno.Clear();
                    txtMaterno.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtPaterno.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Apellido Paterno es incorrecto";
                    txtPaterno.Clear();
                    txtPaterno.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtCelular.Text, numericPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del celular es incorrecto";
                    txtCelular.Clear();
                    txtCelular.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtAñoNacimiento.Text, numericPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del año de nacimiento es incorrecto";
                    txtAñoNacimiento.Clear();
                    txtAñoNacimiento.Focus();
                    return;
                }
                if (!txtCorreo.Text.Contains("@gmail.com"))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del correo no es correcto";
                    txtCorreo.Clear();
                    txtCorreo.Focus();
                    return;
                }
                string paswordPattern = "^[a-zA-Z0-9.#]{8,}$";
                if (!Regex.IsMatch(pwdContraseña.Password, paswordPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "La contraseña debe tener numero, letras, . o #";
                    if(pwdContraseña.Password.Length < 8)
                    {
                        lblMensaje.Content = "La contraseña debe tener un minimo de 8 caractes";
                    }
                    pwdContraseña.Clear();
                    pwdContraseña.Focus();
                    return;
                }
                //crear el correo a partir del nombre de
                //string correo = txtNombre.Text.ToLower()[0] + txtPaterno.Text.ToLower() + txtMaterno.Text.ToLower()[0] + "@univalle.edu";
                //colocar todos los datos en una cadena para guardarla en el archivo
                string datos = txtCorreo.Text.Trim() +"," +  pwdContraseña.Password+"," + txtNombre.Text.Trim() + " " + txtPaterno.Text.Trim() + " " + txtMaterno.Text.Trim() + "," +
                               txtCelular.Text.Trim()  + "," + txtAñoNacimiento.Text.Trim()+"\n";
                //guardar en el archivo: rutArchLigin = "C:\\singup\\RegistroUsrs.txt"
                File.AppendAllText(rutaArchLogin, datos, Encoding.UTF8);

                lblMensaje.Foreground = Brushes.Black;
                lblMensaje.Content = "Bienvenido" + txtNombre.Text + " !";

                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

    }
}
