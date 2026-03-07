using GreeterLib;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IGreeter, Greeter>();

        var provider = services.BuildServiceProvider();
        var greeter = provider.GetRequiredService<IGreeter>();

        Console.WriteLine(greeter.Greet("Himanshi"));
    }
}
