using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NewsWebsite.Models;



var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("NewsWebsiteContextConnection") ?? throw new InvalidOperationException("Connection string 'NewsWebsiteContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
builder.Services.AddDbContext<NewsDBcontext>(item => item.UseSqlServer(configuration.GetConnectionString("myconn")));
builder.Services.AddSession();
//builder.Services.AddScoped<IAccountService, AccountService>();
//builder.Services.AddDefaultIdentity<NewsWebsiteUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<NewsWebsiteContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
