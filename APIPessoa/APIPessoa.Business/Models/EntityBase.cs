using System.ComponentModel.DataAnnotations;

namespace APIPessoa.Business.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}