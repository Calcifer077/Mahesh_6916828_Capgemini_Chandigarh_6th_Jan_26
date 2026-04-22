namespace BookStore.Application.DTOs.Orders;

public record OrderItemResponseDto(int BookId, string BookTitle, int Qty, decimal Price);
