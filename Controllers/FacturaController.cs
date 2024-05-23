using CRUD.Model.Dao;
using CRUD.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("Facturas")]
    public class FacturaController : Controller
    {
        FacturaDao dao;
        public FacturaController()
        {
            dao = new FacturaDao();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ClienteDto>>> get()
        {
            return Ok(await dao.GetAllFacturas());
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<ClienteDto>>> Get([FromBody] JsonElement parametros)
        {
            try
            {
                int idIN = parametros.GetProperty("id").GetInt32();
                
                var result = await dao.GetFactura(idIN);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }


        //Crear Factura
        [HttpPost("Add")]
        public async Task<ActionResult> post([FromBody] JsonElement parametros)
        {
            try
            {

                int id_clienteIN = parametros.GetProperty("id_cliente").GetInt32();
                string nro_facturaIN = parametros.GetProperty("nro_factura").GetString();
                DateTime fecha_horaIN = parametros.GetProperty("fecha_hora").GetDateTime();
                double totalIN = parametros.GetProperty("total").GetDouble();
                double total_iva5IN = parametros.GetProperty("total_iva5").GetDouble();
                double total_iva10IN = parametros.GetProperty("total_iva10").GetDouble();
                double total_ivaIN = parametros.GetProperty("total_iva").GetDouble();
                int total_letrasIN = parametros.GetProperty("total_letras").GetInt32();
                string sucursalIN = parametros.GetProperty("sucursal").GetString();



                FacturaDto newFactura = new FacturaDto()
                {
                    id_cliente = id_clienteIN,
                    nro_factura = nro_facturaIN,
                    fecha_hora = fecha_horaIN,
                    total = totalIN,
                    total_iva5 = total_iva5IN,
                    total_iva10 = total_iva10IN,
                    total_iva = total_ivaIN,
                    total_letras = total_letrasIN,
                    sucursal = sucursalIN
                };

                await dao.CreateFactura(newFactura);

                return Ok(new { message = "Factura Creada" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }

        }

        //Update Factura
        [HttpPut("Update")]
        public async Task<ActionResult> put([FromBody] JsonElement parametros)
        {
            try
            {
                int idIN = parametros.GetProperty("id").GetInt32();
                int id_clienteIN = parametros.GetProperty("id_cliente").GetInt32();
                string nro_facturaIN = parametros.GetProperty("nro_factura").GetString();
                DateTime fecha_horaIN = parametros.GetProperty("fecha_hora").GetDateTime();
                double totalIN = parametros.GetProperty("total").GetDouble();
                double total_iva5IN = parametros.GetProperty("total_iva5").GetDouble();
                double total_iva10IN = parametros.GetProperty("total_iva10").GetDouble();
                double total_ivaIN = parametros.GetProperty("total_iva").GetDouble();
                int total_letrasIN = parametros.GetProperty("total_letras").GetInt32();
                string sucursalIN = parametros.GetProperty("sucursal").GetString();


                FacturaDto updatefactura = new FacturaDto()
                {
                    id_cliente = id_clienteIN,
                    nro_factura = nro_facturaIN,
                    fecha_hora = fecha_horaIN,
                    total = totalIN,
                    total_iva5 = total_iva5IN,
                    total_iva10 = total_iva10IN,
                    total_iva = total_ivaIN,
                    total_letras = total_letrasIN,
                    sucursal = sucursalIN
                };

                await dao.UpdateFactura(updatefactura);

                return Ok(new { message = "Factura Actualizada" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }

        // Eliminar Factura
        [HttpDelete("Delete")]
        public async Task<ActionResult> delete([FromBody] JsonElement parametros)
        {
            try
            {
                int id = parametros.GetProperty("id").GetInt32();

                await dao.DeleteFactura(id);

                return Ok(new { message = "Factura Eliminada" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }
    }
}
