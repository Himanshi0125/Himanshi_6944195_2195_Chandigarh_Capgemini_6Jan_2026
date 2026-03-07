var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/", () => "Hello");
app.MapGet("/error", () => "Something went wrong!");

app.Run();
