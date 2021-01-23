using System.Linq;
using FluentValidation;

namespace WebApi.CQRS.Decorator.Application
{
    public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;
        private readonly IValidator<TCommand> _validator;

        public ValidationCommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            _decorated = decorated;
        }
        public ValidationCommandHandlerDecorator(ICommandHandler<TCommand> decorated, IValidator<TCommand> validator)
        {
            _decorated = decorated;
            _validator = validator;
        }

        public void Handle(TCommand command)
        {
            var result = _validator.Validate(command);

            if (result.Errors.Any())
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                
                throw new InvalidCommandException(errorMessages);
            }
            
            _decorated.Handle(command);
        }
    }
}