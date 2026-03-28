using EmployeeManagementPortal.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<LogActionFilter>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();