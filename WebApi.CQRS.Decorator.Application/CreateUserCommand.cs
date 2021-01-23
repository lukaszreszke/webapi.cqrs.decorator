namespace WebApi.CQRS.Decorator.Application
{
    public class CreateUserCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}