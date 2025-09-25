using Adapters.ViewModels.Producto;
using Config;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;


namespace Crud
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private ServiceProvider? _serviceProvider;

        public App()
        {
            _serviceProvider = CompositionRoot.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            if (_serviceProvider is null)
                return;

            var mainWindow = new MainWindow(_serviceProvider.GetRequiredService<ListProductoViewModel>());
            mainWindow.Show();
        }

    }

}
