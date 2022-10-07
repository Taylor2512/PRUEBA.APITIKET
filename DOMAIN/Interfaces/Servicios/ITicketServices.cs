using DOMAIN.Dtos;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.Servicios
{
    public interface ITicketServices
    {
        Task<List<Tikect>> GetAllTicket(DateTime? fechaini, DateTime? fechaFinal);
        Task<List<Tikect>> GetAllTicket(string usuario);
        Task<List<Tikect>> GetAllTicket();
        Task<Tikect> GetForIdTicket(Guid id);
        Task<Tikect> PostTicket(TikectPost entidad);
        Task<Tikect> UpdateTicket(TikectPut entidad);
    }
}
