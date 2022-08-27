using System.Runtime.Serialization;

namespace BlogSemEntity.Models
{
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}