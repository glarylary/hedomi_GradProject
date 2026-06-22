using hedomi.application.DTOs.OrderDTOs;
using hedomi.application.Services___tharwat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace hedomi_GradProject.Controllers

{
    [ApiController]
    [Route("Orders")]
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private string GetUserIdFromClaims()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new Exception("User ID not found in claims.");
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CreateOrderDTO dto)
        {
            var result = await _orderService.CreateOrderAsync(GetUserIdFromClaims(), dto);
            if (result == null) return BadRequest("Order failed. Check stock availability.");
            return CreatedAtAction(nameof(GetById), new { id = result.OrderID }, result);
        }

    }
}
