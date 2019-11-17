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
    /// Lógica de interacción para w_Reposo.xaml
    /// </summary>
    public partial class w_Reposo : Window
    {

        MediCsharp20Entities datos;
        public w_Reposo()
        {
            datos = new MediCsharp20Entities();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboNombreDoctor.ItemsSource = datos.Doctor.ToList();
            cboNombreDoctor.DisplayMemberPath = "NombreDoctor";
            cboNombreDoctor.SelectedValuePath = "Doctor_Id";


            cboNombrePaciente.ItemsSource = datos.Paciente.ToList();
            cboNombrePaciente.DisplayMemberPath = "NombrePaciente";
            cboNombrePaciente.SelectedValuePath = "Paciente_Id";
            CargarDatosGrilla();
        }


        private void CargarDatosGrilla()
        {
            try
            {
                dgReposo.ItemsSource = datos.Reposo.ToList();
                dgReposo.Columns[5].Visibility = Visibility.Hidden;
                dgReposo.Columns[6].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Reposo r = new Reposo();
            r.Doctor = (Doctor)cboNombreDoctor.SelectedItem;
            r.Paciente = (Paciente)cboNombrePaciente.SelectedItem;
            r.FechaDesde = dtpFechaDesde.SelectedDate;
            r.FechaHasta = dtpFechaHasta.SelectedDate;

            MessageBox.Show("Se ha Agregado Correctamente");

            datos.Reposo.Add(r);
            datos.SaveChanges();
            CargarDatosGrilla();
            LimpiarForm();
        }


        private void LimpiarForm()
        {
            txtId.Text = string.Empty;
            cboNombreDoctor.SelectedIndex = -1;
            cboNombrePaciente.SelectedIndex = -1;
            dtpFechaDesde.SelectedDate = DateTime.Now.Date;
            dtpFechaHasta.SelectedDate = DateTime.Now.Date;
        }
    }
}
