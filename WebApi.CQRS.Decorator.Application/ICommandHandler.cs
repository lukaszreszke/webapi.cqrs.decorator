namespace WebApi.CQRS.Decorator.Application
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}