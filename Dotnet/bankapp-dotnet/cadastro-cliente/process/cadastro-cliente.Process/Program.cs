using System;
using ONS.PlataformaSDK.ProcessApp;
using ONS.PlataformaSDK.Main;
using Executable;
using DomainContext;

namespace cadastro_cliente.Process
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Environment.SetEnvironmentVariable("SYSTEM_ID", "ec498841-59e5-47fd-8075-136d79155705");
            var MainApp = new MainApp();
            MainApp.ExecuteAsync(new CadastraCliente(), new DomainContextConta());
            
        }
    }
}
