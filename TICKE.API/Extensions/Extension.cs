using INFRASTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

namespace TICKE.API.Extensions
{
    public static class Extension
    {
        private static string DbContifico { set; get; } = "ConexionContificoPuertto";
        public static async Task InyectarContexto(this WebApplicationBuilder builder)
        {

            string contifico = builder.Configuration.GetConnectionString(DbContifico);
            builder.Services.AddDbContext<ApplicationDbContext>(async option =>
            {
                option.UseMySql(contifico, ServerVersion.AutoDetect(contifico),
                           mySqlOptionsAction: async sqlOptions =>
                           {
                               sqlOptions.EnableIndexOptimizedBooleanColumns(true);
                               sqlOptions.EnableRetryOnFailure(
                               maxRetryCount: 5,
                               maxRetryDelay: TimeSpan.FromSeconds(30),
                               errorNumbersToAdd: null);
                               sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                               sqlOptions.EnableIndexOptimizedBooleanColumns();
                               await Task.CompletedTask;
                           });
                option.EnableSensitiveDataLogging(true);
                option.EnableDetailedErrors(true);
                await Task.CompletedTask;
            }, ServiceLifetime.Transient);
            await Task.CompletedTask;
        }
        public static async Task InyectarFormatoJSon(this WebApplicationBuilder builder)
        {   builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            { options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            })
        .AddJsonOptions(options =>
        {   options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

            await Task.CompletedTask;
        }

    }
}