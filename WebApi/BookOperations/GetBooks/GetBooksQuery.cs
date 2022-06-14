using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBooks{
    public class GetBooksQuery
    {
        private readonly bookyedekDbContext _dbContext;
        public GetBooksQuery(bookyedekDbContext dbContext)
        {
            _dbContext=dbContext;

        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=> x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach(var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title=book.Title,
                    PageCount=book.PageCount,
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    Genre=((GenreEnum)book.GenreId).ToString()

                });
            }
            return vm;
            
        }
    }

    public class BooksViewModel
    {
        public string Title {get;set;}
        public int PageCount {get;set;}
        public string PublishDate {get;set;}
        public string Genre {get;set;}
    }
}