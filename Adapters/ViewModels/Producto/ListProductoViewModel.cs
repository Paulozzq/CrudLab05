using Application.UseCases.Productos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Adapters.ViewModels.Producto
{
    public class ListProductoViewModel : INotifyPropertyChanged
    {
        public readonly GetAllProductosUseCase? _getAllProductosUseCase;
        public ObservableCollection<Domain.Entities.Producto> Productos { get; set; } = new();
        public ListProductoViewModel(GetAllProductosUseCase getAllProductosUseCase)
        {
            _getAllProductosUseCase = getAllProductosUseCase;
            CargarProductos();
        }
        private void CargarProductos()
        {
            if (_getAllProductosUseCase is null)
                return;
            var productos = _getAllProductosUseCase.Execute();
            Productos = new ObservableCollection<Domain.Entities.Producto>(productos);
            OnPropertyChanged(nameof(Productos));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
