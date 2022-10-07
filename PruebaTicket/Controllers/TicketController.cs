using DOMAIN.Dtos;
using DOMAIN.Entities;
using DOMAIN.Interfaces.Repository;
using DOMAIN.Interfaces.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {/// <summary>
    /// interfaz de inyeccion con dependencias scope
    /// </summary>
        private ITicketServices servicio;

        public TicketController(ITicketServices servicio)
        {
            this.servicio = servicio;
        }
        /// <summary>
        /// Metodo generico para realizar gets
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTicket(DateTime? fechaini,DateTime? fechaFinal, string? usuario)
        {
            List<Tikect> encontrado = new List<Tikect>();

            if(fechaini!=null&& fechaFinal != null)
            {
                 encontrado = await servicio.GetAllTicket(fechaini, fechaFinal);
                return Ok(encontrado);

            }
            if (!string.IsNullOrEmpty(usuario))
            {
                encontrado = await servicio.GetAllTicket(usuario);
                return Ok(encontrado);
            }
            encontrado = await servicio.GetAllTicket();

            return Ok(encontrado);
          
        }
        /// <summary>
        /// Metodo para obtener el ticket por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public async Task<IActionResult> GetForIdTicket(Guid id)
        {
            Tikect encontrado = await servicio.GetForIdTicket(id);
            return Ok(encontrado);
        }
        /// <summary>
        /// metodo para insertar el ticket
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostTikect(TikectPost entidad)
        {
            Tikect encontrado = await  servicio.PostTicket(entidad);
            return Ok(encontrado);
        }
        /// <summary>
        /// metodo para actualizar el ticket y sus incidencias en el detalle
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutTicket(TikectPut entidad)
        {
           var encontrado= await  servicio.UpdateTicket(entidad);
            return Ok(encontrado);
        }

    }
}
