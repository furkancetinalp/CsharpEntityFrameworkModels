using System;
using WebApi.DBOperations;
using System.Linq;
using AutoMapper;
using WebApi.Common;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int BookId {get;set;}
        private readonly bookyedekDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(bookyedekDbContext dbContext,IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(x=>x.Id==BookId).SingleOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("ID could not be found in the library.");
            }
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            /*
            vm.Title=book.Title;
            vm.PageCount=book.PageCount;
            vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre=((GenreEnum)book.GenreId).ToString(); */
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title{get;set;}
        public string Genre {get;set;}
        public int PageCount {get;set;}
        public string PublishDate {get;set;}
    }

}