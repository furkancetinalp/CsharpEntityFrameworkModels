using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new bookyedekDbContext(serviceProvider.GetRequiredService<DbContextOptions<bookyedekDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book{

                        Title="Lean Startup",
                        GenreId = 1, //personal growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001,04,03)
                    },
                    new Book
                    {
                        //Id=2,
                        Title= "Herland",
                        GenreId = 2, //science fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,13)
                    },
                    new Book
                    {
                        //Id=3,
                        Title= "Dune",
                        GenreId = 2,
                        PageCount = 500,
                        PublishDate = new DateTime(2009,02,04)
                    
                });

                context.SaveChanges();


            }

        }
    }
}