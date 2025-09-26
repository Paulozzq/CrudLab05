using Application.Services;
using Config;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrudProducto
{
    public partial class MainWindow : Window
    {
        public readonly ProductoService? _productoService;
        public MainWindow()
        {
            InitializeComponent();
            _productoService = ServiceFactory.CreateProductoService();
            LoadProductos();
        }
        private async void LoadProductos()
        {
            dgProductos.ItemsSource = null;
            if (_productoService == null)
                return;
            var productos = await _productoService.GetProductosAsync();
            dgProductos.ItemsSource = productos;

        }
    }
}