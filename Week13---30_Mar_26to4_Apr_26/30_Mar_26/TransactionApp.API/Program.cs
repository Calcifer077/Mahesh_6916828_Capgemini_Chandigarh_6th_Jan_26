using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// ✅ Make the app listen on all network interfaces (important for IIS + server access)
builder.WebHost.UseUrls("http://0.0.0.0:5283");   // Change 5283 to any port you want

// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ Swagger - Enable in both Development and Production for now
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ));

// ✅ Services
builder.Services.AddScoped<TokenService>();

// ✅ AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// ✅ CORS (Frontend on port 5500)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// ✅ JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

// ✅ Authorization
builder.Services.AddAuthorization();

// 🔥 BUILD THE APP
var app = builder.Build();

// ✅ Enable Swagger for both Development and Production (so /swagger works after publish)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    // Optional: Make Swagger open at root URL[](http://localhost:5283/)
    // c.RoutePrefix = string.Empty;
});

// Optional but recommended
app.UseHttpsRedirection();

// 🔥 VERY IMPORTANT - Correct Middleware Order
app.UseCors("AllowFrontend");     // Must come before Authentication

app.UseAuthentication();
app.UseAuthorization();

// ✅ Map controllers
app.MapControllers();

app.Run();