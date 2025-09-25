using Domain.Entities;

namespace Application.IRepositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductos();
    }
}
