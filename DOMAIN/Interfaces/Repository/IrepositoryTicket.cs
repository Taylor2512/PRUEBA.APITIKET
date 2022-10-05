using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.Repository
{
    public interface IrepositoryTicket
    {
        Task<List<Tikect>> GetAllTicket();
        Task<bool> ifExist(Guid id);
        Task<Tikect> GetForIdTicket(Guid id);
        Task<Tikect> PostTicket(Tikect entidad);
        Task<Tikect> UpdateTicket(Tikect entidad);
        Task<List<Tikect>> GetAllTicket(DateTime? fechaini, DateTime? fechaFinal);
        Task<List<Tikect>> GetAllTicket(string usuario);
    }
}
