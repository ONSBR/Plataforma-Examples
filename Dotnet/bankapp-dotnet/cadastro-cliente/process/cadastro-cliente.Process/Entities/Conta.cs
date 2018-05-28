using ONS.PlataformaSDK.Domain;

namespace Entities
{
    public class Conta : BaseEntity
    {
        public string titular{get;set;}
        public string RG{get;set;}
        public string Saldo{get;set;}
    }
}