using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implemintations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<User> GetUser()
        {
            var userWithMaxOrders = _context.Users
                                    .OrderByDescending(u => u.Orders.Count)
                                    .FirstOrDefault();

            return Task.FromResult(userWithMaxOrders);
        }

        public Task<List<User>> GetUsers()
        {
            return Task.FromResult(_context.Users.Where(i => i.Status == Enums.UserStatus.Inactive).ToList());
        }
    }
}
