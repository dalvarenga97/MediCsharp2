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
    /// Lógica de interacción para w_Paciente.xaml
    /// </summary>
    public partial class w_Paciente : Window
    {
        MediCsharp20Entities datos;
        public w_Paciente()
        {
            InitializeComponent();
            datos = new MediCsharp20Entities();
        }
        void CargarGrilla()
        {
            dgPacientes.ItemsSource = datos.Paciente.ToList();
        }

        void limpiar()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEdad.Text = string.Empty;
            rdbMasculino.IsChecked = true;
            dtpFecha.SelectedDate = DateTime.Now.Date;
            txtTelefono.Text = string.Empty;
        }

       
        private void dgPacientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgPacientes.SelectedItem != null)
            {
                Paciente P = (Paciente)dgPacientes.SelectedItem;

                txtId.Text = P.Id.ToString();
                txtNombre.Text = P.NombrePaciente;
                txtApellido.Text = P.ApellidoPaciente;
                txtEdad.Text = P.Edad;
                if (P.sexo.Equals("Masculino"))
                    rdbMasculino.IsChecked = true;
                else
                    rdbFemenino.IsChecked = true;

                dtpFecha.SelectedDate = P.FechaNacimiento.Value;
                txtTelefono.Text = P.Telefono;


            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Paciente P = new Paciente();
            P.NombrePaciente = txtNombre.Text;
            P.ApellidoPaciente = txtApellido.Text;
            P.Edad = txtEdad.Text;
            if (rdbMasculino.IsChecked == true)
                P.sexo = rdbMasculino.Content.ToString();
            else
                P.sexo = rdbFemenino.Content.ToString();

            P.FechaNacimiento = dtpFecha.SelectedDate;
            P.Telefono = txtTelefono.Text;
            MessageBox.Show("Se ha Agregado Correctamente");

            datos.Paciente.Add(P);
            datos.SaveChanges();
            CargarGrilla();
            limpiar();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPacientes.SelectedItem != null)
            {
                Paciente P = (Paciente)dgPacientes.SelectedItem;

                P.NombrePaciente = txtNombre.Text;
                P.ApellidoPaciente = txtApellido.Text;
                P.Edad = txtEdad.Text;

                if (rdbMasculino.IsChecked == true)
                    P.sexo = rdbMasculino.Content.ToString();
                else
                    P.sexo = rdbFemenino.Content.ToString();

                P.FechaNacimiento = dtpFecha.SelectedDate;
                P.Telefono = txtTelefono.Text;
                MessageBox.Show("Se ha Modificado Correctamente!");

                datos.Entry(P).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                CargarGrilla();
                limpiar();

            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPacientes.SelectedItem != null)
            {
                Paciente P = (Paciente)dgPacientes.SelectedItem;

                datos.Paciente.Remove(P);
                datos.SaveChanges();
                CargarGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar una Paciente de la grilla para eliminar!");
            limpiar();
        }

    }
}
