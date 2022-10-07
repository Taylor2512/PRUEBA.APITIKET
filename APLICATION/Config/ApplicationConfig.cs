using APLICATION.Servicios;
using DOMAIN.Interfaces.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.Config
{
    public static class ApplicationConfig
    {
        public static async Task InyectarServicios(this IServiceCollection services)
        {
            services.AddScoped<ITicketServices, TicketServices>();
            // se inyecta a nivel general de los proyectos los mapeos de cada uno de los perfiles
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
