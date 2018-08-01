using System;
using Business;
using ONS.SDK.Builder;
using ONS.SDK.Impl.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ONS.SDK.Extensions.Builder;
using ONS.SDK.Extensions.DependencyInjection;

using Entities;

namespace cadastro_conta
{
    class Program
    {
        static void Main(string[] args)
        {
            var instanceId = System.Environment.GetEnvironmentVariable("INSTANCE_ID");
            var processId = System.Environment.GetEnvironmentVariable("PROCESS_ID");
            var systemId = System.Environment.GetEnvironmentVariable("SYSTEM_ID");
            Console.WriteLine("################# INSTANCE_ID: " + instanceId + ", PROCESS_ID: " + processId + ", SYSTEM_ID: " + systemId);

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
