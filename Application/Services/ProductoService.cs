using Application.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository? _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            try
            {
                if (_productoRepository == null)
                    throw new InvalidOperationException("_productoRepository es nulo.");

                return await _productoRepository.GetAllProductos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw new ApplicationException("Error al obtener los productos", ex);
            }
        }
    }
}
