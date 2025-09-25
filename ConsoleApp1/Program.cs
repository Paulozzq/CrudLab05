using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

using Application.UseCases.Productos;
public class ConsoleApp1
{
    private readonly GetAllProductosUseCase _getAllProductosUseCase;

    public ConsoleApp1(GetAllProductosUseCase getAllProductosUseCase)
    {
        _getAllProductosUseCase = getAllProductosUseCase;
    }


    

    private static void Main(string[] args)
    {
        
    }
}
