using System;
using Business;
using ONS.SDK.Builder;
using ONS.SDK.Impl.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ONS.SDK.Extensions.Builder;
using ONS.SDK.Extensions.DependencyInjection;

using Entities;

namespace cadastro_cliente.Process
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBuilder.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .RunSDK();
        }
    }

    class Startup : IStartup
    {
        public Startup(IConfiguration conf){}

        public void Configure(IAppBuilder appBuilder){
        }

        public void ConfigureServices(IServiceCollection services) {
            services.BindEvents<CadastraCliente>();
            services.UseDataMap<EntitiesMap>();
            services.AddSingleton<CadastraCliente>();
        }
    }
}
