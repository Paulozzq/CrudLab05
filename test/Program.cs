using Application.Services;
using System;
using System.Collections.Generic;
using Domain.Entities;

class Program
{
    static void Main()
    {
        var productoService = new ProductoService();

        IEnumerable<Producto> productos = productoService.ReadProductos();

        Console.WriteLine("Productos encontrados:");
        foreach (var p in productos)
        {
            Console.WriteLine($"Id: {p.IdProducto}, Nombre: {p.NombreProducto}, Precio: {p.PrecioUnidad}");
        }
    }
}
