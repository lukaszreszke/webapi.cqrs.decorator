namespace WebApi.CQRS.Decorator.Domain
{
    public class User
    {
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        
        public User(string userName, string firstName, string lastName)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}