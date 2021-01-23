using FluentValidation;

namespace WebApi.CQRS.Decorator.Application
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull();
            RuleFor(x => x.LastName).NotEmpty().NotNull();
            RuleFor(x => x.UserName).NotEmpty().NotNull();
        }
    }
}