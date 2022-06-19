using System;
using WebApi.DBOperations;
using System.Linq;
using WebApi.Common;

namespace WebApi.BookOperations.UpdateBook2
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model {get;set;}
        public int BookId { get; set; }
        private readonly bookyedekDbContext _dbContext;

        public UpdateBookCommand(bookyedekDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
            {
                throw new InvalidOperationException("ID could not be found in the library.");
            }
            book.GenreId= Model.GenreId!=default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title !=default ? Model.Title : book.Title;
            _dbContext.SaveChanges();

        }

    }

    public class UpdateBookModel //Let only 'title and genre' to be able to get updated
    {
        public string Title {get;set;}
        public int GenreId {get;set;}

    }


}
