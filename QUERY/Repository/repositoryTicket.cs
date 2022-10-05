using DOMAIN.Entities;
using DOMAIN.Helper.Tools;
using DOMAIN.Interfaces.Repository;
using INFRASTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Repository
{
    internal class repositoryTicket: IrepositoryTicket
    {
        private  ApplicationDbContext _LContext;
        private ApplicationDbContext _context;

        public repositoryTicket(ApplicationDbContext lContext, ApplicationDbContext context)
        {
            _LContext = lContext;
            _context = context;
        }

        public async Task<List<Tikect>> GetAllTicket()
        {
            var encontrado = await _LContext.tbl_ticket
                .Include(e=>e.historial)
                .ToListAsync();
            _LContext.ChangeTracker.Clear();
            return encontrado;
        }

        public async Task<List<Tikect>> GetAllTicket(DateTime? fechaini, DateTime? fechaFinal)
        {
            var encontrado = await _LContext.tbl_ticket
                            .Include(e => e.historial)
                            .Where(e => e.feca_de_ingreso>=fechaini&& e.feca_de_ingreso<= fechaFinal)

                            .ToListAsync();
            _LContext.ChangeTracker.Clear();
            return encontrado;
        }

        public async Task<List<Tikect>> GetAllTicket(string usuario)
        {
            var encontrado = await _LContext.tbl_ticket
                            .Include(e => e.historial)
                            .Where(e=>e.persona_solicitante.Contains(usuario))
                            .ToListAsync();
            _LContext.ChangeTracker.Clear();
            return encontrado;
        }

        public async Task<Tikect>GetForIdTicket(Guid id)
        {
            var encontrado = await _LContext.tbl_ticket
                .Include(e=>e.historial)
                .Where(e=>e.Id== id)
                .FirstOrDefaultAsync();
            _LContext.ChangeTracker.Clear();
            return encontrado;
        }
        public async Task<bool> ifExist(Guid id)
        {
            bool encontrado = false;

            encontrado = await _LContext.tbl_ticket.AnyAsync(e=>e.Id==id);
            return encontrado;

        }
        public async Task<Tikect> PostTicket(Tikect entidad)
        {
            if (!await ifExist(entidad.Id))
            {
             entidad=    await _context.InsertartDb(entidad);
                return entidad;

            }
            else
            {
                entidad.Id = new Guid();
                entidad = await _context.InsertartDb(entidad);
                return entidad;

            }
             
        }
         public async Task<Tikect> UpdateTicket(Tikect entidad)
        {
            if (!await ifExist(entidad.Id))
            {
            
                if(entidad.historial!=null&& entidad.historial.Count() > 0)
                {
                    await entidad.historial.ForEachAsync(async e =>
                    {
                        e.id_Ticket= entidad.Id;
                     _context.Add(e);

                    });
                    await _context.SaveChangesAsync();
                }
                entidad = await _context.UdateDB(entidad);
                return entidad;

            }

            return null;
        }

    }
}
