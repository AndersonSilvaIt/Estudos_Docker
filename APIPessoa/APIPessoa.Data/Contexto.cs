using APIPessoa.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPessoa.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {   
        }

        
    }
}