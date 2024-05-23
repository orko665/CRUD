using CRUD.Conexion;
using CRUD.Model.Dto;
using Npgsql;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD.Model.Dao
{
    public class ClientesDao : ICliente
    {
        public async Task<bool> CreateCliente(ClienteDto cliente)
        {
            ConexionDB cadena = new ConexionDB();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "CALL insertarcliente(@id_banco, @nombre, @apellido, @documento, @direccion, @mail, @celular, @estado)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id_banco", cliente.id_banco);
                    cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.apellido);
                    cmd.Parameters.AddWithValue("documento", cliente.documento);
                    cmd.Parameters.AddWithValue("direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("mail", cliente.mail);
                    cmd.Parameters.AddWithValue("celular", cliente.celular);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result >= 0;
                }
            }
        }

        public async Task<bool> DeleteCliente(int id)
        {
            ConexionDB cadena = new ConexionDB();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "CALL borrarcliente(@idIN)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idIN", id);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result >= 0;
                }
            }
        }

        //Se obtiene todos los clientes
        public async Task<List<ClienteDto>> GetAllClientes()
        {
            ConexionDB cadena = new ConexionDB();

            List<ClienteDto> clienteDtos = new List<ClienteDto>();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "Select * from cliente;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    await conn.OpenAsync();

                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ClienteDto obj = new ClienteDto()
                            {
                                id = reader.GetInt32("id"),
                                id_banco = reader.GetInt32("id_banco"),
                                nombre = reader.GetString("nombre"),
                                apellido = reader.GetString("apellido"),
                                documento = reader.GetString("documento"),
                                direccion = reader.GetString("direccion"),
                                mail = reader.GetString("mail"),
                                celular = reader.GetString("celular"),
                                estado = reader.GetString("estado"),
                            };
                            clienteDtos.Add(obj);
                        }
                    }

                    return clienteDtos;
                }
            }

        }

        public async Task<List<ClienteDto>> GetCliente(int id)
        {
            ConexionDB cadena = new ConexionDB();

            List<ClienteDto> clienteDtos = new List<ClienteDto>();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "Select * from cliente where id=@idIn;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idIn", id);
                    await conn.OpenAsync();

                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ClienteDto obj = new ClienteDto()
                            {
                                id = reader.GetInt32("id"),
                                id_banco = reader.GetInt32("id_banco"),
                                nombre = reader.GetString("nombre"),
                                apellido = reader.GetString("apellido"),
                                documento = reader.GetString("documento"),
                                direccion = reader.GetString("direccion"),
                                mail = reader.GetString("mail"),
                                celular = reader.GetString("celular"),
                                estado = reader.GetString("estado"),
                            };
                            clienteDtos.Add(obj);
                        }
                    }

                    return clienteDtos;
                }
            }
        }

        public async Task<bool> UpdateCliente(ClienteDto cliente)
        {
            ConexionDB cadena = new ConexionDB();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "CALL actualizarcliente(@id, @id_banco, @nombre, @apellido, @documento, @direccion, @mail, @celular, @estado)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", cliente.id);
                    cmd.Parameters.AddWithValue("id_banco", cliente.id_banco);
                    cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.apellido);
                    cmd.Parameters.AddWithValue("documento", cliente.documento);
                    cmd.Parameters.AddWithValue("direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("mail", cliente.mail);
                    cmd.Parameters.AddWithValue("celular", cliente.celular);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result >= 0;
                }
            }
        }
    }
}
