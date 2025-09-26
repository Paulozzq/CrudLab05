using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Application.Services;
using Infraestructure.RepositoriesImpl;

namespace Config
{
    public static class ServiceFactory
    {
        public static ProductoService CreateProductoService()
        {
            IProductoRepository productoRepository = new ProductoRepositoryImlp();
            return new ProductoService(productoRepository);
        }

        public static ClienteService CreateClienteService()
        {
            IClienteRepository clienteRepository = new ClienteRepositoryImpl();
            return new ClienteService(clienteRepository);
        }
    }
}
