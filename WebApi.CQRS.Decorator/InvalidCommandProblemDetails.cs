using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.CQRS.Decorator.Application;

namespace WebApi.CQRS.Decorator
{
    public class InvalidCommandProblemDetails : ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException exception)
        {
            Title = "Command validation error";
            Status = StatusCodes.Status400BadRequest;
            Type = exception.GetType().ToString();
            Errors = exception.Errors;
        }

        public List<string> Errors { get; }
    }
}