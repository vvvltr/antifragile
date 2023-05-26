using System.Security.Claims;
using antifragile.Data.Interfaces;
using antifragile.Data.Mocks;
using antifragile.Data.Models;
using antifragile.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProducts, MockProducts>();
builder.Services.AddTransient<ICategory, MockCategory>();
builder.Services.AddTransient<IUser, MockUsers>();
builder.Services.AddTransient<IAddress, MockAddresses>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Profile/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

/*app.MapGet("/profile/login", (HttpContext ctx) =>
{
    ctx.Response.Headers["set-cookie"] = "auth=user:me";
    return "ok";
});*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});



app.Run();