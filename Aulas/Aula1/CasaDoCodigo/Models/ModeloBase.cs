using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class ModeloBase
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
