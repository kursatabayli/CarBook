using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CarBook.WebUI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Configure Authentication and Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
            opt.LoginPath = "/Admin/AdminLogin/Index/";
            opt.LogoutPath = "/Admin/AdminLogin/Logout/";
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            opt.Cookie.Name = "CarBookJwt";
        });

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(IApiService<>), typeof(ApiService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();