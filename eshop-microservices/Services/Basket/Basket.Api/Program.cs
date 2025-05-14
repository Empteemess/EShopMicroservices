using Basket.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IBasketRepository,BasketRepository>();

// Add services to the container.
builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    opt.Schema.For<ShoppingCart>().Identity(x => x.UserName!);
})
.UseLightweightSessions();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapCarter();

// Configure the HTTP request pipeline.

app.Run();