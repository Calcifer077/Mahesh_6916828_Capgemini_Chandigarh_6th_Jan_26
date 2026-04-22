using BookStore.Application.DTOs.Orders;
using BookStore.Core.Entities;

public class OrderService(
    IOrderRepository orderRepo,
    IBookRepository bookRepo,
    IMapper mapper,
    IEmailService emailService
) : IOrderService
{
    public async Task<OrderResponseDto> PlaceOrderAsync(int userId, OrderCreateDto dto)
    {
        var order = new Order { UserId = userId };

        foreach (var item in dto.Items)
        {
            var book =
                await bookRepo.GetByIdAsync(item.BookId)
                ?? throw new KeyNotFoundException($"Book {item.BookId} not found");

            if (book.Stock < item.Qty)
                throw new InvalidOperationException($"Insufficient stock for '{book.Title}'");

            book.Stock -= item.Qty; // Reduce stock
            bookRepo.Update(book);

            order.Items.Add(
                new OrderItem
                {
                    BookId = item.BookId,
                    Qty = item.Qty,
                    Price = book.Price,
                }
            );
        }

        order.TotalAmount = order.Items.Sum(i => i.Price * i.Qty);
        await orderRepo.AddAsync(order);
        await orderRepo.SaveChangesAsync();

        // Send confirmation email
        await emailService.SendOrderConfirmationAsync(order);

        return mapper.Map<OrderResponseDto>(order);
    }
}
