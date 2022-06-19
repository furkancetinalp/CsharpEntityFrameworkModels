using FluentValidation;
namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookWithIdValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookWithIdValidator()
        {
            RuleFor(command =>command.BookId).GreaterThan(0);
        }
    }
}