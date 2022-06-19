using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get;set;}
        private readonly bookyedekDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(bookyedekDbContext dbContext,IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;

        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.Title);
            if(book is not null){
                throw new InvalidOperationException("Kitap zaten mevcuttur!!!");
            }
            /*
            BookValidator validator = new BookValidator();
            ValidationResult result = validator.Validate(Model);
            if(!result.IsValid)
            {
                foreach(var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + " "+failure.ErrorMessage);
                }
                throw new InvalidOperationException("Inputs are not correct.");

            }
            */
            book = _mapper.Map<Book>(Model);//new Book();
            
            /*
            book.Title=Model.Title;
            book.GenreId=Model.GenreId;
            book.PageCount=Model.PageCount;
            book.PublishDate=Model.PublishDate; */

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }
    }

    public class CreateBookModel
    {
        public string Title {get;set;}
        public int GenreId {get;set;}
        public int PageCount {get;set;}
        public DateTime PublishDate {get;set;}
    }

}