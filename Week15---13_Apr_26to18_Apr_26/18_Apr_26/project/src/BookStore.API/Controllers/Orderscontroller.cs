using System.Security.Claims;
using BookStore.Application.DTOs.Common;
using BookStore.Application.DTOs.Orders;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Handles order placement, retrieval, and admin order management.
/// All endpoints require authentication. Admin endpoints require Admin role.
/// </summary>
[ApiController]
[Route("api/v1/orders")]
[Authorize]
[Produces("application/json")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    // Helper: extract UserId from JWT claims
    private int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    // -------------------------------------------------------------------------
    // POST api/v1/orders
    // -------------------------------------------------------------------------
    /// <summary>Place a new order for the authenticated customer.</summary>
    /// <remarks>
    /// Stock is reserved and reduced immediately on order placement.
    /// An email confirmation is sent automatically.
    /// </remarks>
    /// <response code="200">Order placed successfully, returns order details.</response>
    /// <response code="400">Insufficient stock or invalid book IDs.</response>
    /// <response code="401">Not authenticated.</response>
    [HttpPost]
    [Authorize(Roles = "Customer,Admin")]
    [ProducesResponseType(typeof(ApiResponse<OrderResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PlaceOrder([FromBody] OrderCreateDto dto)
    {
        var order = await orderService.PlaceOrderAsync(CurrentUserId, dto);
        return Ok(ApiResponse<OrderResponseDto>.Ok(order, "Order placed successfully"));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/orders
    // -------------------------------------------------------------------------
    /// <summary>Get all orders belonging to the currently authenticated customer.</summary>
    /// <response code="200">List of user's orders.</response>
    [HttpGet]
    [ProducesResponseType(
        typeof(ApiResponse<IEnumerable<OrderResponseDto>>),
        StatusCodes.Status200OK
    )]
    public async Task<IActionResult> GetMyOrders()
    {
        var orders = await orderService.GetUserOrdersAsync(CurrentUserId);
        return Ok(ApiResponse<IEnumerable<OrderResponseDto>>.Ok(orders));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/orders/{id}
    // -------------------------------------------------------------------------
    /// <summary>
    /// Get details of a specific order. Customers can only view their own orders;
    /// Admins can view any order.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <response code="200">Order details returned.</response>
    /// <response code="403">Customer tried to access another user's order.</response>
    /// <response code="404">Order not found.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<OrderResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await orderService.GetOrderByIdAsync(id);

        // Customers may only see their own orders
        bool isAdmin = User.IsInRole("Admin");
        if (!isAdmin && order.UserId != CurrentUserId)
            return Forbid();

        return Ok(ApiResponse<OrderResponseDto>.Ok(order));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/orders/all               [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Get all orders across all customers. Requires Admin role.</summary>
    /// <response code="200">All orders returned.</response>
    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(
        typeof(ApiResponse<IEnumerable<OrderResponseDto>>),
        StatusCodes.Status200OK
    )]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();
        return Ok(ApiResponse<IEnumerable<OrderResponseDto>>.Ok(orders));
    }

    // -------------------------------------------------------------------------
    // PATCH api/v1/orders/{id}/status     [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Update the status of an order. Requires Admin role.</summary>
    /// <param name="id">Order ID.</param>
    /// <param name="dto">New status value: Pending | Processing | Shipped | Delivered | Cancelled</param>
    /// <response code="204">Status updated.</response>
    /// <response code="404">Order not found.</response>
    [HttpPatch("{id:int}/status")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOrderStatusDto dto)
    {
        await orderService.UpdateOrderStatusAsync(id, dto.Status);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // POST api/v1/orders/{id}/cancel
    // -------------------------------------------------------------------------
    /// <summary>
    /// Cancel an order. Customers can only cancel their own Pending orders.
    /// Admins can cancel any order in any cancellable state.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <response code="204">Order cancelled, stock restored.</response>
    /// <response code="400">Order cannot be cancelled (e.g. already shipped).</response>
    /// <response code="403">Not allowed to cancel this order.</response>
    [HttpPost("{id:int}/cancel")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CancelOrder(int id)
    {
        var order = await orderService.GetOrderByIdAsync(id);

        bool isAdmin = User.IsInRole("Admin");
        if (!isAdmin && order.UserId != CurrentUserId)
            return Forbid();

        await orderService.CancelOrderAsync(id, isAdmin);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // GET api/v1/orders/{id}/invoice
    // -------------------------------------------------------------------------
    /// <summary>Download a PDF invoice for an order.</summary>
    /// <param name="id">Order ID.</param>
    /// <response code="200">PDF invoice as file stream.</response>
    /// <response code="403">Not allowed to access this order's invoice.</response>
    [HttpGet("{id:int}/invoice")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DownloadInvoice(int id)
    {
        var order = await orderService.GetOrderByIdAsync(id);

        bool isAdmin = User.IsInRole("Admin");
        if (!isAdmin && order.UserId != CurrentUserId)
            return Forbid();

        var pdfBytes = await orderService.GenerateInvoicePdfAsync(id);
        return File(pdfBytes, "application/pdf", $"invoice-order-{id}.pdf");
    }
}
