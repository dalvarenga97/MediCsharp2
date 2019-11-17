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
    /// Lógica de interacción para w_Consulta.xaml
    /// </summary>
    public partial class w_Consulta : Window
    {
        MediCsharp19Entities datos;
        public w_Consulta()
        {
            datos = new MediCsharp19Entities();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboNombreDoctor.ItemsSource = datos.Doctor.ToList();
            cboNombreDoctor.DisplayMemberPath = "NombreDoctor";
            cboNombreDoctor.SelectedValuePath = "NombreDoctor";


            cboNombrePaciente.ItemsSource = datos.Paciente.ToList();
            cboNombrePaciente.DisplayMemberPath = "NombrePaciente";
            cboNombrePaciente.SelectedValuePath = "NombrePaciente";
            CargarDatosGrilla();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Consulta c = new Consulta();
            c.Doctor = (Doctor)cboNombreDoctor.SelectedItem;
            c.Paciente = (Paciente)cboNombrePaciente.SelectedItem;
            c.FechaConsulta = dtpFechaConsulta.DisplayDate;
            c.Diagnostico = txtDiagnostico.Text;
            MessageBox.Show("Se ha Agregado Correctamente");

            datos.Consulta.Add(c);
            datos.SaveChanges();
            CargarDatosGrilla();
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            txtId.Text = string.Empty;
            cboNombreDoctor.SelectedIndex = -1;
            cboNombrePaciente.SelectedIndex = -1;            
            dtpFechaConsulta.SelectedDate = DateTime.Now.Date;
            txtDiagnostico.Text = string.Empty;
        }


        private void CargarDatosGrilla()
        {
            try
            {
                dgConsultas.ItemsSource = datos.Consulta.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
