using Schedule.Me.Application.Common.Interfaces.Persistence;
using Schedule.Me.Domain.Entities;

namespace Schedule.Me.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new(); // static because service is Scoped

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
   }
}