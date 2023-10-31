using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MonCatalogue.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//sql server
//builder.Services.AddDbContext<CatalogDBContext>();
//sqlite
builder.Services.AddDbContext<CatalogDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AppContextDB") ?? throw new InvalidOperationException("Connection string 'AppContextDB' not found.")));
//builder.Services.AddSession();

/*1*/
// Session state
 builder.Services.AddSession(options =>
 {
    options.IdleTimeout = TimeSpan.FromMinutes(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
     options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
 });
/*
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(2);

});*/
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Register CartService as a scoped service
//builder.Services.AddScoped<CartService>();
//builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CartService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "redirectToCreateProduct",
        pattern: "redirection/createproduct",
        defaults: new { controller = "Redirection", action = "RedirectToCreateProduct" }
    );

    // ... autres routes
});*/


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/*2*/
app.UseSession();
// Register CartService as a scoped service

app.MapRazorPages();

app.Run();
