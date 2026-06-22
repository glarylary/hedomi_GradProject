using AutoMapper;
using hedomi.application.DTOs.OrderDTOs;
using hedomi.application.Repositories.Interfaces;
using hedomi.application.Services___tharwat.Interfaces;
using hedomi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderDTO?> CreateOrderAsync(string userId, CreateOrderDTO dto)
        {
            decimal total = 0;
            var items = new List<OrderItem>();

            foreach (var item in dto.Items)
            {
                var article = await _articleRepository.GetByIdAsync(item.ArticleID);
                if (article == null || article.StockQuantity < item.Quantity)
                    return null; // article not found or not enough stock

                total += article.Price * item.Quantity;
                article.StockQuantity -= item.Quantity; // deduct stock
                await _articleRepository.UpdateAsync(article);

                items.Add(new OrderItem
                {
                    ArticleID = item.ArticleID,
                    Quantity = item.Quantity,
                    PriceAtPurchase = article.Price
                });
            }

            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = total,
                Status = "Pending",
                OrderItems = items
            };

            await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderWithItemsAsync(orderId);
            return order == null ? null : _mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }
        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return false;
            order.Status = status;
            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}
