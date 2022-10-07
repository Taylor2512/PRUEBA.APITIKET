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
    {
        private ITicketServices servicio;

        public TicketController(ITicketServices servicio)
        {
            this.servicio = servicio;
        }

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
        [HttpGet("{id}")]

        public async Task<IActionResult> GetForIdTicket(Guid id)
        {
            Tikect encontrado = await servicio.GetForIdTicket(id);
            return Ok(encontrado);
        }
        [HttpPost]
        public async Task<IActionResult> PostTikect(TikectPost entidad)
        {
            Tikect encontrado = await  servicio.PostTicket(entidad);
            return Ok(encontrado);
        }
        [HttpPut]
        public async Task<IActionResult> PutTicket(TikectPut entidad)
        {
           var encontrado= await  servicio.UpdateTicket(entidad);
            return Ok(encontrado);
        }

    }
}
