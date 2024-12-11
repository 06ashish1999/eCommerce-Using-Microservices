using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// adding dependency injections for Infrastructure and core
builder.Services.AddCore();
builder.Services.AddInfrastructure();

// addin middlewares to the service
builder.Services.AddTransient<ExceptionHandling>();

var app = builder.Build();

// exception handling
app.HandleExceptionsIfAny();

// routing
app.UseRouting();

// authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// mapping controller routes
app.MapControllers();

app.Run();
