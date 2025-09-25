using Application.UseCases.Productos;
using Config;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var provider = CompositionRoot.BuildServiceProvider();
        var getAllProductosUseCase =
            provider.GetService<GetAllProductosUseCase>();
        var productos = getAllProductosUseCase.Execute();

        foreach (var p in productos)
        {
            Console.WriteLine($"{p.IdProducto} - {p.NombreProducto} - {p.PrecioUnidad}");
        }
    }
}