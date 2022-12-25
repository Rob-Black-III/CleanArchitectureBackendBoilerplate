using CleanArchitectureBoilerplate.API;
using CleanArchitectureBoilerplate.API.Middleware;
using CleanArchitectureBoilerplate.Application;
using CleanArchitectureBoilerplate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container. Also for DI
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration); // This is why we have a layer reference to infrastructure.
    builder.Services.AddPresentationServices();

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    // Add all of our custom middleware to the request pipeline.
    app.RegisterCustomMiddleware();

    app.Run();
}
