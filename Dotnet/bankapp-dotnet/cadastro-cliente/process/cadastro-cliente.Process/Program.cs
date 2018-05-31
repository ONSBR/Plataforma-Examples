using System;
using ONS.PlataformaSDK.ProcessApp;
using ONS.PlataformaSDK.Main;
using Executable;
using DomainContext;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace cadastro_cliente.Process
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastro de conta");
            System.Environment.SetEnvironmentVariable("SYSTEM_ID", "ec498841-59e5-47fd-8075-136d79155705");
            System.Environment.SetEnvironmentVariable("PROCESS_ID", "f7fe8464-030f-4e85-9ab9-d91adb1018ff");
            System.Environment.SetEnvironmentVariable("INSTANCE_ID", "1159fca6-1236-4960-883c-13a510868dd0");
            System.Environment.SetEnvironmentVariable("EVENT", "create.client.request");
            try {
                var MainApp = new MainApp();
                MainApp.Execute(new CadastraCliente(), new DomainContextConta());
            } catch(Exception e) {
                e.ToString();
                throw e;
            }
            Console.WriteLine("Fim Cadastro de conta");
        }

    }
}
