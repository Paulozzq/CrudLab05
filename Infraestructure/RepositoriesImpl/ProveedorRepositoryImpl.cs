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
    public class ProveedorRepositoryImpl : IProveedorRepository
    {
        public IEnumerable<Proveedor> GetProveedoresByNombreContactoAndCiudad(string nombreContacto, string ciudad)
        {
            var proveedores = new List<Proveedor>();

            using (var connection = DbConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_GetProveedorByNombreContactoAndCiudad";
                    command.CommandType = CommandType.StoredProcedure;

                    var pNombre = new SqlParameter("@NombreContacto", SqlDbType.NVarChar, 50)
                    {
                        Value = string.IsNullOrWhiteSpace(nombreContacto) ? DBNull.Value : nombreContacto
                    };
                    command.Parameters.Add(pNombre);

                    var pCiudad = new SqlParameter("@Ciudad", SqlDbType.NVarChar, 50)
                    {
                        Value = string.IsNullOrWhiteSpace(ciudad) ? DBNull.Value : ciudad
                    };
                    command.Parameters.Add(pCiudad);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proveedor = new Proveedor
                            {
                                IdProveedor = reader.GetInt32(reader.GetOrdinal("IdProveedor")),
                                NombreCompañia = reader.GetString(reader.GetOrdinal("NombreCompañia")),
                                NombreContacto = reader.IsDBNull(reader.GetOrdinal("NombreContacto")) ? null : reader.GetString(reader.GetOrdinal("NombreContacto")),
                                CargoContacto = reader.IsDBNull(reader.GetOrdinal("CargoContacto")) ? null : reader.GetString(reader.GetOrdinal("CargoContacto")),
                                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                                Ciudad = reader.IsDBNull(reader.GetOrdinal("Ciudad")) ? null : reader.GetString(reader.GetOrdinal("Ciudad")),
                                Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader.GetString(reader.GetOrdinal("Region")),
                                CodPostal = reader.IsDBNull(reader.GetOrdinal("CodPostal")) ? null : reader.GetString(reader.GetOrdinal("CodPostal")),
                                Pais = reader.IsDBNull(reader.GetOrdinal("Pais")) ? null : reader.GetString(reader.GetOrdinal("Pais")),
                                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                                Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : reader.GetString(reader.GetOrdinal("Fax")),
                                PaginaPrincipal = reader.IsDBNull(reader.GetOrdinal("PaginaPrincipal")) ? null : reader.GetString(reader.GetOrdinal("PaginaPrincipal"))
                            };

                            proveedores.Add(proveedor);
                        }
                    }
                }
            }

            return proveedores;
        }

    }
}
