using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Constants;
using OnlineShop.Library.Data;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.Options;
using OnlineShop.Library.OrdersService.Model;
using OnlineShop.Library.OrdersService.Repo;
using OnlineShop.Library.UserManagmentService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrdersDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionNames.OrdersConnection)));
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionNames.UsersConnection)));

builder.Services.AddTransient<IRepo<Order>, OrdersRepo>();
builder.Services.AddTransient<IRepo<OrderedGoods>, OrderedGoodsRepo>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<UsersDbContext>()
               .AddDefaultTokenProviders();

/*var serviceAddressOptions = new ServiceAdressOptions();
builder.Configuration.GetSection(ServiceAdressOptions.SectionName).Bind(serviceAddressOptions);*/

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "https://localhost:5001";
        //options.ApiName = "https://localhost:5001/resources",
        options.RequireHttpsMetadata = false;
    });

/*builder.Services.AddAuthentication(
    IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Authority = serviceAddressOptions.IdentityServer;
        //options.ApiName = $"{serviceAddressOptions.IdentityServer}/resources";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters() { ValidateAudience = false };
    });*/

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", IdConstants.ApiScope);
    });
});

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(encpoints =>
{
    encpoints.MapControllers().RequireAuthorization("ApiScope");
});

app.Run();
