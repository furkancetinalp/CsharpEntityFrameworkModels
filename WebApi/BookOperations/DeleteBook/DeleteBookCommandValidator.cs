using FluentValidation;
using WebApi.BookOperations.DeleteBook;
namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidation : AbstractValidator<GetBookDeleted>
    {
        public DeleteBookCommandValidation()
        {
            RuleFor(command=>command.ID).GreaterThan(0);
        }

    }
}