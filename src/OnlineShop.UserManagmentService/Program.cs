using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Library.Constants;
using OnlineShop.Library.Data;
using OnlineShop.Library.UserManagmentService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionNames.UsersConnection)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "https://localhost:5001";
        //options.ApiName = "https://localhost:5001/resources",
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", IdConstants.ApiScope);
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
