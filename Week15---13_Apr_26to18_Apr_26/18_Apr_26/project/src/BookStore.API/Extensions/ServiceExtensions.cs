using System.Text;
using BookStore.Application.Mappings;
using BookStore.Application.Services;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddDbContext<BookStoreDbContext>(o =>
            o.UseSqlServer(config.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddValidatorsFromAssemblyContaining<BookCreateValidator>();
        return services;
    }

    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var key = Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!);
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = config["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        services.AddAuthorization();
        return services;
    }
}
