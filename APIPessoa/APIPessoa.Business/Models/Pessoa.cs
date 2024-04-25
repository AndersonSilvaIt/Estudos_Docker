using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPessoa.Business.Models
{
    [Table("Pessoa")]
    public class Pessoa : EntityBase
    {
        [MaxLength(100)]
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
