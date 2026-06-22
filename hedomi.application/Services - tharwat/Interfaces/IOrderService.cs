using hedomi.application.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO?> CreateOrderAsync(string userId, CreateOrderDTO createOrderDTO);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(string userId);
        Task<OrderDTO?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus);
    }
}
