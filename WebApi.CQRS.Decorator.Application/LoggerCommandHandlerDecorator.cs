using System;
using Microsoft.Extensions.Logging;

namespace WebApi.CQRS.Decorator.Application
{
    public class LoggerCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;
        private readonly ILogger<TCommand> _logger;
        
        public LoggerCommandHandlerDecorator(ILogger<TCommand> logger, ICommandHandler<TCommand> decorated)
        {
            _logger = logger;
            _decorated = decorated;
        }

        public void Handle(TCommand command)
        {
            try
            {
                _logger.Log(
                    LogLevel.Information,
                    "Executing command {Command}",
                    command.GetType().Name);

                _decorated.Handle(command);

                _logger.Log(
                    LogLevel.Information,
                    "Command {Command} processed successful",
                    command.GetType().Name);
            }
            catch (Exception exception)
            {
                _logger.Log(
                    LogLevel.Error,
                    exception,
                    "Command {Command} processing failed",
                    command.GetType().Name);
                throw;
            }
        }
    }
}