using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.domain;

namespace hedomi.application.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
            Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
            Task<Order> GetOrderWithItemsAsync(int orderId);
            Task<IEnumerable<Order>> GetOrderByStatusAsync(string status);
            Task<decimal> GetTotalRevenueAsync();
            Task<IEnumerable<Order>> GetOrdersWithinDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
