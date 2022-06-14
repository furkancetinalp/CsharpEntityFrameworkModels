using System;
using WebApi.DBOperations;
using System.Linq;

namespace WebApi.BookOperations.DeleteBook
{
    public class GetBookDeleted
    {
        public int ID;

        private readonly bookyedekDbContext _dbContext;

        public GetBookDeleted(bookyedekDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==ID);
            if(book is null)
            {
                throw new InvalidOperationException("ID could not be found in the library.");         
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }
    }
}