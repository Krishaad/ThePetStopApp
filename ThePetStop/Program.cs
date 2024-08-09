using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThePetStop.Areas.Identity.Data;
using ThePetStop.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ThePetStopDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ThePetStopDBContextConnection' not found.");

builder.Services.AddDbContext<ThePetStopDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ThePetStopUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ThePetStopDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ThePetStopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThePetStopContext") ?? throw new InvalidOperationException("Connection string 'ThePetStopContext' not found.")));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();
