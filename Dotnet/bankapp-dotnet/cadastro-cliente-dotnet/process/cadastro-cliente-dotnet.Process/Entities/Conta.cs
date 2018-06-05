using ONS.PlataformaSDK.Domain;
using Newtonsoft.Json;

namespace Entities
{
    public class Conta : BaseEntity
    {
        [JsonProperty("name")]
        public string Name{get;set;}
        public string RG{get;set;}
        [JsonProperty("balance")]
        public int Balance{get;set;}
    }
}