using Application.Services;
using Config;
using Domain.Entities;
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

namespace CrudClientes
{
    /// <summary>
    /// Lógica de interacción para FormCliente.xaml
    /// </summary>
    public partial class FormCliente : Window
    {
        public readonly ClienteService _clienteService;
        private readonly bool isEditMode;
        private Cliente clienteActual;
        public FormCliente()
        {
            InitializeComponent();
            _clienteService = ServiceFactory.CreateClienteService();
            isEditMode = false;
        }
        public FormCliente(Cliente cliente) : this()
        {
            isEditMode = true;
            clienteActual = cliente;

            txtIdCliente.Text = cliente.IdCliente;
            txtNombreCompañia.Text = cliente.NombreCompañia;
            txtNombreContacto.Text = cliente.NombreContacto;
            txtCargoContacto.Text = cliente.CargoContacto;
            txtDireccion.Text = cliente.Direccion;
            txtCiudad.Text = cliente.Ciudad;
            txtRegion.Text = cliente.Region;
            txtCodPostal.Text = cliente.CodPostal;
            txtPais.Text = cliente.Pais;
            txtTelefono.Text = cliente.Telefono;
            txtFax.Text = cliente.Fax;

            txtIdCliente.IsEnabled = false;
        }
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    IdCliente = txtIdCliente.Text,
                    NombreCompañia = txtNombreCompañia.Text,
                    NombreContacto = txtNombreContacto.Text,
                    CargoContacto = txtCargoContacto.Text,
                    Direccion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    Region = txtRegion.Text,
                    CodPostal = txtCodPostal.Text,
                    Pais = txtPais.Text,
                    Telefono = txtTelefono.Text,
                    Fax = txtFax.Text
                };

                if (isEditMode)
                {
                    await _clienteService.UpdateCliente(cliente);
                    MessageBox.Show("Cliente actualizado correctamente.");
                }
                else
                {
                    await _clienteService.AddCliente(cliente);
                    MessageBox.Show("Cliente agregado correctamente.");
                }

                DialogResult = true;
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error al guardar cliente: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
