using Application.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.IdCliente))
                throw new ArgumentException("El IdCliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.NombreCompañia))
                throw new ArgumentException("El NombreCompañia es obligatorio.");

            return await _clienteRepository.AddCliente(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAllClientes();
        }

        public async Task<Cliente?> GetClienteById(string idCliente)
        {
            if (string.IsNullOrWhiteSpace(idCliente))
                throw new ArgumentException("El IdCliente es obligatorio.");

            return await _clienteRepository.GetClienteById(idCliente);
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.IdCliente))
                throw new ArgumentException("El IdCliente es obligatorio para actualizar.");

            return await _clienteRepository.UpdateCliente(cliente);
        }

        public async Task<bool> DeleteCliente(string idCliente)
        {
            if (string.IsNullOrWhiteSpace(idCliente))
                throw new ArgumentException("El IdCliente es obligatorio para eliminar.");

            return await _clienteRepository.DeleteCliente(idCliente);
        }

        public async Task<bool> DeleteClienteLogic(string idCliente)
        {
            if (string.IsNullOrWhiteSpace(idCliente))
                throw new ArgumentException("El IdCliente es obligatorio para eliminar lógicamente.");

            return await _clienteRepository.DeleteClienteLogic(idCliente);
        }
        public async Task<IEnumerable<Cliente>> SearchClientes(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                return await _clienteRepository.GetAllClientes();

            return await _clienteRepository.SearchClientes(palabra);
        }
    }
}
