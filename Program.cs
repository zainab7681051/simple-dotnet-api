using simple_dotnet_api.Repo;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        /*registrating a service:
        when we request for one item by id we get null
        because Guid recreates a new id and assigns it to
        the id field.
        so to prevent that we need AddSingleton with
        the interface and its implementation as part of
        dependency injection technique
        more at https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0

        NOTE:
        1-Singleton objects are the same for every object
        and every request.

        2-Transient objects are always different;
        a new instance is provided to every controller
        and every service.

        3-Scoped objects are the same within a request,
        but different across different requests.

        more at https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
        */
        builder.Services.AddSingleton<IinMemRepo, inMemRepo>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
