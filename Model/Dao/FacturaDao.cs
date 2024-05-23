using CRUD.Conexion;
using CRUD.Model.Dto;
using Npgsql;
using System.Data;

namespace CRUD.Model.Dao
{
    public class FacturaDao : IFactura
    {
        ConexionDB cadena;
        List<FacturaDto> facturaDtos;
        public FacturaDao() { 
            cadena = new ConexionDB();  
        }

        public async Task<bool> CreateFactura(FacturaDto factura)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "CALL insertarfactura(@id_cliente,@nro_factura,@fecha_hora,@total,@total_iva5,@total_iva10,@total_iva,@total_letras,@sucursal);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id_cliente", factura.id_cliente);
                    cmd.Parameters.AddWithValue("nro_factura", factura.nro_factura);
                    cmd.Parameters.AddWithValue("fecha_hora", NpgsqlTypes.NpgsqlDbType.Timestamp, factura.fecha_hora);
                    cmd.Parameters.AddWithValue("total", NpgsqlTypes.NpgsqlDbType.Numeric,factura.total);
                    cmd.Parameters.AddWithValue("total_iva5", NpgsqlTypes.NpgsqlDbType.Numeric,factura.total_iva5);
                    cmd.Parameters.AddWithValue("total_iva10", NpgsqlTypes.NpgsqlDbType.Numeric, factura.total_iva10);
                    cmd.Parameters.AddWithValue("total_iva", NpgsqlTypes.NpgsqlDbType.Numeric, factura.total_iva);
                    cmd.Parameters.AddWithValue("total_letras", factura.total_letras);
                    cmd.Parameters.AddWithValue("sucursal", factura.sucursal);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result >= 0;
                }
            }
        }

        public async Task<bool> DeleteFactura(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "CALL borrarFactura(@idIN)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idIN", id);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result >= 0;
                }
            }
        }

        public async Task<List<FacturaDto>> GetAllFacturas()
        {
            facturaDtos = new List<FacturaDto>();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "Select * from factura;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    await conn.OpenAsync();

                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            FacturaDto obj = new FacturaDto()
                            {
                                id = reader.GetInt32("id"),
                                id_cliente = reader.GetInt32("id_cliente"),
                                nro_factura = reader.GetString("nro_factura"),
                                fecha_hora = reader.GetDateTime("fecha_hora"),
                                total = reader.GetDouble("total"),
                                total_iva5 = reader.GetDouble("total_iva5"),
                                total_iva10 = reader.GetDouble("total_iva10"),
                                total_iva = reader.GetDouble("total_iva"),
                                total_letras = reader.GetInt32("total_letras"),
                                sucursal = reader.GetString("sucursal")
                            };
                            facturaDtos.Add(obj);
                        }
                    }

                    return facturaDtos;
                }
            }
        }

        public async Task<List<FacturaDto>> GetFactura(int id)
        {
            facturaDtos = new List<FacturaDto>();

            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "Select * from factura where id=@idIn;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idIn", id);
                    await conn.OpenAsync();

                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            FacturaDto obj = new FacturaDto()
                            {
                                id = reader.GetInt32("id"),
                                id_cliente = reader.GetInt32("id_cliente"),
                                nro_factura = reader.GetString("nro_factura"),
                                fecha_hora = reader.GetDateTime("fecha_hora"),
                                total = reader.GetDouble("total"),
                                total_iva5 = reader.GetDouble("total_iva5"),
                                total_iva10 = reader.GetDouble("total_iva10"),
                                total_iva = reader.GetDouble("total_iva"),
                                total_letras = reader.GetInt32("total_letras"),
                                sucursal = reader.GetString("sucursal")
                            };
                            facturaDtos.Add(obj);
                        }
                    }

                    return facturaDtos;
                }
            }
        }

        public async Task<bool> UpdateFactura(FacturaDto factura)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(cadena.getCadena()))
            {

                string sql = "CALL actualizarFactura(@id, @id_cliente,@nro_factura,@fecha_hora,@total,@total_iva5,@total_iva10,@total_iva,@total_letras,@sucursal)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", factura.id);
                    cmd.Parameters.AddWithValue("id_cliente", factura.id_cliente);
                    cmd.Parameters.AddWithValue("nro_factura", factura.nro_factura);
                    cmd.Parameters.AddWithValue("fecha_hora", NpgsqlTypes.NpgsqlDbType.Timestamp, factura.fecha_hora);
                    cmd.Parameters.AddWithValue("total", NpgsqlTypes.NpgsqlDbType.Numeric, factura.total);
                    cmd.Parameters.AddWithValue("total_iva5", NpgsqlTypes.NpgsqlDbType.Numeric, factura.total_iva5);
                    cmd.Parameters.AddWithValue("total_iva10", NpgsqlTypes.NpgsqlDbType.Numeric, factura.total_iva10);
                    cmd.Parameters.AddWithValue("total_iva", NpgsqlTypes.NpgsqlDbType.Numeric, factura.total_iva);
                    cmd.Parameters.AddWithValue("total_letras", factura.total_letras);
                    cmd.Parameters.AddWithValue("sucursal", factura.sucursal);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result >= 0;
                }
            }
        }
    }
}
