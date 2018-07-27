using ONS.SDK.Worker;
using ONS.SDK.Context;
using ONS.SDK.Data.Persistence;
using Entities;
using System;

namespace Business
{
    public class CadastraCliente    {

        private const string _inserirCenario = "create.client.request";

        [SDKEvent(_inserirCenario)]
        public void InserirCenario(IDataSet<Conta> contas, Conta payload)
        {
            var conta = new Conta();
            conta.Name = payload.Name;
            conta.Balance = 0;

            contas.Insert(conta); 

        }

    }
}