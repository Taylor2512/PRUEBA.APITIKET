using Microsoft.OpenApi.Models;
using PRUEBA.APITIKET.Extensions;
using System.Reflection;

namespace PRUEBA.APITIKET.Config
{
    public static class Startup
    {
        public static async Task<WebApplication> Inizializar(this string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            await builder.ConfigureServices();
            var app = builder.Build();
            app = await app.MillwareServices();
            await Task.CompletedTask;
            return app;
        }
        public static async Task ConfigureServices(this WebApplicationBuilder builder)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            await builder.InyectarDependencies();
            await builder.InyectarFormatoJSon();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Alltodo",
                                  builder =>
                                  {
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyOrigin();


                                  });
            });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "Api de Integracion de Contifico",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // using System.Reflection;
              /*  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                var XMLAPPLICATION = Path.Combine(AppContext.BaseDirectory, "APLICATION.xml");
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, XMLAPPLICATION));

                var xmldomain = Path.Combine(AppContext.BaseDirectory, "DOMAIN.xml");
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmldomain));

                var xmlinfrastructure = Path.Combine(AppContext.BaseDirectory, " INFRASTRUCTURE.xml");
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlinfrastructure));
                var xmlquery = Path.Combine(AppContext.BaseDirectory, "QUERY.xml");
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlquery));*/
            });

            await Task.CompletedTask;
        }
        public static async Task<WebApplication> MillwareServices(this WebApplication app)
        {
        

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("Alltodo");
            app.UseAuthorization();

            app.MapControllers();
            await app.RunAsync();
            await Task.CompletedTask;
            return app;

        }

    }
}
