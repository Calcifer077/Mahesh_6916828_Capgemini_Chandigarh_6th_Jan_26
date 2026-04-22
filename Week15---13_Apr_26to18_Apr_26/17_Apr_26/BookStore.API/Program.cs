using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(opt =>
    opt.AddPolicy(
        "AllowFrontend",
        p =>
            p.WithOrigins(
                    "http://localhost:5001",
                    "https://localhost:7001",
                    "https://bookstoremvc-mahesh-cdaedrdfb8gpe2g7.koreacentral-01.azurewebsites.net"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
    )
);

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowFrontend");
app.MapControllers();

// Auto-apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
