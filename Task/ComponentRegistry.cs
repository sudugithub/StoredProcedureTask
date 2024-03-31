using Data.Repositories;
using Data.Repositories.Books;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Services.Books;
using Task.Filters;

namespace Task
{
    public class ComponentRegistry
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.Converters.Add(new StringEnumConverter());
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            serviceCollection.AddControllers(x =>
            {
                x.Filters.Add(typeof(CustomExceptionFilter));
            });

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddDbContext<Repository>(opt => opt.UseSqlServer(configuration.GetConnectionString("Repository")));
            serviceCollection.AddScoped<IDbInitializer, DbInitializer>();

            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IBookService, BookService>();
        }
    }
}
