using hedomi.application.DTOs.OrderDTOs;
using hedomi.application.Services___tharwat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace hedomi_GradProject.Controllers
{
    [ApiController]
    [Route("orders")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private string GetUserId() =>
            User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new Exception("User ID not found in claims.");

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CreateOrderDTO dto)
        {
            var result = await _orderService.CreateOrderAsync(GetUserId(), dto);
            if (result == null) return BadRequest("Order failed. Check stock availability.");
            return CreatedAtAction(nameof(GetById), new { id = result.OrderID }, result);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyOrders()
        {
            var result = await _orderService.GetMyOrdersAsync(GetUserId());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var success = await _orderService.UpdateOrderStatusAsync(id, status);
            if (!success) return NotFound();
            return Ok("Status updated.");
        }
    }
}