using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Constants;
using OnlineShop.Library.Data;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.OrdersService.Model;
using OnlineShop.Library.OrdersService.Repo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrdersDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionNames.OrdersConnection)));

builder.Services.AddTransient<IRepo<Order>, OrdersRepo>();
builder.Services.AddTransient<IRepo<OrderedGoods>, OrderedGoodsRepo>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrdersService", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "OrdersService v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(encpoints =>
{
    encpoints.MapControllers()/*.RequireAuthorization("ApiScope")*/;
});

app.Run();
