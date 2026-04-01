using LearningPlatform.API.Data;
using LearningPlatform.API.Mappings;
using LearningPlatform.API.Middleware;
using LearningPlatform.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. DATABASE - EF Core + SQL Server
// ==========================================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================================
// 2. AUTHENTICATION - JWT Bearer
// ==========================================
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]
    ?? throw new InvalidOperationException("JWT SecretKey not configured");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(
                "{\"error\": \"Unauthorized. Please provide a valid JWT token.\"}");
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(
                "{\"error\": \"Forbidden. You do not have permission to access this resource.\"}");
        }
    };
});

builder.Services.AddAuthorization();

// ==========================================
// 3. CACHING - IMemoryCache
// ==========================================
builder.Services.AddMemoryCache();

// ==========================================
// 4. AUTOMAPPER
// ==========================================
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ==========================================
// 5. SERVICES (DI)
// ==========================================
builder.Services.AddScoped<IJwtService, JwtService>();

// ==========================================
// 6. CONTROLLERS + JSON OPTIONS
// ==========================================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Keep PascalCase
    });

// ==========================================
// 7. SWAGGER / OPENAPI
// ==========================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Learning Platform API",
        Version = "v1",
        Description = "Online Learning Platform API - Similar to Udemy",
        Contact = new OpenApiContact
        {
            Name = "Learning Platform Team",
            Email = "support@learnify.com"
        }
    });

    // JWT Authentication in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your_jwt_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ==========================================
// 8. CORS
// ==========================================
var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });

    // Open policy for development
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ==========================================
// BUILD APP
// ==========================================
var app = builder.Build();

// ==========================================
// MIDDLEWARE PIPELINE
// ==========================================

// Global error handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning Platform API v1");
        c.RoutePrefix = "swagger";
        c.DocumentTitle = "Learning Platform API";
    });

    app.UseCors("AllowAll"); // Open CORS in dev
}
else
{
    app.UseCors("FrontendPolicy");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Auto-migrate database on startup (Development only)
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogWarning(ex, "Could not apply migrations. Database may need to be created manually.");
    }
}

app.Run();
