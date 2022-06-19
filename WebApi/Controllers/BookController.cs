using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook2;
using AutoMapper;
using System;
using FluentValidation;
using FluentValidation.Results;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly bookyedekDbContext _context;
        private readonly IMapper _mapper;

        public BookController(bookyedekDbContext context,IMapper mapper){
            _context=context;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            BookDetailViewModel result;
            try{
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId=id;
                GetBookWithIdValidator valitator = new GetBookWithIdValidator();
                valitator.ValidateAndThrow(query);
                result =query.Handle();
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);



            /*
            GetBookWithId query = new GetBookWithId(_context);
            query.id=id;

            try{
                var result =query.Handle();
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            */

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try{
                command.Model=newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                /*
                ValidationResult results = validator.Validate(command);

                
                if(!results.IsValid)
                {
                    foreach(var s in results.Errors)
                    {
                        Console.WriteLine("Property: "+s.PropertyName+"=>"+"Error: "+s.ErrorMessage);
                    }
                }
                else
                {
                    command.Handle();
                }
                */

            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }      
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            try{
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId=id;
                command.Model=updateBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();




            /*
            GetBookUpdated query = new GetBookUpdated(_context);
            query.ID=id;
            query.Model=updateBook;
            try{
                query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
            */
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            GetBookDeleted query = new GetBookDeleted(_context);
            query.ID=id;

            try{
                DeleteBookCommandValidation validation = new DeleteBookCommandValidation();
                validation.ValidateAndThrow(query);
                query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        

    }

}