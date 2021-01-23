using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApi.CQRS.Decorator.Application;

namespace WebApi.CQRS.Decorator
{
    public static class CommandHandlerRegistration
    {
        public static IServiceCollection RegisterCommandHandler<TCommandHandler, TCommand, TValidator>(
            this IServiceCollection services)
            where TCommand : ICommand
            where TCommandHandler : class, ICommandHandler<TCommand>
        {
            var type = typeof(TValidator);
            var validator = (IValidator<TCommand>) Activator.CreateInstance(type);

            services.AddTransient<TCommandHandler>();
            //
            // services.AddTransient<ICommandHandler<TCommand>>(x =>
            //     new LoggerCommandHandlerDecorator<TCommand>(
            //         x.GetService<ILogger<TCommand>>(),
            //         new ValidationCommandHandlerDecorator<TCommand>(x.GetService<TCommandHandler>(), validator)
            //     )
            // );
            
            services.AddTransient<ICommandHandler<TCommand>>(x =>
                    new ValidationCommandHandlerDecorator<TCommand>(x.GetService<TCommandHandler>(), validator)
            );

            return services;
        }
    }
}