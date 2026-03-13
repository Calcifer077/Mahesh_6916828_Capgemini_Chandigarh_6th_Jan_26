using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RequestTracking.Data;
using RequestTracking.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RequestTrackingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RequestTrackingContext") ?? throw new InvalidOperationException("Connection string 'RequestTrackingContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

builder.Services.AddSingleton<IRequestLogService, RequestLogService>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<RequestTrackingMiddleware>();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
