using AutoMapper;
using BookStore.Application.DTOs.Auth;
using BookStore.Application.DTOs.Books;
using BookStore.Application.DTOs.Orders;
using BookStore.Core.Entities;

namespace BookStore.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Book mappings
        CreateMap<Book, BookDto>()
            .ConstructUsing(b => new BookDto(
                b.BookId,
                b.Title,
                b.ISBN,
                b.Price,
                b.Stock,
                b.ImageUrl,
                b.Category.Name,
                b.Author.Name,
                b.Publisher.Name
            ));

        CreateMap<BookCreateDto, Book>();

        CreateMap<BookUpdateDto, Book>()
            .ForAllMembers(o => o.Condition((src, dest, val) => val != null));

        // Order mappings
        CreateMap<Order, OrderResponseDto>()
            .ConstructUsing(o => new OrderResponseDto(
                o.OrderId,
                o.OrderDate,
                o.TotalAmount,
                o.Status.ToString(),
                o.Items.Select(i => new OrderItemResponseDto(
                        i.BookId,
                        i.Book.Title,
                        i.Qty,
                        i.Price
                    ))
                    .ToList()
            ));

        // User mappings
        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}
