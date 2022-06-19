using System;
using WebApi.DBOperations;
using System.Linq;
using WebApi.Common;

namespace WebApi.BookOperations.DeleteBook2
{
    public class DeleteBookCommand
    {
        public int BookId {get;set;}
        private readonly bookyedekDbContext _dbContext;

        public DeleteBookCommand(bookyedekDbContext dbContext)
        {
            _dbContext=dbContext;

        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
            {
                throw new InvalidOperationException("ID could not be found in the library");
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }
}