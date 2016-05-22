using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using TheWorld.Models;
using TheWorld.Models.Contexto;
using TheWorld.Models.Repositorio;
using TheWorld.Models.Repositorio.Interfaces;
using TheWorld.Services;
using TheWorld.Services.Interfaces;

namespace TheWorld
{
    public class Startup
    {
        public static IConfigurationRoot Configuracao;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuracao = builder.Build();

        }
        //Este método é chamado pelo tempo de execução.Utilize este método para adicionar serviços para o recipiente .
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer() 
                .AddDbContext<MundoContext>();

            //uma vez que passado por ele, poderá ser destruido
            services.AddTransient<MundoContextSeedData>();

            services.AddScoped<IViagemRepositorio, ViagemRepositorio>();

            services.AddScoped<IParadaRepositorio, ParadaRepositorio>();

#if DEBUG
            services.AddScoped<IEmailService, DebugEmailService>();
#else
            services.AddScoped<IEmailService, EmailService>();
#endif

        }

        //Este método é chamado pelo tempo de execução.Utilize este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, MundoContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            seeder.EnsureSeedData();
        }

        //Ponto de entrada para a aplicação.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
