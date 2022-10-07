using AutoMapper;
using DOMAIN.Dtos;
using DOMAIN.Entities;
using DOMAIN.Interfaces.Repository;
using DOMAIN.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.Servicios
{
    internal class TicketServices: ITicketServices
    {
        private IrepositoryTicket repository;
        private IMapper mapper;
        /// <summary>
        /// en los constructores se inician las instancias correspondientes 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TicketServices(IrepositoryTicket repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<Tikect>> GetAllTicket(DateTime? fechaini, DateTime? fechaFinal)=>await repository.GetAllTicket(fechaini, fechaFinal);
        

        public async Task<List<Tikect>> GetAllTicket(string usuario)=> await repository.GetAllTicket(usuario);
        

        public async Task<List<Tikect>> GetAllTicket()=> await repository.GetAllTicket();
        

        public async Task<Tikect> GetForIdTicket(Guid id)=> await repository.GetForIdTicket(id);

        public async Task<Tikect> PostTicket(TikectPost entidad)
        {
            var mapeo= mapper.Map<Tikect>(entidad);
            mapeo= await repository.PostTicket(mapeo);
            return mapeo;
        }

        public async Task<Tikect> UpdateTicket(TikectPut entidad)
        {
            var mapeo=mapper.Map<Tikect>(entidad);
            return await repository.UpdateTicket(mapeo);
        }
    }
}
