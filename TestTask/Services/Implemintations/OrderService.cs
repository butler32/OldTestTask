using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implemintations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Order> GetOrder()
        {
            var orderWithMaxPrice = _context.Orders
                                    .OrderByDescending(u => u.Price)
                                    .FirstOrDefault();
            return Task.FromResult(orderWithMaxPrice);
        }

        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(_context.Orders.Where(q => q.Quantity > 10).ToList());
        }
    }
}