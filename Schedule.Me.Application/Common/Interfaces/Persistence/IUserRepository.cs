using Schedule.Me.Domain.Entities;

namespace Schedule.Me.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}