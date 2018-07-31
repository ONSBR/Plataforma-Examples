using System;
using ONS.PlataformaSDK.ProcessApp;
using ONS.PlataformaSDK.Main;
using Executable;
using DomainContext;

namespace cadastro_cliente_dotnet.Process
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastro de conta");
            try {
                var MainApp = new MainApp();
                MainApp.Execute(new CadastraCliente(), new DomainContextConta());
            } catch(System.Exception e) {
                System.Console.WriteLine(e.StackTrace); 
                throw e;
            }
            Console.WriteLine("Fim Cadastro de conta");
        }
    }
}
