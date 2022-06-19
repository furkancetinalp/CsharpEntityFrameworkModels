using FluentValidation;
namespace WebApi.BookOperations.UpdateBook2
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0).NotEmpty();
            RuleFor(command=>command.Model.GenreId).NotEmpty().GreaterThan(0).LessThan(4);
            RuleFor(command=>command.Model.Title).NotEmpty();
            

        }
    }
}