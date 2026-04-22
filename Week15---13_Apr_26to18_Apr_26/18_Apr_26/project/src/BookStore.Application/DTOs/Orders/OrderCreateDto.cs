namespace BookStore.Application.DTOs.Orders;

public record OrderCreateDto(List<OrderItemCreateDto> Items);
