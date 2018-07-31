using System.Collections.Generic;
using Entities;
using ONS.PlataformaSDK.Domain;

namespace DomainContext 
{
    public class DomainContextConta : IDomainContext
    {
        public List<Conta> Conta{get;set;}

        public DomainContextConta()
        {
            Conta = new List<Conta>();
        }
        
        public List<BaseEntity> GetPersistList()
        {
            var Entities = new List<BaseEntity>();
            Entities.AddRange(Conta);
            return Entities;
        }
    }
}