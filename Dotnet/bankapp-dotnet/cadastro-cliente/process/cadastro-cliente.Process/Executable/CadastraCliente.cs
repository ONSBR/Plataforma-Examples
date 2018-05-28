using ONS.PlataformaSDK.Domain;
using ONS.PlataformaSDK.ProcessApp;
using Entities;
using DomainContext;
using ONS.PlataformaSDK.Util;
using System;

namespace Executable
{
    public class CadastraCliente : IExecutable
    {
        public void Execute(IDomainContext domainContext, dynamic payload)
        {
            var Conta = new Conta();
            var DomainContextConta = (DomainContextConta) domainContext;
            Conta.Titular = payload.name;
            Conta.Saldo = 0;
            try {
                DomainContextConta.Conta.Insert(Conta);
            } catch (Exception e)
            {
                e.ToString();
                throw e;
            }
        }
    }
}