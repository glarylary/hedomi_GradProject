using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hedomi.domain;
using Microsoft.EntityFrameworkCore;
using hedomi.infrastructure.AppDBcontext;
using hedomi.infrastructure.Repositories.Interfaces;

namespace hedomi.infrastructure.Implementation
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
            => await ((DbContext)_context).Set<Order>()
                .Where(o => o.UserID == userId)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Article)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

        public async Task<Order?> GetOrderWithItemsAsync(int orderId) 
            => await _context.Orders  
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Article)
                        .ThenInclude(a => a.Brand)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);
        public async Task<IEnumerable<Order>> GetOrderByStatusAsync(string status)
            => await  _context.Orders
                .Where(o => o.Status == status)
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Article)
                        .ThenInclude(a => a.Brand)
                .ToListAsync();
        public async Task<decimal> GetTotalRevenueAsync()
            => await _context.Orders
                .Where(o => o.Status == "Completed")
                .SelectMany(o => o.OrderItems)
                .SumAsync(oi => oi.PriceAtPurchase * oi.Quantity);
    }
}
