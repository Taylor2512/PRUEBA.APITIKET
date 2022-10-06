using APLICATION.Config;
using QUERY.Config;

namespace TICKE.API.Extensions
{
    public static class Dependencies
    {
        public static async Task InyectarDependencies(this WebApplicationBuilder builder)
        {
            await builder.InyectarContexto();
            await builder.Services.InyectarServicios();


            await builder.Services.InyectarRepositorios();


            await Task.CompletedTask;
        }
    }
}
