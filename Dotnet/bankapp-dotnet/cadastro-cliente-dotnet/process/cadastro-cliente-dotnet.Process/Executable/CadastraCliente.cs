using ONS.PlataformaSDK.Domain;
using ONS.PlataformaSDK.ProcessApp;
using Entities;
using DomainContext;
using ONS.PlataformaSDK.Util;
using System;
using ONS.PlataformaSDK.Entities;

namespace Executable
{
    public class CadastraCliente : IExecutable
    {
        public void Execute(IDomainContext domainContext, Context context)
        {
            var DomainContextConta = (DomainContextConta)domainContext;
            foreach (var conta in DomainContextConta.Conta)
            {
                System.Console.WriteLine("----------");
                System.Console.WriteLine(conta.Id);
                System.Console.WriteLine("----------");
            }
            var Conta = new Conta();
            Conta.Name = context.Event.Payload.Value<string>("name");
            Conta.Balance = 0;
            try
            {
                DomainContextConta.Conta.Insert(Conta);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                throw e;
            }
        }
    }
}