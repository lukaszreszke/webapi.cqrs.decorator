using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.CQRS.Decorator.Application;

namespace WebApi.CQRS.Decorator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        [HttpPost]
        public ActionResult RegisterUser(
            [FromServices] ICommandHandler<CreateUserCommand> handler,
            [FromBody] RegisterUserRequest request)
        {
            var command = new CreateUserCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            handler.Handle(command);

            return new OkResult();
        }
    }
}