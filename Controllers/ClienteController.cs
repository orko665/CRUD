using CRUD.Model.Dao;
using CRUD.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController : Controller
    {

        [HttpGet("list")]
        public async Task<ActionResult<List<ClienteDto>>> get()
        {
            ClientesDao dao = new ClientesDao();

            return Ok(await dao.GetAllClientes());
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<ClienteDto>>> Get([FromBody] JsonElement parametros)
        {
            try
            {
                int idIN = parametros.GetProperty("id").GetInt32();
                ClientesDao dao = new ClientesDao();
                var result = await dao.GetCliente(idIN);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }


        //Crear CLiente
        [HttpPost("Add")]
        public async Task<ActionResult> post([FromBody] JsonElement parametros)
        {
            try
            {

                int id_bancoIN = parametros.GetProperty("id_banco").GetInt32();
                string nombreIN = parametros.GetProperty("nombre").GetString();
                string apellidoIN = parametros.GetProperty("apellido").GetString();
                string documentoIN = parametros.GetProperty("documento").GetString();
                string direccionIN = parametros.GetProperty("direccion").GetString();
                string mailIN = parametros.GetProperty("mail").GetString();
                string celularIN = parametros.GetProperty("celular").GetString();
                string estadoIN = parametros.GetProperty("estado").GetString();

                ClientesDao dao = new ClientesDao();

                ClienteDto newCliente = new ClienteDto()
                {
                    id_banco = id_bancoIN,
                    nombre = nombreIN,
                    apellido = apellidoIN,
                    documento = documentoIN,
                    direccion = direccionIN,
                    mail = mailIN, 
                    celular = celularIN,
                    estado = estadoIN,
                };

                await dao.CreateCliente(newCliente);

                return Ok(new { message = "Cliente Creado" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }

        }

        //Update Cliente
        [HttpPut("Update")]
        public async Task<ActionResult> put([FromBody] JsonElement parametros)
        {
            try
            {
                int idIN = parametros.GetProperty("id").GetInt32();
                int id_bancoIN = parametros.GetProperty("id_banco").GetInt32();
                string nombreIN = parametros.GetProperty("nombre").GetString();
                string apellidoIN = parametros.GetProperty("apellido").GetString();
                string documentoIN = parametros.GetProperty("documento").GetString();
                string direccionIN = parametros.GetProperty("direccion").GetString();
                string mailIN = parametros.GetProperty("mail").GetString();
                string celularIN = parametros.GetProperty("celular").GetString();
                string estadoIN = parametros.GetProperty("estado").GetString();

                ClientesDao dao = new ClientesDao();

                ClienteDto updateCliente = new ClienteDto()
                {
                    id = idIN,
                    id_banco = id_bancoIN,
                    nombre = nombreIN,
                    apellido = apellidoIN,
                    documento = documentoIN,
                    direccion = direccionIN,
                    mail = mailIN,
                    celular = celularIN,
                    estado = estadoIN,
                };

                await dao.UpdateCliente(updateCliente);

                return Ok(new { message = "Cliente Actualizado" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }
        // Eliminar Cliente
        [HttpDelete("Delete")]
        public async Task<ActionResult> delete([FromBody] JsonElement parametros)
        {
            try
            {
                int id = parametros.GetProperty("id").GetInt32();


                ClientesDao dao = new ClientesDao();

                await dao.DeleteCliente(id);

                return Ok(new { message = "Cliente Eliminado" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }

    }
}
