using Microsoft.EntityFrameworkCore;
using EfCoreCodeFirstApproachDemo01.Models;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var cs1 = builder.Configuration.GetConnectionString("cs1");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register EF Core DbContext
builder.Services.AddDbContext<EmployeeDBContext>(options =>
    options.UseSqlServer(cs1));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();