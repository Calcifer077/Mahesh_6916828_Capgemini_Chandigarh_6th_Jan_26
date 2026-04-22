namespace BookStore.Application.DTOs.Orders;

public record OrderResponseDto(
    int OrderId,
    DateTime OrderDate,
    decimal TotalAmount,
    string Status,
    List<OrderItemResponseDto> Items
);
