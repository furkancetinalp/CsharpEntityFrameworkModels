using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly bookyedekDbContext _context;

        public BookController(bookyedekDbContext context){
            _context=context;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context);
            var result =query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            GetBookWithId query = new GetBookWithId(_context);
            query.id=id;

            try{
                var result =query.Handle();
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){

            CreateBookCommand command = new CreateBookCommand(_context);
            try{
                command.Model=newBook;
                command.Handle();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }      
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,BookModel updateBook)
        {
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
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            GetBookDeleted query = new GetBookDeleted(_context);
            query.ID=id;

            try{
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