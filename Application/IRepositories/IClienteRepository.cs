using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente?> GetClienteById(string idCliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(string idCliente);
        Task<bool> DeleteClienteLogic(string idCliente);
    }
}
