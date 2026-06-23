using hedomi.application.DTOs.OrderDTOs;

namespace hedomi.application.Services___tharwat.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO?> CreateOrderAsync(string userId, CreateOrderDTO dto);
        Task<IEnumerable<OrderDTO>> GetMyOrdersAsync(string userId);
        Task<OrderDTO?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
    }
}