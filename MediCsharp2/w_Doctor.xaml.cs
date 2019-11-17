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
    /// Lógica de interacción para w_Doctor.xaml
    /// </summary>
    public partial class w_Doctor : Window
    {
        MediCsharp20Entities datos;

        public w_Doctor()
        {
            InitializeComponent();
            datos = new MediCsharp20Entities();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                dgDoctor.ItemsSource = datos.Doctor.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LimpiarForm()
        {
            txtId.Text = string.Empty;
            txtNombreDoctor.Text = string.Empty;
            txtApellidoDoctor.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
            rdbF.IsChecked = true;
            txtEdad.Text = string.Empty;
            dtpFechaNac.SelectedDate = DateTime.Now.Date;
            txtTelefono.Text = string.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Doctor d = new Doctor();
            d.NombreDoctor = txtNombreDoctor.Text;
            d.ApellidoDoctor = txtApellidoDoctor.Text;
            d.especialidad = txtEspecialidad.Text;
            if (rdbF.IsChecked == true)
                d.sexo = rdbF.Content.ToString();
            else
                d.sexo = rdbM.Content.ToString();
            d.Edad = txtEdad.Text;
            d.FechaNacimiento = dtpFechaNac.DisplayDate;
            d.Telefono = txtTelefono.Text;

            MessageBox.Show("Se ha Agregado Correctamente");

            datos.Doctor.Add(d);
            datos.SaveChanges();
            CargarDatosGrilla();
            LimpiarForm();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgDoctor.SelectedItem != null)
            {
                Doctor d = (Doctor)dgDoctor.SelectedItem;
                d.NombreDoctor = txtNombreDoctor.Text;
                d.ApellidoDoctor = txtApellidoDoctor.Text;
                d.especialidad = txtEspecialidad.Text;
                if (rdbF.IsChecked == true)
                    d.sexo = rdbF.Content.ToString();
                else
                    d.sexo = rdbM.Content.ToString();
                d.Edad = txtEdad.Text;
                d.FechaNacimiento = dtpFechaNac.SelectedDate;
                d.Telefono = txtTelefono.Text;

                datos.Entry(d).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            MessageBox.Show("Se ha Modificado Correctamente!");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarForm();
        }

        private void dgDoctor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgDoctor.SelectedItem != null)
            {
                Doctor d = (Doctor)dgDoctor.SelectedItem;

                txtId.Text = d.Id.ToString();
                txtNombreDoctor.Text = d.NombreDoctor;
                txtApellidoDoctor.Text = d.ApellidoDoctor;
                txtEspecialidad.Text = d.especialidad;
                if (d.sexo.Equals("Femenino"))
                    rdbF.IsChecked = true;
                else
                    rdbM.IsChecked = true;
                txtEdad.Text = d.Edad;
                dtpFechaNac.SelectedDate = d.FechaNacimiento.Value;
                txtTelefono.Text = d.Telefono;
            }
            else
            {
                MessageBox.Show("Debe Seleccionar al menos un Doctor");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgDoctor.SelectedItem != null)
            {
                Doctor d = (Doctor)dgDoctor.SelectedItem;

                datos.Entry(d).State = System.Data.Entity.EntityState.Deleted;
                datos.SaveChanges();
                CargarDatosGrilla();
                LimpiarForm();
            }
            MessageBox.Show("Se ha Eliminado Correctamente!!");
        }




    }
}
