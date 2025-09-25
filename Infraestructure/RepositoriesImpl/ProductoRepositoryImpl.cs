using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.IRepositories;

namespace Infraestructure.RepositoriesImpl
{
    public class ProductoRepositoryImlp : IProductoRepository
    {
        public Task<IEnumerable<Producto>> GetAllProductos()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            var productos = new List<Producto>();
            using (var connection = DbConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_GetAllProductos";
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var producto = new Producto
                            {
                                IdProducto = reader.GetInt32(reader.GetOrdinal("IdProducto")),
                                NombreProducto = reader.GetString(reader.GetOrdinal("NombreProducto")),
                                IdProveedor = reader.GetInt32(reader.GetOrdinal("IdProveedor")),
                                IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria")),
                                CantidadPorUnidad = reader.GetString(reader.GetOrdinal("CantidadPorUnidad")),
                                PrecioUnidad = reader.GetDecimal(reader.GetOrdinal("PrecioUnidad")),
                                UnidadesEnExistencia = reader.GetInt16(reader.GetOrdinal("UnidadesEnExistencia")),
                                UnidadesEnPedido = reader.GetInt16(reader.GetOrdinal("UnidadesEnPedido")),
                                NivelNuevoPedido = reader.GetInt16(reader.GetOrdinal("NivelNuevoPedido")),
                                Suspendido = reader.GetInt16(reader.GetOrdinal("Suspendido"))
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }
    }
}

