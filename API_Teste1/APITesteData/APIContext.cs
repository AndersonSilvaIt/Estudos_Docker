using Microsoft.EntityFrameworkCore;

namespace APITesteData
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
            
        }
    }
}
