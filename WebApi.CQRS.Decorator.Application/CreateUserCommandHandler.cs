using WebApi.CQRS.Decorator.Domain;

namespace WebApi.CQRS.Decorator.Application
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        public void Handle(CreateUserCommand command)
        {
            var user = new User(command.UserName, command.FirstName, command.LastName);
        }
    }
}