using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class bookyedekDbContext : DbContext
    {
        public bookyedekDbContext(DbContextOptions<bookyedekDbContext> options): base(options)
        {

        }
        public DbSet<Book> Books {get;set;}

    }

}