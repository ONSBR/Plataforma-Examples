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
            System.Environment.SetEnvironmentVariable("INSTANCE_ID", "2a2b862a-0816-4d33-8f23-75f75d9fd601");
            System.Environment.SetEnvironmentVariable("PROCESS_ID", "f7fe8464-030f-4e85-9ab9-d91adb1018ff");
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

        // async private static void teste() 
        // {
        //     try
        //     {
        //         System.Console.WriteLine("teste");
        //         var client = new System.Net.Http.HttpClient();
        //         var content = new StringContent("{\"Name\":\"ec498841-59e5-47fd-8075-136d79155705.persist.request\",\"instanceId\":\"2a2b862a-0816-4d33-8f23-75f75d9fd601\",\"Payload\":{\"instanceId\":\"2a2b862a-0816-4d33-8f23-75f75d9fd601\"}}", Encoding.UTF8, "application/json");
        //         var response = await client.PutAsync("http://localhost:8081/sendevent", content);
        //         response.EnsureSuccessStatusCode();
        //         var status = await response.Content.ReadAsStringAsync();
        //         System.Console.WriteLine(status);
        //         System.Console.WriteLine("teste2");
        //     }
        //     catch (System.Exception e)
        //     {
        //         System.Console.WriteLine(e);
        //         throw e;
        //     } finally {
        //         System.Console.WriteLine("finally");
        //     }
        // }
    }
}
