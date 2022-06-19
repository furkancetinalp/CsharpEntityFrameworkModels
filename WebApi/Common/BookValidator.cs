using FluentValidation;
using WebApi.BookOperations.CreateBook;
namespace WebApi.Common
{
    public class BookValidator:AbstractValidator<CreateBookModel>
    {
        public BookValidator()
        {
            RuleFor(CreateBookModel =>CreateBookModel.Title).NotEmpty();
            RuleFor(CreateBookModel =>CreateBookModel.PageCount).NotEmpty();
            RuleFor(CreateBookModel =>CreateBookModel.GenreId).NotEmpty();
            RuleFor(CreateBookModel =>CreateBookModel.GenreId).LessThan(4);
            RuleFor(CreateBookModel =>CreateBookModel.PublishDate).NotEmpty();
            RuleFor(CreateBookModel=>CreateBookModel.PublishDate).LessThan(System.DateTime.Now);
        }
    


    }

}