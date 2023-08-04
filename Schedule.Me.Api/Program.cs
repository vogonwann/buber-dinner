using Schedule.Me.Api;
using Schedule.Me.Application;
using Schedule.Me.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{   
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}