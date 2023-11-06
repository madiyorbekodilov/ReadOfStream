using Microsoft.Extensions.DependencyInjection;
using ReadOfStream.DbContexts;
using ReadOfStream.Interface;
using ReadOfStream.Services;

var serviceProvider = ConfigureServices();

using (var scope = serviceProvider.CreateScope())
{
    var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

    // Your application logic here
    // Example:
    var userId = Guid.NewGuid();
    var user = userService.GetUserById(userId);
    Console.WriteLine($"User ID: {userId}, User Name: {user?.Name}");

    // Don't forget to dispose of the services when done
}

static IServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();

    services.AddDbContext<AppDbContext>();
    services.AddScoped<IUserService, UserService>();

    return services.BuildServiceProvider();
}