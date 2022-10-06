using DOMAIN.Entities;
using DOMAIN.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IrepositoryTicket servicio;

        public TicketController(IrepositoryTicket servicio)
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
            var encontrado = await servicio.GetForIdTicket(id);
            return Ok(encontrado);
        }
        [HttpPost]
        public async Task<IActionResult> PostTikect(Tikect entidad)
        {
           var encontrado= await  servicio.PostTicket(entidad);
            return Ok(encontrado);
        }
        [HttpPut]
        public async Task<IActionResult> GetAllTicket(Tikect entidad)
        {
           var encontrado= await  servicio.UpdateTicket(entidad);
            return Ok(encontrado);
        }

    }
}
