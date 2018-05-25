using System.Collections.Generic;
using Entities;
using ONS.PlataformaSDK.Domain;

namespace DomainContext 
{
    public class DomainContextConta : IDomainContext
    {
        private List<Conta> Conta;
        public List<BaseEntity> GetPersistList()
        {
            var Entities = new List<BaseEntity>();
            Entities.AddRange(Conta);
            return Entities;
        }
    }
}