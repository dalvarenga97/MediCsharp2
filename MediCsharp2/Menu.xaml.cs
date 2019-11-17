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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

       

        private void Doctores_Click(object sender, RoutedEventArgs e)
        {
            w_Doctor ventanaDoctor = new w_Doctor();
            ventanaDoctor.ShowDialog();
        }

        private void Pacientes_Click(object sender, RoutedEventArgs e)
        {
            w_Paciente ventanaPaciente = new w_Paciente();
            ventanaPaciente.ShowDialog();
        }

        private void Consultas_Click(object sender, RoutedEventArgs e)
        {
            w_Consulta ventanaConsulta = new w_Consulta();
            ventanaConsulta.ShowDialog();
        }
    }
}
