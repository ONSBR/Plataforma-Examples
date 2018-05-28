using ONS.PlataformaSDK.Domain;

namespace Entities
{
    public class Conta : BaseEntity
    {
        public string Titular{get;set;}
        public string RG{get;set;}
        public int Saldo{get;set;}
    }
}