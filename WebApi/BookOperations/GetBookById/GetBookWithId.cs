using WebApi.Controllers;
using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.BookOperations.GetBookById
{

    public class GetBookWithId
    {
        public int id;
        private readonly bookyedekDbContext _dbContext;
        public GetBookWithId(bookyedekDbContext dbContext)
        {
            _dbContext=dbContext;

        }

        public getBookModel Handle()
        {
            var book = _dbContext.Books.Where(x=>x.Id==id).SingleOrDefault();
            if(book is null){
                throw new InvalidOperationException("ID could not be found in the library.");
            }
            getBookModel Model = new getBookModel();
            Model.Title=book.Title;
            Model.GenreId=book.GenreId;
            Model.PageCount=book.PageCount;
            Model.PublishDate=book.PublishDate;
            return Model;

        }
    }

    public class getBookModel
    {
        public string Title {get;set;}
        public int GenreId {get;set;}
        public int PageCount {get;set;}
        public DateTime PublishDate {get;set;}
    }
}