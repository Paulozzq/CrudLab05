using Application.IRepositories;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.RepositoriesImpl
{
    public class ClienteRepositoryImpl : IClienteRepository
    {
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            try
            {
                using (var conn = DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_AddCliente", (SqlConnection)conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@NombreCompañia", cliente.NombreCompañia);
                        cmd.Parameters.AddWithValue("@NombreContacto", (object?)cliente.NombreContacto ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CargoContacto", (object?)cliente.CargoContacto ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Direccion", (object?)cliente.Direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ciudad", (object?)cliente.Ciudad ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Region", (object?)cliente.Region ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CodPostal", (object?)cliente.CodPostal ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Pais", (object?)cliente.Pais ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Telefono", (object?)cliente.Telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Fax", (object?)cliente.Fax ?? DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar cliente", ex);
            }
        }

        public async Task<bool> DeleteCliente(string idCliente)
        {
            try
            {
                using (var conn = DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_DeleteCliente", (SqlConnection)conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente", ex);
            }
        }

        public async Task<bool> DeleteClienteLogic(string idCliente)
        {
            try
            {
                using (SqlConnection conn = (SqlConnection)DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_DeleteClienteLogic", conn)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente lógicamente", ex);
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var conn = DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetAllClientes", (SqlConnection)conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var cliente = new Cliente
                                {
                                    IdCliente = reader["IdCliente"].ToString(),
                                    NombreCompañia = reader["NombreCompañia"].ToString(),
                                    NombreContacto = reader["NombreContacto"] as string,
                                    CargoContacto = reader["CargoContacto"] as string,
                                    Direccion = reader["Direccion"] as string,
                                    Ciudad = reader["Ciudad"] as string,
                                    Region = reader["Region"] as string,
                                    CodPostal = reader["CodPostal"] as string,
                                    Pais = reader["Pais"] as string,
                                    Telefono = reader["Telefono"] as string,
                                    Fax = reader["Fax"] as string
                                };

                                clientes.Add(cliente);
                            }
                        }
                    }
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes", ex);
            }
        }

        public async Task<Cliente?> GetClienteById(string idCliente)
        {
            try
            {
                using (var conn = DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetClienteById", (SqlConnection)conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Cliente
                                {
                                    IdCliente = reader["IdCliente"].ToString(),
                                    NombreCompañia = reader["NombreCompañia"].ToString(),
                                    NombreContacto = reader["NombreContacto"] as string,
                                    CargoContacto = reader["CargoContacto"] as string,
                                    Direccion = reader["Direccion"] as string,
                                    Ciudad = reader["Ciudad"] as string,
                                    Region = reader["Region"] as string,
                                    CodPostal = reader["CodPostal"] as string,
                                    Pais = reader["Pais"] as string,
                                    Telefono = reader["Telefono"] as string,
                                    Fax = reader["Fax"] as string
                                };
                            }
                        }
                    }
                }

                return null; // No encontrado
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cliente por Id", ex);
            }
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            try
            {
                using (var conn = DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_UpdateCliente", (SqlConnection)conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@NombreCompañia", cliente.NombreCompañia);
                        cmd.Parameters.AddWithValue("@NombreContacto", (object?)cliente.NombreContacto ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CargoContacto", (object?)cliente.CargoContacto ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Direccion", (object?)cliente.Direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ciudad", (object?)cliente.Ciudad ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Region", (object?)cliente.Region ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CodPostal", (object?)cliente.CodPostal ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Pais", (object?)cliente.Pais ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Telefono", (object?)cliente.Telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Fax", (object?)cliente.Fax ?? DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente", ex);
            }
        }
        public async Task<IEnumerable<Cliente>> SearchClientes(string palabra)
        {
            var clientes = new List<Cliente>();

            try
            {
                using (SqlConnection conn = (SqlConnection)DbConnectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_SearchClientes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Palabra", palabra ?? string.Empty);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var cliente = new Cliente
                                {
                                    IdCliente = reader["IdCliente"].ToString(),
                                    NombreCompañia = reader["NombreCompañia"].ToString(),
                                    NombreContacto = reader["NombreContacto"] as string,
                                    CargoContacto = reader["CargoContacto"] as string,
                                    Direccion = reader["Direccion"] as string,
                                    Ciudad = reader["Ciudad"] as string,
                                    Region = reader["Region"] as string,
                                    CodPostal = reader["CodPostal"] as string,
                                    Pais = reader["Pais"] as string,
                                    Telefono = reader["Telefono"] as string,
                                    Fax = reader["Fax"] as string
                                };

                                clientes.Add(cliente);
                            }
                        }
                    }
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes", ex);
            }
        }
    }
}
