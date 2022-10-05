using DOMAIN.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using QUERY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Config
{
    public static class RepositoryConfig
    {
        public static async Task InyectarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IrepositoryTicket, repositoryTicket> ();

        }
    }
}
