using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// adding dependency injections for Infrastructure and core
builder.Services.AddCore();
builder.Services.AddInfrastructure();

// addin middlewares to the service
builder.Services.AddTransient<ExceptionHandling>();

// adding controllers as service
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // by default asp.net unable to convert enum to string so we need to add converter
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// adding auto mapper as service
builder.Services.AddAutoMapper(typeof(ApplicationUserToAuthenticationResponseMapperProfile).Assembly);

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
