using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Task;
using Task.Utils;

Console.WriteLine("Starting up - pre init");

try
{
    var builder = WebApplication.CreateBuilder(args);
    Console.WriteLine("App Starting Up");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    SwaggerProvider.Configure(builder.Services, builder.Configuration);
    CorsProvider.Configure(builder.Services);
    ComponentRegistry.Register(builder.Services, builder.Configuration);

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

    ApplyMigration(app);

    SeedDatabase(app);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    var type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }

    Console.WriteLine(ex.Message + "Unhandled exception");
}
finally
{
    Console.WriteLine("Shut down complete");
}

static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}

static void ApplyMigration(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<Repository>();
    dbContext.Database.Migrate();
}