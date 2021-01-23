namespace WebApi.CQRS.Decorator
{
    public class RegisterUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}