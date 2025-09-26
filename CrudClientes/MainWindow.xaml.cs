using Application.Services;
using Config;
using CrudClientes;
using Domain.Entities;
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

namespace CrudClientes
{
    public partial class MainWindow : Window
    {
        public readonly ClienteService _clienteService;
        public MainWindow()
        {
            InitializeComponent();
            _clienteService = ServiceFactory.CreateClienteService();
            LoadClientes();
        }

        private async void LoadClientes()
        {
            dgClientes.ItemsSource = null;
            if (_clienteService == null)
                return;
            var clientes = await _clienteService.GetAllClientes();
            dgClientes.ItemsSource = clientes;
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormCliente();
            if (form.ShowDialog() == true)
            {
                LoadClientes();
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem is Cliente clienteSeleccionado)
            {
                var form = new FormCliente(clienteSeleccionado);
                if (form.ShowDialog() == true)
                {
                    LoadClientes();
                }
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem is Cliente clienteSeleccionado)
            {
                if (MessageBox.Show($"¿Seguro que deseas desactivar al cliente {clienteSeleccionado.NombreCompañia}?",
                    "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Console.WriteLine($"IdCliente seleccionado: {clienteSeleccionado.IdCliente}");
                        await _clienteService.DeleteClienteLogic(clienteSeleccionado.IdCliente);
                        LoadClientes() ;

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Error al desactivar cliente: {ex.Message}");
                    }
                }
            }
        }

        private void dgClientes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            bool isSelected = dgClientes.SelectedItem != null;
            btnActualizar.IsEnabled = isSelected;
            btnEliminar.IsEnabled = isSelected;
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (_clienteService == null)
                return;

            string palabra = txtBuscar.Text.Trim();
            var resultados = await _clienteService.SearchClientes(palabra);
            dgClientes.ItemsSource = resultados;
        }
    }
}
