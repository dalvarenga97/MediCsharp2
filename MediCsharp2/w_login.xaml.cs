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

namespace MediCsharp2
{
    /// <summary>
    /// Lógica de interacción para w_login.xaml
    /// </summary>
    public partial class w_login : Window
    {
        public w_login()
        {
            InitializeComponent();
        }

        private async void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.email = txtUsuario.Text;
            usuario.password = txtContrasena.Password.ToString();
            if (await Usuario.login(usuario))
            {
                Menu menu = new Menu();
                Hide();
                menu.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
       
    }
}
