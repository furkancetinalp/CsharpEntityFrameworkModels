using WebApi.DBOperations;
using System;
using System.Linq;
namespace WebApi.BookOperations.UpdateBook
{
    public class GetBookUpdated
    {
        public int ID;
        public BookModel Model {get;set;}

        private readonly bookyedekDbContext _dbContext;
        
        public GetBookUpdated(bookyedekDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==ID);
            if(book is null){
                throw new InvalidOperationException("ID could not be found in the library.");
            }

            book.Title = Model.Title!=default ? Model.Title : book.Title;
            book.GenreId =Model.GenreId !=default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount !=default ? Model.PageCount : book.PageCount;
            book.PublishDate =Model.PublishDate !=default ? Model.PublishDate : book.PublishDate;

            _dbContext.SaveChanges();
        }

    }

    public class BookModel
    {
        public string Title {get;set;}
        public int PageCount {get;set;}
        public int GenreId {get;set;}
        public DateTime PublishDate {get;set;}

    }

}