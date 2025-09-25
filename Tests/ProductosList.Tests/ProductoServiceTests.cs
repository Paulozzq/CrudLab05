using Application.IRepositories;
using Application.Services;
using Application.UseCases.Productos;
using Domain.Entities;
using Moq;
using Xunit;

namespace ProductosList.Tests;

public class ProductoServiceTests
{
    [Fact]
    public void ReadProductos_DeberiaRetornarListaDeProductos()
    {
        var mockRepo = new Mock<IProductoRepository>();
        mockRepo.Setup(r => r.GetAllProductos())
                .Returns(new List<Producto>
                {
                        new Producto { IdProducto = 1, NombreProducto = "Teclado", PrecioUnidad = 50m },
                        new Producto { IdProducto = 2, NombreProducto = "Mouse", PrecioUnidad = 20m }
                });

        var useCase = new GetAllProductosUseCase(mockRepo.Object);
        var service = new ProductoService(useCase);

        var productos = service.ReadProductos();

        Assert.Equal(2, productos.Count());
        Assert.Contains(productos, p => p.NombreProducto == "Teclado");
        Assert.Contains(productos, p => p.NombreProducto == "Mouse");
    }
}
